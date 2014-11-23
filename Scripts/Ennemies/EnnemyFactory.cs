using UnityEngine;
using System.Collections;

public class EnnemyFactory : MonoBehaviour {
//
	public float SpawnSpeed;
	public float SpawnX = 10;
	public float SpawnZ = -1;
	public GameObject PoulpePrefab;
	public GameObject PouletPrefab;
	public GameObject DragonPrefab;
	public GameObject RobotPrefab;
	public GameObject AlienPrefab;
	public GameObject PoubellePrefab;
	public GameObject ScDragonPrefab;
	public GameObject ScPoulpePrefab;
	public GameObject ScPouletPrefab;
	public GameObject ScRobotPrefab;
	public GameObject ScAlienPrefab;
	private int CurrentTime;
	private Vector3 _spawn;
	private GameManager _gameManager;
	private ScrollingScript _scrollingScript;

	void Start() {
		_gameManager = GetComponent<GameManager> ();
	}

	GameObject Spawn() {
	//randomly spawns an ennemy
		int r = Random.Range (0, 126);
		GameObject _ennemy;
		GameObject _prefab;
		if (r < 10)
			_prefab = DragonPrefab;
		else if (r < 40)
			_prefab = PouletPrefab;
		else if (r < 60)
			_prefab = PoulpePrefab;
		else if (r < 80)
			_prefab = RobotPrefab;
		else //if (r < 90)
			_prefab = AlienPrefab;
/*		else if (r < 100)
			_prefab = PoubellePrefab;
		else if (r < 105)
			_prefab = ScDragonPrefab;
		else if (r < 110)
			_prefab = ScPoulpePrefab;
		else if (r < 115)
			_prefab = ScPouletPrefab;
		else if (r < 120)
			_prefab = ScRobotPrefab;
		else 
			_prefab = ScAlienPrefab;
//*/
	
		_ennemy = (GameObject) Instantiate (_prefab); 
		//randomly determines in which plane the ennemy'll be placed
		int p = (int)Random.Range (0, 3);
		//all ennemies start at the same (x,z) coordinates but not in the same plane
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
