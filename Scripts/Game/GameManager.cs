﻿using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    /**
     * condition de mort
     * figer l'écran
     * afficher le temps
     * afficher le nb de membres volés
     * menus
     * */

	// Use this for initialization
	void Start ()
	{
	    _spawnX = Camera.main.orthographicSize*Camera.main.aspect + 2;
        _spawn1 = new Vector3(_spawnX, 0, -1);
        _spawn2 = new Vector3(_spawnX, -1.5f, -2);
        _spawn3 = new Vector3(_spawnX, -3, -3);
		Speed = 10;
	    //_playerAction = _player.GetComponent<PlayerAction>();
	}

    [SerializeField] private GameObject _player;
    private PlayerAction _playerAction;

    //void Loose()
    //{
    //    if(_playerAction.IsDead())
    //        Time.timeScale = 0;
    //}

    private float _spawnX;
    public Vector3 _spawn1 { get; set; }
    public Vector3 _spawn2 { get; set; }
    public Vector3 _spawn3 { get; set; }
	public int Speed;

	// Update is called once per frame
	void Update () {
	    //Loose();
	}
}
