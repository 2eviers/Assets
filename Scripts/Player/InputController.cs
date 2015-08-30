using System;
using AssemblyCSharp;
using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class InputController : MonoBehaviour
{
    #region Injections
    private PlayerMotion _playerMotion;
    private PlayerAction _playerAction;
    #endregion

    #region Properties
    [SerializeField]
    float _delayActionMemberInput = 0.3f;
    #endregion
    
    #region Events
    public Engine.TypedUnityEvents.BoolEvent onCollision = new Engine.TypedUnityEvents.BoolEvent();
    #endregion

    #region Unity
    void Start ()
	{
	    _playerMotion = GetComponent<PlayerMotion>();
	    _playerAction = GetComponent<PlayerAction>();

	    _monsterCollision = false;
	    _scientistCollision = false;
	    _action = false;

        onCollision.Invoke(false);
	}

    void OnTriggerEnter(Collider other)
    {
        onCollision.Invoke(true);

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

    void OnTriggerExit(Collider other)
    {
        onCollision.Invoke(false);

        _scientistCollision = false;
        _monsterCollision = false;
        _ennemy = other.gameObject.GetComponent<Ennemy>();
        _ennemy.Die();
        _ennemy = null;
        if (!_action)
            _playerAction.Recul();
        _action = false;
        
        other.gameObject.GetComponent<Renderer>().material.color = Color.green;
    }

    void Update()
    {
        Controller();
        OrgansController();
    }
    #endregion

    #region API mobile input
    public void MobileInput(string button)
    {
        switch (button)
        {
            case "Up":
                _mobileUp = true;
                break;
            case "Down":
                _mobileDown = true;
                break;
            case "Jump":
                _mobileJump = true;
                break;
            case "Action":
                _mobileAction = true;
                break;
            case "Head":
                _mobileHead = true;
                break;
            case "RightArm":
                _mobileRightArm = true;
                break;
            case "LeftArm":
                _mobileLeftArm = true;
                break;
            case "RightLeg":
                _mobileRightLeg = true;
                break;
            case "LeftLeg":
                _mobileLeftLeg = true;
                break;
        }
    }
    #endregion

    #region Private
    private bool _mobileUp = false;
    private bool _mobileDown = false;
    private bool _mobileAction = false;
    private bool _mobileJump = false;

    private bool _mobileHead = false;
    private bool _mobileLeftArm = false;
    private bool _mobileRightArm = false;
    private bool _mobileLeftLeg = false;
    private bool _mobileRightLeg = false;

    private bool _monsterCollision;
    private bool _scientistCollision;
    private bool _action;

    private Ennemy _ennemy;

    private bool _test;
    private bool _isAxisInUse;
	
    void Controller()
    {
		bool headless = _playerAction.Headless ();

        bool isUp = InputGetButtonUp(headless);
        bool isDown = InputGetButtonDown(headless);

        if (InputGetAxisVertical() != 0)
        {
            if (_isAxisInUse == false)
            {
                _isAxisInUse = true;
                int opp = headless ? -1 : 1;
                isUp = (opp * InputGetAxisVertical()) > 0;
                isDown = (opp * InputGetAxisVertical()) < 0;
            }
        }
        else
            _isAxisInUse = false;

		if (isUp)_playerMotion.MoveUp();
        if (isDown)_playerMotion.MoveDown();
        if (InputGetButtonAction())  _playerAction.UseCompetence(); 
        if (InputGetButtonJump() && !_playerMotion.IsJumping)  _playerMotion.Jump(); 
    }

    void OrgansController()
    {
		bool headless = _playerAction.Headless();
		String head = headless ? "LeftArm" : "Head";
		String leftarm = headless ? "LeftLeg" : "LeftArm";
		String rightarm = headless ? "Head" : "RightArm";
		String leftleg = headless ? "RightLeg" : "LeftLeg";
		String rightleg = headless ? "LeftArm" : "RightLeg";

        #region jeter
        if (!_monsterCollision && !_scientistCollision)
        {
            if (InputGetButtonHead())
                _playerAction.Jeter(PlayerAction.Membre.Tete);
            else if (InputGetButtonLeftArm())
                _playerAction.Jeter(PlayerAction.Membre.BrasGauche);
            else if (InputGetButtonRightArm())
                _playerAction.Jeter(PlayerAction.Membre.BrasDroit);
            else if (InputGetButtonLeftLeg())
                _playerAction.Jeter(PlayerAction.Membre.JambeGauche);
            else if (InputGetButtonRightLeg())
                _playerAction.Jeter(PlayerAction.Membre.JambeDroite);
        }
        #endregion

        if(_ennemy == null)
            return;

        #region AddMember
        if (InputGetButtonHead())
        {
            if (_monsterCollision)
            {
                _action = true;
                _playerAction.AddMember(PlayerAction.Membre.Tete, _ennemy.HeadPrefab);
                //NbOrgans++;
            }
        }
        else if (InputGetButtonLeftArm())
        {
            if (_monsterCollision)
            {
                _action = true;
                _playerAction.AddMember(PlayerAction.Membre.BrasGauche, _ennemy.ArmLeftPrefab);
                //NbOrgans++;
            }
        }
        else if (InputGetButtonRightArm())
        {
            if (_monsterCollision)
            {
                _action = true;
                _playerAction.AddMember(PlayerAction.Membre.BrasDroit, _ennemy.ArmRightPrefab);
                //NbOrgans++;
            }
        }
        else if (InputGetButtonLeftLeg())
        {
            if (_monsterCollision)
            {
                _action = true;
                _playerAction.AddMember(PlayerAction.Membre.JambeGauche, _ennemy.LegLeftPrefab);
                //NbOrgans++;
            }
        }
        else if (InputGetButtonRightLeg())
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
            onCollision.Invoke(false);
		}
        #endregion
    }
    #endregion

    #region Input
    bool InputGetButtonDown(bool headless)
    {
        String down = headless ? "Up" : "Down";
        return Input.GetButtonDown(down) || MobileInputGetDown();
    }

    bool InputGetButtonUp(bool headless)
    {
        String up = headless ? "Down" : "Up";
        return Input.GetButtonDown(up) || MobileInputGetUp();
    }

    float InputGetAxisVertical()
    {
        return Input.GetAxisRaw("Vertical");
    }

    bool InputGetButtonAction()
    {
        return Input.GetButtonDown("Action") || MobileInputGetAction();
    }

    bool InputGetButtonJump()
    {
        return Input.GetButtonDown("Jump");
    }

    bool InputGetButtonHead()
    {
        return Input.GetButtonDown("Head") || MobileInputGetHead();
    }

    bool InputGetButtonRightArm()
    {
        return Input.GetButtonDown("RightArm") || MobileInputGetRightArm();
    }

    bool InputGetButtonLeftArm()
    {
        return Input.GetButtonDown("LeftArm") || MobileInputGetLeftArm();
    }

    bool InputGetButtonRightLeg()
    {
        return Input.GetButtonDown("RightLeg") || MobileInputGetRightLeg();
    }

    bool InputGetButtonLeftLeg()
    {
        return Input.GetButtonDown("LeftLeg") || MobileInputGetLeftLeg();
    }
    #endregion

    #region Mobile Input
    bool MobileInputGetUp()
    {
        if (_mobileUp)
        {
            _mobileUp = false;
            return true;
        }
        return false;
    }

    bool MobileInputGetDown()
    {
        if (_mobileDown)
        {
            _mobileDown = false;
            return true;
        }
        return false;
    }

    bool MobileInputGetAction()
    {
        if (_mobileAction)
        {
            _mobileAction = false;
            return true;
        }
        return false;
    }

    bool MobileInputGetJump()
    {
        if (_mobileJump)
        {
            _mobileJump = false;
            return true;
        }
        return false;
    }
    #endregion

    #region API mobile organs input
    bool MobileInputGetHead()
    {
        if (_mobileHead)
        {
            _mobileHead = false;
            return true;
        }
        return false;
    }

    bool MobileInputGetRightArm()
    {
        if (_mobileRightArm)
        {
            _mobileRightArm = false;
            return true;
        }
        return false;
    }

    bool MobileInputGetLeftArm()
    {
        if (_mobileLeftArm)
        {
            _mobileLeftArm = false;
            return true;
        }
        return false;
    }

    bool MobileInputGetRightLeg()
    {
        if (_mobileRightLeg)
        {
            _mobileRightLeg = false;
            return true;
        }
        return false;
    }

    bool MobileInputGetLeftLeg()
    {
        if (_mobileLeftLeg)
        {
            _mobileLeftLeg = false;
            return true;
        }
        return false;
    }
    #endregion
}