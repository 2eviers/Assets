using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    public void Begin()
    {
        Destroy(gameObject);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Return()
    {
        Application.LoadLevel(0);
    } 
	// Update is called once per frame
	void Update () {
	
	}
}
