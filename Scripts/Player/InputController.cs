﻿using System;
using AssemblyCSharp;
using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
	    _playerMotion = GetComponent<PlayerMotion>();
	    _playerAction = GetComponent<PlayerAction>();

	    _monsterCollision = false;
	    _scientistCollision = false;
	    _action = false;
	}

    private PlayerMotion _playerMotion;
    private PlayerAction _playerAction;

    private bool _monsterCollision;
    private bool _scientistCollision;
    private bool _action;

    private Ennemy _ennemy;

    private bool _test;
    private bool _isAxisInUse;

    //public int NbOrgans = 0;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Ennemy>().IsHiddenScientist)
        {
            _scientistCollision = true;
            if (!_playerAction.UseShield())
                _playerAction.Arracher();

            other.gameObject.GetComponent<Ennemy>().Die();
            _scientistCollision = false;

        }
        else _monsterCollision = true;
        _ennemy = other.gameObject.GetComponent<Ennemy>();
        other.gameObject.GetComponent<Renderer>().material.color = Color.red;
    }

    

    public void Exit(Collider other)
    {
        _scientistCollision = false;
        _monsterCollision = false;
        _ennemy = other.gameObject.GetComponent<Ennemy>();
        _ennemy.Die();
        _ennemy = null;
        if (!_action)
            _playerAction.Recul();
        _action = false;
        //		other.gameObject.renderer.material.color = Color.green;
        other.gameObject.GetComponent<Renderer>().material.color = Color.green;

        //		_ennemy.Die ();
    }

    void OnTriggerExit(Collider other)
    {
        Exit(other);
    }
	
    void Controller()
    {
		bool headless = _playerAction.Headless ();
        String up = headless ? "Down" : "Up";
		String down = headless ? "Up" : "Down";

        bool isUp = Input.GetButtonDown(up);
        bool isDown = Input.GetButtonDown(down);


        if (Input.GetAxisRaw("Vertical") != 0)
        {
            if (_isAxisInUse == false)
            {
                _isAxisInUse = true;
                int opp = headless ? -1 : 1;
                isUp = (opp * Input.GetAxisRaw("Vertical")) > 0;
                isDown = (opp * Input.GetAxisRaw("Vertical")) < 0;

            }
        }
        else
            _isAxisInUse = false;
//*/

		if (isUp)_playerMotion.MoveUp();
        if (isDown)_playerMotion.MoveDown();
        if (Input.GetButtonDown("Action"))  _playerAction.UseCompetence(); 
        if (Input.GetButtonDown("Jump") && !_playerMotion.IsJumping)  _playerMotion.Jump(); 
    }

    void OrgansController()
    {
		bool headless = _playerAction.Headless ();
		String head = headless ? "LeftArm" : "Head";
		String leftarm = headless ? "LeftLeg" : "LeftArm";
		String rightarm = headless ? "Head" : "RightArm";
		String leftleg = headless ? "RightLeg" : "LeftLeg";
		String rightleg = headless ? "LeftArm" : "RightLeg";

        #region jeter

        if (!_monsterCollision && !_scientistCollision)
        {
            if (Input.GetButtonDown(head))
                _playerAction.Jeter(PlayerAction.Membre.Tete);
            else if (Input.GetButtonDown(leftarm))
                _playerAction.Jeter(PlayerAction.Membre.BrasGauche);
            else if (Input.GetButtonDown(rightarm))
                _playerAction.Jeter(PlayerAction.Membre.BrasDroit);
            else if (Input.GetButtonDown(leftleg))
                _playerAction.Jeter(PlayerAction.Membre.JambeGauche);
            else if (Input.GetButtonDown(rightleg))
                _playerAction.Jeter(PlayerAction.Membre.JambeDroite);
        }
        #endregion

        if(_ennemy == null)
            return;

        #region AddMember
        if (Input.GetButtonDown(head))
        {
            if (_monsterCollision)
            {
                _action = true;
                _playerAction.AddMember(PlayerAction.Membre.Tete, _ennemy.HeadPrefab);
                //NbOrgans++;
            }
        }
        else if (Input.GetButtonDown(leftarm))
        {
            if (_monsterCollision)
            {
                _action = true;
                _playerAction.AddMember(PlayerAction.Membre.BrasGauche, _ennemy.ArmLeftPrefab);
                //NbOrgans++;
            }
        }
        else if (Input.GetButtonDown(rightarm))
        {
            if (_monsterCollision)
            {
                _action = true;
                _playerAction.AddMember(PlayerAction.Membre.BrasDroit, _ennemy.ArmRightPrefab);
                //NbOrgans++;
            }
        }
        else if (Input.GetButtonDown(leftleg))
        {
            if (_monsterCollision)
            {
                _action = true;
                _playerAction.AddMember(PlayerAction.Membre.JambeGauche, _ennemy.LegLeftPrefab);
                //NbOrgans++;
            }
        }
        else if (Input.GetButtonDown(rightleg))
        {
            if (_monsterCollision)
            {
                _action = true;
                _playerAction.AddMember(PlayerAction.Membre.JambeDroite, _ennemy.LegRightPrefab);
                //NbOrgans++;
            }
        }

		if (_action)
		{
		    _action = false;
			_ennemy.Die ();
			_ennemy = null;
		    _monsterCollision = false;
		    _scientistCollision = false;
		}
        #endregion

    }

	// Update is called once per frame
	void Update () {
	    Controller();
        OrgansController();
	}
}
