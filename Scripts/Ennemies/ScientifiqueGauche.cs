using UnityEngine;
using System.Collections;

public class ScientifiqueGauche : MonoBehaviour {

	public float SpawnX;

	void Start () {
		float PosX = - Camera.main.orthographicSize * Camera.main.aspect + SpawnX;
		transform.position = new Vector3 (PosX, transform.position.y, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
