using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class TeteDragon : Tete {

	public GameObject FireballPrefab;

	void Start() {
		Cooldown = 5f;
		Charge = 3;
	}
	
	protected override void ActiveCompetence() {
		//on instancie une boule de feu 
		Vector3 PositionTete = Player.GetComponent<Tete> ().transform.position;
		PositionTete.x += 2;
		GameObject Fireball = (GameObject) Instantiate (FireballPrefab);
		Fireball.transform.position = PositionTete;
	}
}