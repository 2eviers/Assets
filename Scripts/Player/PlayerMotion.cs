using System.Reflection;
using UnityEngine;
using System.Collections;

public class PlayerMotion : MonoBehaviour
{


    public float Speed;
    private Vector3? _target;

	// Use this for initialization
	void Start () {
	
	}

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
        
    }

    public void MoveDown()
    {
        
    }

    public void Jump()
    {
        
    }

	// Update is called once per frame
	void Update () {
	    move();
	}
}
