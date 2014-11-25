using AssemblyCSharp;
using UnityEngine;
using System.Collections;
using System;

public class PlayerAction : MonoBehaviour
{

    public GameObject Tete;
    public GameObject BrasDroit;
    public GameObject BrasGauche;
    public GameObject JambeDroite;
    public GameObject JambeGauche;

    public GameObject TeteContain;
    public GameObject BrasDroitContain;
    public GameObject BrasGaucheContain;
    public GameObject JambeDroiteContain;
    public GameObject JambeGaucheContain;

    public float Position1;
    private float _pos1;
    public float Position2;
    private float _pos2;
    public float Position3;
    private float _pos3;

    [SerializeField] private AudioClip _arracher;
    [SerializeField] private AudioClip _addmembre;

    public enum Membre
    {
        Tete,BrasDroit,BrasGauche,JambeGauche,JambeDroite
    }

    public void AddMember(Membre membre, GameObject prefab)
    {
        switch (membre)
        {
            case Membre.Tete:
                if(Tete != null) Tete.GetComponent<AssemblyCSharp.Membre>().Detruire();
                Tete = (GameObject) Instantiate(prefab);
                Tete.transform.parent = TeteContain.transform;
                Tete.transform.localPosition = Vector3.zero;
                Tete.transform.localScale = new Vector3(1, 1, 1);
                Tete.GetComponent<AssemblyCSharp.Membre>().Player = gameObject;
                break;
            case Membre.BrasDroit:
                if (BrasDroit != null) BrasDroit.GetComponent<AssemblyCSharp.Membre>().Detruire();
                BrasDroit = (GameObject) Instantiate(prefab);
                BrasDroit.transform.parent = BrasDroitContain.transform;
                BrasDroit.transform.localPosition = Vector3.zero;
                BrasDroit.transform.localScale = new Vector3(1, 1, 1);
                BrasDroit.GetComponent<AssemblyCSharp.Membre>().Player = gameObject;
                break;

            case Membre.BrasGauche:
                if (BrasGauche != null) BrasGauche.GetComponent<AssemblyCSharp.Membre>().Detruire();
                BrasGauche = (GameObject)Instantiate(prefab);
                BrasGauche.transform.parent = BrasGaucheContain.transform;
                BrasGauche.transform.localPosition = Vector3.zero;
                BrasGauche.transform.localScale = new Vector3(1, 1, 1);
                BrasGauche.GetComponent<AssemblyCSharp.Membre>().Player = gameObject;
                break;
            case Membre.JambeDroite:
                if (JambeDroite != null) JambeDroite.GetComponent<AssemblyCSharp.Membre>().Detruire();
                JambeDroite = (GameObject) Instantiate(prefab);
                JambeDroite.transform.parent = JambeDroiteContain.transform;
                JambeDroite.transform.localPosition = Vector3.zero;
                JambeDroite.transform.localScale = new Vector3(1, 1, 1);
                JambeDroite.GetComponent<AssemblyCSharp.Membre>().Player = gameObject;
                break;
            case Membre.JambeGauche:
                if (JambeGauche != null) JambeGauche.GetComponent<AssemblyCSharp.Membre>().Detruire();
                JambeGauche = (GameObject) Instantiate(prefab);
                JambeGauche.transform.parent = JambeGaucheContain.transform;
                JambeGauche.transform.localPosition = Vector3.zero;
                JambeGauche.transform.localScale = new Vector3(1, 1, 1);
                JambeGauche.GetComponent<AssemblyCSharp.Membre>().Player = gameObject;
                break;
        }
        GetComponent<AudioSource>().clip = _addmembre;
        GetComponent<AudioSource>().Play();
    }

    public bool IsDead()
    {
        return (JambeDroite == null && JambeGauche == null);
    }

	public bool Headless() 
	{
		return (Tete == null);
	}

    public void IsLava()
    {
        Vector3 position = gameObject.transform.position;
        
        float pas = gameObject.GetComponent<PlayerMotion>().Speed*Time.deltaTime;


        if (Mathf.Abs(_pos3 - position.x) <= pas)
        {

            killRandomMember();
            avance();
        }
    }

