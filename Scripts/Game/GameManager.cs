using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public Score scoreManager;
    private bool _lost;

    #region Events
    public UnityEvent onStartGame = new UnityEvent();
    public UnityEvent onEndGame = new UnityEvent();
    #endregion

    #region API
    public void StartGame()
    {
        onStartGame.Invoke();
    }
    #endregion

    // Use this for initialization
	void Start ()
	{
	    scoreManager = new Score();
	    _spawnX = Camera.main.orthographicSize*Camera.main.aspect + 2;
        _spawn1 = new Vector3(_spawnX, 0, -1);
        _spawn2 = new Vector3(_spawnX, -1.5f, -2);
        _spawn3 = new Vector3(_spawnX, -3, -3);
		Speed = 10;
        _playerAction = Player.GetComponent<PlayerAction>();
        _lost = _playerAction.IsDead();
	    Time.timeScale = 0;
	    _timerDeath = 50;
	}

    [SerializeField] private GameObject _endCanvas;
    [SerializeField] public GameObject Player;
    private PlayerAction _playerAction;
    public int NbOrgans;
    private int _timerDeath;

    void Lose()
    {
        if (_lost && !(_timerDeath < 0))
            _timerDeath--;

        if ((Input.GetKeyDown(KeyCode.V) || _playerAction.IsDead()) && !_lost)
        {
            _lost = true;
            Time.timeScale = 0;
            onEndGame.Invoke();
        }
 
        if (_timerDeath == 0)
            Instantiate(_endCanvas);
    }

    private float _spawnX;
    public Vector3 _spawn1 { get; set; }
    public Vector3 _spawn2 { get; set; }
    public Vector3 _spawn3 { get; set; }
	public int Speed;
	public float LastIncrease = 0f;

	// Update is called once per frame
	void Update () {
	    Lose();
	    //NbOrgans = Player.GetComponent<InputController>().NbOrgans;
		if ((Time.time - LastIncrease) > 12) {
			this.LastIncrease = Time.time;
			Speed += 1;
		}
	}
}
