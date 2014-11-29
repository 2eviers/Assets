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
        gameObject.GetComponent<Text>().text = _gameMngr.scoreManager.PointToString() + " : Score\n" + Mathf.Round(_gameMngr.scoreManager.globalMultiplicateur())+ " : Multiplicateur";
	}
}
