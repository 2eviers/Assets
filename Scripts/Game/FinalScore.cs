using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        Score scoreManager = Camera.main.GetComponent<GameManager>().scoreManager;
        var time = Math.Round(Time.timeSinceLevelLoad, 2);
        GetComponent<Text>().text = 
            "Temps : " + time.ToString() + 
            "\nOrganes transplantés : " + scoreManager.GetMembres().Count + 
            "\nScore Final : " + scoreManager.PointToString();
	}
}