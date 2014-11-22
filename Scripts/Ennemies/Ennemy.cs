using UnityEngine;
using System.Collections;

public abstract class Ennemy : MonoBehaviour {
//

    public bool IsHiddenScientist { get; protected set; }
	private float _speed;
	private ScrollingScript _scrollingScript;
	private GameObject HeadPrefab;
	private GameObject ArmPrefab;
	private GameObject LegPrefab;

	void Start () {

	}

	void Motion() {
	//move to left
		//move along the x axis
		_speed = Camera.main.GetComponent<GameManager> ().Speed;
		this.transform.Translate (Time.deltaTime * new Vector3 (- _speed, 0, 0));
		if (transform.position.x < -10)
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
