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

    public float Position1;
    private float _pos1;
    public float Position2;
    private float _pos2;

    public enum Membre
    {
        Tete,BrasDroit,BrasGauche,JambeGauche,JambeDroite
    }

    public void AddMember(Membre membre, GameObject prefab)
    {
        Debug.Log(membre);
        switch (membre)
        {
            case Membre.Tete:

                break;
            case Membre.BrasDroit:
                BrasDroit = prefab;
                break;

            case Membre.BrasGauche:
                BrasGauche = prefab;
                break;
            case Membre.JambeDroite:

                break;
            case Membre.JambeGauche:

                break;
        }
    }
    /**
     * Il faut qu'il existe au moins un membre sur le gameObject sinon boucle
     */
    public void Arracher()
    {
        killRandomMember();
        recul();
    }

    private void killRandomMember()
    {

        GameObject membre = null;

        while (membre == null)
        {
            switch (Random.Range(0, 4))
            {
                case 0:
                    membre = Tete;
                    break;
                case 1:
                    membre = BrasDroit;
                    break;
                case 2:
                    membre = BrasGauche;
                    break;
                case 3:
                    membre = JambeDroite;
                    break;
                case 4:
                    membre = JambeGauche;
                    break;
            }
        }

        membre.GetComponent<AssemblyCSharp.Membre>().Detruire();
    }


    private void recul()
    {
        
    }

    public bool IsDead()
    {
        return (JambeDroite == null && JambeGauche == null);
    }

    public void UseCompetence()
    {
        Tete.GetComponent<Tete>().UseCompetence();
    }

    public bool UseShield()
    {
        GameObject bras = null;

        if (BrasDroit == null)
        {
            bras = BrasGauche;
            if(bras == null) return false;
        }
        else if (BrasGauche == null) return false;
        else
            bras = (BrasDroit.GetComponent<AssemblyCSharp.Membre>().Rejet <
                    BrasGauche.GetComponent<AssemblyCSharp.Membre>().Rejet)
                ? BrasDroit
                : BrasGauche;

        return bras.GetComponent<Bras>().UseShield(); 
    }


    // Use this for initialization
	void Start ()
	{
        _pos1 = -Position1 * Camera.main.aspect * Camera.main.orthographicSize;
        _pos2 = -Position2 * Camera.main.aspect * Camera.main.orthographicSize;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
