using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour
{

    private GameManager _gameMngr;

    void Start()
    {
        _gameMngr = Camera.main.GetComponent<GameManager>();
    }
	// Update is called once per frame
	void Update ()
	{
        gameObject.GetComponent<Text>().text = "Score : " + _gameMngr.scoreManager.PointToString() + "\nMultiplicateur : " + Mathf.Round(_gameMngr.scoreManager.globalMultiplicateur());
	}
}
