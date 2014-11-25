using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public Score scoreManager;
    private bool _loose;
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
        _loose = _playerAction.IsDead();
	    Time.timeScale = 0;
	}

    [SerializeField] private GameObject _endCanvas;
    [SerializeField] public GameObject Player;
    private PlayerAction _playerAction;
    public int NbOrgans;

    void Loose()
    {

        if ((Input.GetKeyDown(KeyCode.V) || _playerAction.IsDead())&& !_loose )
        {
            _loose = true;
            Time.timeScale = 0;
            Instantiate(_endCanvas);
        }  
    }

    private float _spawnX;
    public Vector3 _spawn1 { get; set; }
    public Vector3 _spawn2 { get; set; }
    public Vector3 _spawn3 { get; set; }
	public int Speed;
	public float LastIncrease = 0f;

	// Update is called once per frame
	void Update () {
	    Loose();
	    NbOrgans = Player.GetComponent<InputController>().NbOrgans;
		if ((Time.time - LastIncrease) > 12) {
			this.LastIncrease = Time.time;
			Speed += 1;
		}
	}
}
