using System.Collections.Generic;
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

    private GameObject RandomPrefab()
    {
		int r = Random.Range (0, 126);
		if (r < 10)
			return DragonPrefab;
		else if (r < 40)
			return PouletPrefab;
		else if (r < 60)
			return PoulpePrefab;
		else if (r < 80)
			return RobotPrefab;
		else if (r < 90)
			return AlienPrefab;
		else if (r < 100)
		    return PoubellePrefab;
		else if (r < 105)
		    return ScDragonPrefab;
		else if (r < 110)
		    return ScPoulpePrefab;
		else if (r < 115)
		    return ScPouletPrefab;
		else if (r < 120)
		    return ScRobotPrefab;
		else
		    return ScAlienPrefab;
    }

	GameObject Spawn() {
	//randomly spawns an ennemy
		GameObject _ennemy;
		GameObject _prefab;
	    _prefab = RandomPrefab();
//*/
	
		_ennemy = (GameObject) Instantiate (_prefab);
	    if (_prefab == PoubellePrefab)
	    {
            do _prefab = RandomPrefab(); 
            while (_prefab == PoubellePrefab);
	        _ennemy.GetComponent<Ennemy>().HeadPrefab = _prefab.GetComponent<Ennemy>().HeadPrefab;
            do _prefab = RandomPrefab(); 
            while (_prefab == PoubellePrefab);
	        _ennemy.GetComponent<Ennemy>().ArmLeftPrefab = _prefab.GetComponent<Ennemy>().ArmLeftPrefab;
            do _prefab = RandomPrefab(); 
            while (_prefab == PoubellePrefab);
	        _ennemy.GetComponent<Ennemy>().ArmRightPrefab = _prefab.GetComponent<Ennemy>().ArmRightPrefab;
            do _prefab = RandomPrefab(); 
            while (_prefab == PoubellePrefab);
	        _ennemy.GetComponent<Ennemy>().LegLeftPrefab = _prefab.GetComponent<Ennemy>().LegLeftPrefab;
            do _prefab = RandomPrefab(); 
            while (_prefab == PoubellePrefab);
	        _ennemy.GetComponent<Ennemy>().LegRightPrefab = _prefab.GetComponent<Ennemy>().LegRightPrefab;
        }



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
