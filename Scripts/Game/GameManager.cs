using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
	    _spawn1 = new Vector3(10, 0, -1);
        _spawn2 = new Vector3(10, -1.5f, -2);
        _spawn3 = new Vector3(10, -3, -3);
		Speed = 10;
	}

    public Vector3 _spawn1 { get; set; }
    public Vector3 _spawn2 { get; set; }
    public Vector3 _spawn3 { get; set; }
	public int Speed;

	// Update is called once per frame
	void Update () {
	
	}
}
