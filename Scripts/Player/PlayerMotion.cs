using System.Reflection;
using UnityEngine;
using System.Collections;
using System;

public class PlayerMotion : MonoBehaviour
{


    public float Speed;
    [NonSerialized]
    public Vector3? Target;
    private Vector3 _line1;
    private Vector3 _line2;
    private Vector3 _line3;
	public bool IsJumping;


    private void move()
    {
        if (Target == null) return;

        var target = (Vector3) Target;


        Vector3 dirTarget = target - gameObject.transform.position;
        float distanceTarget = Vector3.Magnitude(dirTarget);

        float pas = Speed*Time.deltaTime;

        if (distanceTarget < pas)
        {
            gameObject.transform.position = target;
            Target = null;
            return;
        }


        gameObject.transform.Translate(dirTarget.normalized * pas);

        gameObject.GetComponent<PlayerAction>().IsLava();
    }

    public void MoveUp()
    {

        Vector3 target = (Target != null) ? (Vector3) Target : gameObject.transform.position;

        var deplacement = (_line2.z > target.z) ? 
            new Vector3(0, _line2.y, _line2.z) : 
            new Vector3(0, _line1.y, _line1.z);

        Target = new Vector3(target.x, deplacement.y, deplacement.z);

    }

    public void MoveDown()
    {
        Vector3 target = (Target != null) ? (Vector3)Target : gameObject.transform.position;


        var deplacement = (_line2.z < target.z) ?
            new Vector3(0, _line2.y, _line2.z) :
            new Vector3(0, _line3.y, _line3.z);

        Target = new Vector3(target.x, deplacement.y,deplacement.z);
    }

    IEnumerator J()
    {
		IsJumping = true;
		Vector3 PlayerPosition = this.gameObject.transform.position;
		Target = new Vector3 (PlayerPosition.x, PlayerPosition.y+2, PlayerPosition.z);
		yield return new WaitForSeconds (0.25f);
		bool CanFly = false;
		float duration = 0;
		//si on a deux ailes de poulet on plane plus longtemps
		try {
			BrasPoulet aile = this.gameObject.GetComponent<PlayerAction>().BrasDroit.GetComponent<BrasPoulet>();
			BrasPoulet aile2 = this.gameObject.GetComponent<PlayerAction>().BrasGauche.GetComponent<BrasPoulet>();
			CanFly = true;
			duration = aile.FlightDuration;
			duration = aile2.FlightDuration;
		}
		catch (NullReferenceException) {  
			CanFly = false;
		}
		catch (MissingReferenceException) {
			CanFly = false;
		}
		if (CanFly)
			yield return new WaitForSeconds(duration);
		Target = new Vector3(PlayerPosition.x, PlayerPosition.y, PlayerPosition.z);
		yield return new WaitForSeconds (0.25f);
		IsJumping = false;
    }

	public void Jump() 
	{
		StartCoroutine (J ());
	}

    // Use this for initialization
    void Start()
    {

    }

	// Update is called once per frame
	void Update () {

        _line1 = Camera.main.GetComponent<GameManager>()._spawn1;
        _line2 = Camera.main.GetComponent<GameManager>()._spawn2;
        _line3 = Camera.main.GetComponent<GameManager>()._spawn3;

        _line1.x = gameObject.transform.position.x;
        _line2.x = _line1.x;
        _line3.x = _line1.x;

	    move();
	}
}
