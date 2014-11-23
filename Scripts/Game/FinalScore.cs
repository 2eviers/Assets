using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        var time = Math.Round(Time.time, 2);
        GetComponent<Text>().text = "Temps : " + time.ToString() + "\n " + "Organes transplantés : " + Camera.main.GetComponent<GameManager>().NbOrgans.ToString();
	}
}
