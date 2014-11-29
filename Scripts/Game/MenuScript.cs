using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {

	// Use this for initialization
    void Start()
    {
        _delay = 0;
        _activeDelay = false;
        _image = GetComponentsInChildren<Image>();
        _it = _image.GetEnumerator();

        _it.MoveNext();
        _it.MoveNext();
        _it.MoveNext();
        _it.MoveNext();
        //*/
    }

    private float _delay;

    private float fixedTime;
    private bool _activeDelay;
    private Image[] _image;
    private IEnumerator _it;
    [SerializeField] private GameObject _score;

    void Decrement()
    {
        if (_delay <= 10 && _activeDelay)
        {
            fixedTime = Time.fixedDeltaTime * 0.85f;
            _delay += fixedTime;
        }
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
        /*
        Debug.Log(_delay - 7f);
        Debug.Log(Time.fixedDeltaTime);
        Debug.Log(Mathf.Abs(_delay - 7f) <= Time.fixedDeltaTime && _activeDelay);
        //*/


        if (Mathf.Abs(_delay - 0.02f) <= fixedTime/2f && _activeDelay)
        {
            Debug.Log("Image 1");
            (_it.Current as Image).enabled = false;
            _it.MoveNext();
            var image = _it.Current as Image;
            image.enabled = true;
        }
        if (Mathf.Abs(_delay - 2.175f) <= fixedTime/2f)
        {
            Debug.Log("Image 2");
            (_it.Current as Image).enabled = false;
            _it.MoveNext();
            var image = _it.Current as Image;
            image.enabled = true;
        }

        if (Mathf.Abs(_delay - 3f) < fixedTime/2f)
        {
            Debug.Log("Image 3");
            (_it.Current as Image).enabled = false;
            _it.MoveNext();
            var image = _it.Current as Image;
            image.enabled = true;
        }

        if (Mathf.Abs(_delay - 4.360f) < fixedTime/2f) //140
        {
            Debug.Log("Image 4");
            (_it.Current as Image).enabled = false;
            _it.MoveNext();
            var image = _it.Current as Image;
            image.enabled = true;
        }

        if (Mathf.Abs(_delay - 4.9f) < fixedTime/2f) //107
        {
            Debug.Log("Image 5");
            (_it.Current as Image).enabled = false;
            _it.MoveNext();
            var image = _it.Current as Image;
            image.enabled = true;
        }

        if (Mathf.Abs(_delay - 5.45f) < fixedTime/2f) //75
        {
            Debug.Log("Image 6");
            (_it.Current as Image).enabled = false;
            _it.MoveNext();
            var image = _it.Current as Image;
            image.enabled = true;
        }

        if (Mathf.Abs(_delay - 6f) < fixedTime/2f) //37
        {
            Debug.Log("Image 7");
            (_it.Current as Image).enabled = false;
            _it.MoveNext();
            var image = _it.Current as Image;
            image.enabled = true;
        }
            
        StartAudio();
	    Decrement();
        if (_delay > 6.54f || (Input.GetKeyDown(KeyCode.Escape) && _activeDelay))
        {
            //gameManager.enabled = true ???
            Time.timeScale = 1;
            Destroy(gameObject);
            Instantiate(_score);
            Camera.main.GetComponent<GameManager>().Player.GetComponent<InputController>().enabled = true;
        }
            
	}
}
