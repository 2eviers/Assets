using System.Reflection;
using UnityEngine;
using System.Collections;
using System;

public class PlayerMotion : MonoBehaviour
{


    public float Speed;
    private Vector3? _target;
    private Vector3 _line1;
    private Vector3 _line2;
    private Vector3 _line3;


    private void move()
    {
        if (_target == null) return;

        var target = (Vector3) _target;


        Vector3 dirTarget = target - gameObject.transform.position;
        float distanceTarget = Vector3.Magnitude(dirTarget);

        float pas = Speed*Time.deltaTime;

        if (distanceTarget < pas)
        {
            gameObject.transform.position = target;
            _target = null;
            return;
        }

        gameObject.transform.Translate(dirTarget.normalized * pas);
    }

    public void MoveUp()
    {

        Vector3 target = (_target != null) ? (Vector3) _target : gameObject.transform.position;

        _target = (_line2.z > target.z) ? _line2 : _line1;

    }

    public void MoveDown()
    {
        Vector3 target = (_target != null) ? (Vector3)_target : gameObject.transform.position;

        _target = (_line2.z < target.z) ? _line2 : _line3;
    }

    IEnumerator J()
    {
		Vector3 PlayerPosition = this.gameObject.transform.position;
		_target = new Vector3 (PlayerPosition.x, PlayerPosition.y+2, PlayerPosition.z);
		yield return new WaitForSeconds (0.25f);
		bool CanFly = false;
		float duration = 0;
		//si on a deux ailes de poulet on plane plus longtemps
		try {
			Aile aile = this.gameObject.GetComponent<PlayerAction>().BrasDroit.GetComponent<Aile>();
			Aile aile2 = this.gameObject.GetComponent<PlayerAction>().BrasGauche.GetComponent<Aile>();
			CanFly = true;
			duration = aile.FlightDuration;
			duration = aile2.FlightDuration;
		}
		catch (NullReferenceException e) {
			String b = e.Message;
			CanFly = false;
		}
		CanFly = true;
		if (CanFly)
			yield return new WaitForSeconds(duration);
		_target = new Vector3(PlayerPosition.x, PlayerPosition.y, PlayerPosition.z);
		yield return new WaitForSeconds (0.25f);
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