    /**
     * Il faut qu'il existe au moins un membre sur le gameObject sinon boucle
     */
    public void Arracher()
    {
		killRandomMember();
		Recul();
        GetComponent<AudioSource>().clip = _arracher;
        GetComponent<AudioSource>().Play();
    }

    private void killRandomMember()
    {

        GameObject membre = null;

        while (membre == null && 
		       !(Tete == null && BrasDroit == null && BrasGauche == null 
		  		&& JambeDroite == null && JambeGauche == null))
        {
            switch (UnityEngine.Random.Range(0, 5))
            {
                case 0:
                    membre = Tete;
                    Tete = null;
                    break;
                case 1:
                    membre = BrasDroit;
                    BrasDroit = null;
                    break;
                case 2:
                    membre = BrasGauche;
                    BrasGauche = null;
                    break;
                case 3:
                    membre = JambeDroite;
                    JambeDroite = null;
                    break;
                case 4:
                    membre = JambeGauche;
                    JambeGauche = null;
                    break;
            }
        }
		if (membre != null)
        	membre.GetComponent<AssemblyCSharp.Membre>().Detruire();
    }


    public void avance()
    {
        var motion = gameObject.GetComponent<PlayerMotion>();
        var position = gameObject.transform.position;
        motion.Target = position + new Vector3(_pos1 - position.x, 0, 0);
    }

    public void Recul()
    {
        var motion = gameObject.GetComponent<PlayerMotion>();
        var target = motion.Target;
        var position = gameObject.transform.position;
        if (target != null)
        {
            position = (Vector3) target;
        }


        if (position.x > _pos2)
        {
            motion.Target = position + new Vector3(_pos2-position.x, 0, 0);
            return;
        }

        motion.Target = position + new Vector3(_pos3-position.x, 0, 0);
    }

    
    public void UseCompetence()
    {
        Tete.GetComponent<Tete>().UseCompetence();
    }

    public bool UseShield()
    {
        if (BrasDroit == null)
        {
            if (BrasGauche == null)
                return false;
            return BrasGauche.GetComponent<Bras>().UseShield();
        }
        if(BrasGauche == null)
                return BrasDroit.GetComponent<Bras>().UseShield();

        var bras1 = BrasDroit.GetComponent<Bras>();
        var bras2 = BrasGauche.GetComponent<Bras>();

        if (bras1.CurrentRejet < bras2.CurrentRejet)
            return bras1.UseShield() || bras2.UseShield();
        else
            return bras2.UseShield() || bras1.UseShield();
    }

    public void Jeter(Membre membre)
    {
        Debug.Log("Jeter");
        switch (membre)
        {
                case Membre.Tete:
                if (Tete != null)
                {
                    Tete.GetComponent<AssemblyCSharp.Membre>().Jeter();
                    Tete = null;
                    avance();
                }
                break;

                case  Membre.BrasGauche:
                if (BrasGauche != null)
                {
                    BrasGauche.GetComponent<AssemblyCSharp.Membre>().Jeter();
                    BrasGauche = null;
                    avance();
                }
                break;

                case Membre.BrasDroit:
                if (BrasDroit != null)
                {
                    BrasDroit.GetComponent<AssemblyCSharp.Membre>().Jeter();
                    BrasDroit = null;
                    avance();
                }
                break;

                case Membre.JambeGauche:
                if (JambeGauche != null)
                {
                    JambeGauche.GetComponent<AssemblyCSharp.Membre>().Jeter();
                    JambeGauche = null;
                    avance();
                }
                break;

                case Membre.JambeDroite:
                if (JambeDroite != null)
                {
                    JambeDroite.GetComponent<AssemblyCSharp.Membre>().Jeter();
                    JambeDroite = null;
                    avance();
                }
                break;
        }
    }

    // Use this for initialization
	void Start ()
	{
        _pos1 = -Position1 * Camera.main.aspect * Camera.main.orthographicSize;
        _pos2 = -Position2 * Camera.main.aspect * Camera.main.orthographicSize;
        _pos3 = -Position3 * Camera.main.aspect * Camera.main.orthographicSize;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
