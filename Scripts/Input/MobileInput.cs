using UnityEngine;
using System.Collections;

public class MobileInput : MonoBehaviour
{
    #region Injections
    [SerializeField]
    InputController _inputController = null;
    #endregion

    #region API
    public void ButtonInput(string button)
    {
        _inputController.MobileInput(button);
    }
    #endregion

    #region Unity
    void Start () {
        if (_inputController == null)
        {
            _inputController = FindObjectOfType<InputController>();
        }
	}
    #endregion
}
