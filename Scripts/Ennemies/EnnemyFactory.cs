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
    private Vector3 _spawn;
    private GameManager _gameManager;
	private ArrayList Probabilities;
	public GameObject PoulpePrefab;
	public GameObject PouletPrefab;

	void Start() {
	// 	Probabilities.Add ();
	    _gameManager = GetComponent<GameManager>();
	}

	GameObject Spawn() {
	//randomly spawns an ennemy
		int r = Random.Range (0, 100);
		Debug.Log (r);
		GameObject _ennemy;
		GameObject _prefab;
		if (r < 10)
			_prefab = PoulpePrefab;
		else
			_prefab = PouletPrefab; 

		_ennemy = (GameObject) Instantiate (_prefab); 
		//randomly determines in which plane the ennemy'll be placed
		int p = (int)Random.Range (0, 3);
        if (p == 0)
            _spawn = _gameManager._spawn1;
        if (p == 1)
            _spawn = _gameManager._spawn2;
        if (p == 2)
            _spawn = _gameManager._spawn3;

	    _ennemy.transform.position = _spawn;

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
