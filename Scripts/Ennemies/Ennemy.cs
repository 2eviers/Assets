using UnityEngine;
using System.Collections;

public abstract class Ennemy : MonoBehaviour {
//

	public float Speed;
	public float Plane;
	protected bool _isHiddenScientist;
	private GameObject HeadPrefab;
	private GameObject ArmPrefab;
	private GameObject LegPrefab;

	void Start () {
	
	}

	void Motion() {
	//move to left
		//move along the x axis
		this.transform.Translate (Time.deltaTime * new Vector3 (- this.Speed, 0, 0));
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
