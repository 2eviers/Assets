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
        Debug.Log(_delay);
        StartAudio();
	    Decrement();
        if (_delay == 0)
        {
            Time.timeScale = 1;
            Destroy(gameObject);
        }
            
	}
}
