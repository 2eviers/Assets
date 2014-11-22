using UnityEngine;
using System.Collections;

public abstract class Ennemy : MonoBehaviour {
//

    public bool IsHiddenScientist { get; protected set; }
	private float _speed;
	private ScrollingScript _scrollingScript;
    public GameObject HeadPrefab;
    public GameObject ArmRightPrefab;
    public GameObject ArmLeftPrefab;
    public GameObject LegRightPrefab;
    public GameObject LegLeftPrefab;

	void Start () {
        transform.Translate(0,gameObject.GetComponent<SpriteRenderer>().bounds.size.y/2,0);
	}

	void Motion() {
	//move to left
		//move along the x axis
		_speed = Camera.main.GetComponent<GameManager> ().Speed;
		this.transform.Translate (Time.deltaTime * new Vector3 (- _speed, 0, 0));
		if (transform.position.x > 9f 
		    	&& transform.position.x < 10f 
		    	&& this.gameObject.audio != null) 
			this.gameObject.audio.Play ();
        if (transform.position.x < -Camera.main.orthographicSize * Camera.main.aspect - 2)
			Die ();
	}

	void Die() {
	//when player successfully steals an organ or ennemy gets out of the screen
		//death animation
	//	animation.Play ("die");
		Destroy (this.gameObject);
	}

	// Update is called once per frame
	void Update () {
		Motion ();
	}
}
