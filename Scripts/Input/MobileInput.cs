using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MobileInput : MonoBehaviour
{
    #region Injections
    [SerializeField]
    InputController _inputController = null;
    [SerializeField]
    GameManager _gameManager = null;
    [SerializeField]
    GameObject _upButton = null;
    [SerializeField]
    GameObject _downButton = null;
    [SerializeField]
    GameObject _actionButton = null;
    [SerializeField]
    GameObject _headButton = null;
    [SerializeField]
    GameObject _rightArmButton = null;
    [SerializeField]
    GameObject _leftArmButton = null;
    [SerializeField]
    GameObject _rightLegButton = null;
    [SerializeField]
    GameObject _leftLegButton = null;
    #endregion

    #region API
    public void ButtonInput(string button)
    {
        _inputController.MobileInput(button);
    }
    #endregion

    #region Handlers
    void OnCollision(bool isColliding)
    {
        SwitchButtons(isColliding);
    }

    void OnStartGame()
    {
    }

    void OnEndGame()
    {
        SwitchAllButtonsOff();
    }
    #endregion

    #region Unity
    void Awake () {
        if (_inputController == null)
        {
            _inputController = FindObjectOfType<InputController>();
        }
        if (_inputController != null)
        {
            _inputController.onCollision.AddListener(OnCollision);
        }
        if (_gameManager == null)
        {
            _gameManager = FindObjectOfType<GameManager>();
        }
        if (_gameManager != null)
        {
            _gameManager.onStartGame.AddListener(OnStartGame);
            _gameManager.onEndGame.AddListener(OnEndGame);
        }

        _actionButtons.Add(_upButton);
        _actionButtons.Add(_downButton);
        _actionButtons.Add(_actionButton);

        _organButtons.Add(_headButton);
        _organButtons.Add(_leftArmButton);
        _organButtons.Add(_rightArmButton);
        _organButtons.Add(_leftLegButton);
        _organButtons.Add(_rightLegButton);

        SwitchAllButtonsOff();
	}
    #endregion

    #region Private
    List<GameObject> _actionButtons = new List<GameObject>();
    List<GameObject> _organButtons = new List<GameObject>();

    void SwitchButtons(bool isColliding)
    {
        // If we're colliding a monster, disable action buttons...
        foreach (GameObject button in _actionButtons)
        {
            if (button != null)
            {
                button.SetActive(!isColliding);
            }
        }

        // ... and enable organ buttons.
        foreach (GameObject button in _organButtons)
        {
            if (button != null)
            {
                button.SetActive(isColliding);
            }
        }        
    }

    void SwitchAllButtonsOff()
    {
        foreach (GameObject button in _organButtons)
        {
            if (button != null)
            {
                button.SetActive(false);
            }
        }
        foreach (GameObject button in _actionButtons)
        {
            if (button != null)
            {
                button.SetActive(false);
            }
        } 
    }
    #endregion
}
