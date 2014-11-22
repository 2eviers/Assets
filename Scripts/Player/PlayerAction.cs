using AssemblyCSharp;
using UnityEngine;
using System.Collections;

public class PlayerAction : MonoBehaviour
{

    public GameManager Tete;
    public GameManager BrasDroit;
    public GameManager BrasGauche;
    public GameManager JambeDroite;
    public GameManager JambeGauche;

    public enum Membre
    {
        Tete,BrasDroit,BrasGauche,JambeGauche,JambeDroite
    }

    public void AddMember(Membre membre, GameManager prefab)
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
