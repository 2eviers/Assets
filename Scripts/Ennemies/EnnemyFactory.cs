using UnityEngine;
using System.Collections;

public class EnnemyFactory : MonoBehaviour {
//
	public float DragonProbability = 0.1f;
	public float ChickenProbability = 0.3f;
	public float AlienProbability = 0.1f;
	public float OctopusProbability = 0.2f;
	public float RobotProbability = 0.2f;
	public float TrashProbability = 0.1f;
	public float SpawnSpeed;
	private int CurrentTime;
	public float SpawnX = 10;
	public float SpawnZ = -1;
	private ArrayList Probabilities;
	public GameObject PoulpePrefab;

	void Start() {
	// 	Probabilities.Add ();
	}

	GameObject Spawn() {
	//randomly spawns an ennemy
		//GameObject Ennemy = (GameObject) Instantiate (Resources.Load("Poulpe"));
		GameObject _ennemy = (GameObject) Instantiate (PoulpePrefab);
		//randomly determines in which plane the ennemy'll be placed
		int p = (int)Random.Range (0, 3);
		float Plane = (float) (- 1.5 * p);
		//all ennemies start at the same (x,z) coordinates but not in the same plane
		Vector3 Position = new Vector3 (SpawnX, Plane, SpawnZ);
		_ennemy.transform.position = Position;
//		_ennemy.GetComponent<Ennemy>().Plane = Plane;

		return _ennemy;
	}

	void Update() {
		if ((int)Time.time != this.CurrentTime) {
			this.CurrentTime = (int)Time.time;
			if ((int) (SpawnSpeed * this.CurrentTime) % 60 == 0)
				this.Spawn();
		}
	}
	
	
}
