using System.Runtime.InteropServices;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour 
{    
    #region Properties
    [SerializeField] 
    private GameObject _scorePrefab;
    #endregion

    #region API
    public void Begin()
    {
        _gameStarted = true;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Return()
    {
        Application.LoadLevel(0);
    }
    #endregion

    #region Unity
    void Start()
    {
        _timeElapsed = 0;
        _gameStarted = false;
        _image = GetComponentsInChildren<Image>();
        _it = _image.GetEnumerator();

        _it.MoveNext();
        _it.MoveNext();
        _it.MoveNext();
        _it.MoveNext();
    }

    void Update () 
    {
        ShowIntro();        
        StartAudio();
	    Decrement();

        if (_timeElapsed > 6.54f || (Input.GetButtonDown("Cancel") || Input.GetButtonDown("Submit")) && _gameStarted)
        {
            StartGame();
        }

        if (!_gameStarted)
        {
            GetInput();
        }
	}
    #endregion

    #region Private
    private float _timeElapsed;
    private float fixedTime;
    private bool _gameStarted;
    private Image[] _image;
    private IEnumerator _it;

    void ShowIntro()
    {
        if (Mathf.Abs(_timeElapsed - 0.02f) <= fixedTime / 2f && _gameStarted)
        {
            Debug.Log("Image 1");
            (_it.Current as Image).enabled = false;
            _it.MoveNext();
            var image = _it.Current as Image;
            image.enabled = true;
        }
        if (Mathf.Abs(_timeElapsed - 2.175f) <= fixedTime / 2f)
        {
            Debug.Log("Image 2");
            (_it.Current as Image).enabled = false;
            _it.MoveNext();
            var image = _it.Current as Image;
            image.enabled = true;
        }

        if (Mathf.Abs(_timeElapsed - 3f) < fixedTime / 2f)
        {
            Debug.Log("Image 3");
            (_it.Current as Image).enabled = false;
            _it.MoveNext();
            var image = _it.Current as Image;
            image.enabled = true;
        }

        if (Mathf.Abs(_timeElapsed - 4.360f) < fixedTime / 2f) //140
        {
            Debug.Log("Image 4");
            (_it.Current as Image).enabled = false;
            _it.MoveNext();
            var image = _it.Current as Image;
            image.enabled = true;
        }

        if (Mathf.Abs(_timeElapsed - 4.9f) < fixedTime / 2f) //107
        {
            Debug.Log("Image 5");
            (_it.Current as Image).enabled = false;
            _it.MoveNext();
            var image = _it.Current as Image;
            image.enabled = true;
        }

        if (Mathf.Abs(_timeElapsed - 5.45f) < fixedTime / 2f) //75
        {
            Debug.Log("Image 6");
            (_it.Current as Image).enabled = false;
            _it.MoveNext();
            var image = _it.Current as Image;
            image.enabled = true;
        }

        if (Mathf.Abs(_timeElapsed - 6f) < fixedTime / 2f) //37
        {
            Debug.Log("Image 7");
            (_it.Current as Image).enabled = false;
            _it.MoveNext();
            var image = _it.Current as Image;
            image.enabled = true;
        }
    }

    void Decrement()
    {
        if (_timeElapsed <= 10 && _gameStarted)
        {
            fixedTime = Time.fixedDeltaTime * 0.85f;
            _timeElapsed += fixedTime;
        }
    }

    void StartAudio()
    {
        if (_gameStarted)
            Camera.main.GetComponent<AudioSource>().enabled = true;
    }

    void StartGame()
    {
        Time.timeScale = 1;
        Destroy(gameObject);
        Instantiate(_scorePrefab);
        Camera.main.GetComponent<GameManager>().Player.GetComponent<InputController>().enabled = true;
    }

    void GetInput()
    {
        if (Input.GetButtonDown("Submit"))
        {
            Begin();
        }

        if (Input.GetButtonDown("Cancel"))
        {
            Application.Quit();
        }
    }
    #endregion
}
