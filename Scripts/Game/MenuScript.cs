using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        _delay = 400;
	    _activeDelay = false;
	}

    private int _delay;
    private bool _activeDelay;

    void Decrement()
    {
        if(_delay >= 0 && _activeDelay)
            _delay--;
    }

    void StartAudio()
    {
        if (_activeDelay)
            Camera.main.audio.enabled = true;
    }

    public void Begin()
    {
        _activeDelay = true;
        
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
        if(_delay == 270)
            Debug.Log("1");
        if (_delay == 220)
            Debug.Log("2");
        if (_delay == 140)
            Debug.Log("3");
        if (_delay == 107)
            Debug.Log("4");
        if (_delay == 75)
            Debug.Log("5");
        if (_delay == 37)
            Debug.Log("6");
        StartAudio();
	    Decrement();
        if (_delay == 0)
        {
            Time.timeScale = 1;
            Destroy(gameObject);
        }
            
	}
}
