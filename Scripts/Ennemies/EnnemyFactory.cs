﻿using UnityEngine;
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
	public float SpawnX = 10;
	public float SpawnZ = -1;
	public GameObject PoulpePrefab;
	public GameObject PouletPrefab;
	public GameObject DragonPrefab;
	private int CurrentTime;
	private Vector3 _spawn;
	private GameManager _gameManager;
	private ScrollingScript _scrollingScript;

	void Start() {
		_gameManager = GetComponent<GameManager> ();
	}

	GameObject Spawn() {
	//randomly spawns an ennemy
		int r = Random.Range (0, 100);
		GameObject _ennemy;
		GameObject _prefab;
		if (r < 10)
			_prefab = DragonPrefab;
		else if (r < 40)
			_prefab = PouletPrefab;
		else
			_prefab = PoulpePrefab;

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