using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class TeteDragon : Tete {

	public GameObject FireballPrefab;

	
	protected override void ActiveCompetence() {
		//on instancie une boule de feu 
		Vector3 PositionTete = Player.GetComponent<PlayerAction>().TeteContain.transform.position;
		PositionTete.x += 2;
		GameObject Fireball = (GameObject) Instantiate (FireballPrefab);
		Fireball.transform.position = PositionTete;
	}
}