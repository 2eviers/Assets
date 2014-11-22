using System;
using AssemblyCSharp;
using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
	    _playerMotion = GetComponent<PlayerMotion>();
        _tete = GetComponent<Tete>();
        _jambeGauche = GetComponent<Jambe>();
        _jambeDroite = GetComponent<Jambe>();
        _brasDroit = GetComponent<Bras>();
        _brasGauche = GetComponent<Bras>();
	}

    private PlayerMotion _playerMotion;
    private Tete _tete;
    private Jambe _jambeGauche;
    private Jambe _jambeDroite;
    private Bras _brasDroit;
    private Bras _brasGauche;
	
    void Controller()
    {
        if (Input.GetButtonDown("Up"))
        {
            throw new Exception("not implemented");
        }
        if (Input.GetButtonDown("Down")) { throw new Exception("not implemented"); }
        if (Input.GetButtonDown("Action")) { throw new Exception("not implemented"); }
        if (Input.GetButtonDown("Jump")) { throw new Exception("not implemented"); }
        if (Input.GetButtonDown("Head")) { throw new Exception("not implemented");}
        if (Input.GetButtonDown("LeftArm")) { throw new Exception("not implemented"); }
        if (Input.GetButtonDown("RightArm")) { throw new Exception("not implemented"); }
        if (Input.GetButtonDown("LeftLeg")) { throw new Exception("not implemented"); }
        if (Input.GetButtonDown("RightLeg")) { throw new Exception("not implemented"); }
            
    }

	// Update is called once per frame
	void Update () {
	    Controller();
	}
}
