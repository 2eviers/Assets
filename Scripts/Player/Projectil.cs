using UnityEngine;
using System.Collections;

public class Projectil : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    public int Speed = 5;

    void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<Ennemy>().Die();
    }

	// Update is called once per frame
	void Update () {
	    transform.Translate(Speed*Time.deltaTime,0,0);
	}
}
