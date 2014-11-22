using AssemblyCSharp;
using UnityEngine;
using System.Collections;

public class PlayerAction : MonoBehaviour
{

    public GameObject Tete;
    public GameObject BrasDroit;
    public GameObject BrasGauche;
    public GameObject JambeDroite;
    public GameObject JambeGauche;

    public enum Membre
    {
        Tete,BrasDroit,BrasGauche,JambeGauche,JambeDroite
    }

    public void AddMember(Membre membre, GameObject prefab)
    {
        switch (membre)
        {
            case Membre.Tete:

                break;
            case Membre.BrasDroit:

                break;
            case Membre.BrasGauche:

                break;
            case Membre.JambeDroite:

                break;
            case Membre.JambeGauche:

                break;
        }
    }

    public void UseCompetence()
    {
        Bras bras;
    }

    public bool UseShield()
    {
        return false;
    }


    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
