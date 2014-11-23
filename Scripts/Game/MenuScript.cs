using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {

	// Use this for initialization
    void Start()
    {
        _delay = 400;
        _activeDelay = false;
        _image = GetComponentsInChildren<Image>();
        _it = _image.GetEnumerator();
        _it.MoveNext();
        _it.MoveNext();
        _it.MoveNext();
    }

    private int _delay;
    private bool _activeDelay;
    private Image[] _image;
    private IEnumerator _it;
    [SerializeField] private Canvas _score;

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
        if (_delay == 400 && _activeDelay)
        {
            _it.MoveNext();
            var image = _it.Current as Image;
            image.enabled = true;
        }
        if (_delay == 270)
        {
            _it.MoveNext();
            var image = _it.Current as Image;
            image.enabled = true;
        }

        if (_delay == 220)
        {
            _it.MoveNext();
            var image = _it.Current as Image;
            image.enabled = true;
        }
            
        if (_delay == 137) //140
        {
            _it.MoveNext();
            var image = _it.Current as Image;
            image.enabled = true;
        }

        if (_delay == 107) //107
        {
            _it.MoveNext();
            var image = _it.Current as Image;
            image.enabled = true;
        }

        if (_delay == 72) //75
        {
            _it.MoveNext();
            var image = _it.Current as Image;
            image.enabled = true;
        }

        if (_delay == 34) //37
        {
            _it.MoveNext();
            var image = _it.Current as Image;
            image.enabled = true;
        }
            
        StartAudio();
	    Decrement();
        if (_delay == 0)
        {
            Time.timeScale = 1;
            Destroy(gameObject);
            Instantiate(_score);
        }
            
	}
}
