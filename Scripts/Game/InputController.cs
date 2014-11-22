using System;
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
	}

    private PlayerMotion _playerMotion;
    private PlayerAction _playerAction;

    private bool _monsterCollision;
    private bool _scientistCollision;

    private Ennemy _ennemy;

    private bool _test;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Ennemy>().IsHiddenScientist)
            _scientistCollision = true;
        else _monsterCollision = true;
        _ennemy = other.gameObject.GetComponent<Ennemy>();
    }

    void OnTriggerExit(Collider other)
    {
        _scientistCollision = false;
        _monsterCollision = false;
        _ennemy = null;
    }
	
    void Controller()
    {
        if (Input.GetButtonDown("Up")) { _playerMotion.MoveUp(); }
        if (Input.GetButtonDown("Down")) { _playerMotion.MoveDown(); }
        if (Input.GetButtonDown("Action")) { _playerAction.UseCompetence(); }
        if (Input.GetButtonDown("Jump")) { _playerMotion.Jump(); }
    }

    void OrgansController()
    {
        if (Input.GetButtonDown("Head"))
        {
            if (_monsterCollision)
                _playerAction.AddMember(PlayerAction.Membre.Tete, _ennemy.HeadPrefab);
            if (_scientistCollision)
                _playerAction.Arracher();
        }
        if (Input.GetButtonDown("LeftArm"))
        {
            if (_monsterCollision)
                _playerAction.AddMember(PlayerAction.Membre.BrasGauche, _ennemy.ArmPrefab);
            if (_scientistCollision)
                _playerAction.Arracher();
        }
        if (Input.GetButtonDown("RightArm"))
        {
            if (_monsterCollision)
                _playerAction.AddMember(PlayerAction.Membre.BrasDroit, _ennemy.ArmPrefab);
            if (_scientistCollision)
                _playerAction.Arracher();
        }
        if (Input.GetButtonDown("LeftLeg"))
        {
            if (_monsterCollision)
                _playerAction.AddMember(PlayerAction.Membre.JambeGauche, _ennemy.LegPrefab);
            if (_scientistCollision)
                _playerAction.Arracher();
        }
        if (Input.GetButtonDown("RightLeg"))
        {
            if (_monsterCollision)
                _playerAction.AddMember(PlayerAction.Membre.JambeDroite, _ennemy.LegPrefab);
            if (_scientistCollision)
                _playerAction.Arracher();
        }
    }

	// Update is called once per frame
	void Update () {
	    Controller();
        OrgansController();
	}
}
