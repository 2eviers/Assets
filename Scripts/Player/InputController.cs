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

    public int NbOrgans = 0;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Ennemy>().IsHiddenScientist)
            _scientistCollision = true;
        else _monsterCollision = true;
        _ennemy = other.gameObject.GetComponent<Ennemy>();
		Debug.Log ("entrée");
		other.gameObject.renderer.material.color = Color.red;
    }

	void OnTriggerStay(Collider other)
	{
		OrgansController();
	}

    void OnTriggerExit(Collider other)
    {
        _scientistCollision = false;
        _monsterCollision = false;
		Debug.Log ("exit");
		_ennemy = other.gameObject.GetComponent<Ennemy>();
		_ennemy.Die ();
		Debug.Log("Fin de la collision, ennemi meurt.");
		other.gameObject.renderer.material.color = Color.green;

//		_ennemy.Die ();
    }
	
    void Controller()
    {
        if (Input.GetButtonDown("Up")){_playerMotion.MoveUp();}
        if (Input.GetButtonDown("Down")) { _playerMotion.MoveDown(); }
        if (Input.GetButtonDown("Action")) { _playerAction.UseCompetence(); }
        if (Input.GetButtonDown("Jump") && !_playerMotion.IsJumping) { _playerMotion.Jump(); }
    }

    void OrgansController()
    {
		if (_ennemy == null)
			return;
        if (Input.GetButtonDown("Head"))
        {
            if (_monsterCollision)
            {
                _playerAction.AddMember(PlayerAction.Membre.Tete, _ennemy.HeadPrefab);
                NbOrgans++;
            }
            if (_scientistCollision)
                _playerAction.Arracher();
        }
        else if (Input.GetButtonDown("LeftArm"))
        {
            if (_monsterCollision)
            {
                _playerAction.AddMember(PlayerAction.Membre.BrasGauche, _ennemy.ArmLeftPrefab);
                NbOrgans++;
            }
            if (_scientistCollision)
                _playerAction.Arracher();
        }
        else if (Input.GetButtonDown("RightArm"))
        {
            if (_monsterCollision)
            {
                _playerAction.AddMember(PlayerAction.Membre.BrasDroit, _ennemy.ArmRightPrefab);
                NbOrgans++;
            }
            if (_scientistCollision)
                _playerAction.Arracher();
        }
        else if (Input.GetButtonDown("LeftLeg"))
        {
            if (_monsterCollision)
            {
                _playerAction.AddMember(PlayerAction.Membre.JambeGauche, _ennemy.LegLeftPrefab);
                NbOrgans++;
            }
            if (_scientistCollision)
                _playerAction.Arracher();
        }
        else if (Input.GetButtonDown("RightLeg"))
        {
            if (_monsterCollision)
            {
                _playerAction.AddMember(PlayerAction.Membre.JambeDroite, _ennemy.LegRightPrefab);
                NbOrgans++;
            }
            if (_scientistCollision)
                _playerAction.Arracher();
        }

		if (Input.GetButtonDown ("Head") || Input.GetButtonDown ("LeftArm") || 
		    	Input.GetButtonDown ("RightArm") || Input.GetButtonDown ("LeftLeg") || 
		    	Input.GetButtonDown ("RightLeg") && _monsterCollision && _ennemy.gameObject != null) {
			_ennemy.Die ();
			Debug.Log("J't'ai tué !");
		}
    }

	// Update is called once per frame
	void Update () {
	    Controller();
	}
}
