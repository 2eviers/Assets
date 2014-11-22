using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class TeteRobot : Tete {

	public GameObject FulgurotetePrefab;

	void Start() {
		Cooldown = 0;
		Charge = 1;
	}
	
	protected override void ActiveCompetence() {
		//on instancie une fulguro tete
		Vector3 PositionTete = Player.GetComponent<Tete> ().transform.position;
		PositionTete.x += 2;
		GameObject Fulgurotete = (GameObject) Instantiate (FulgurotetePrefab);
		Fulgurotete.transform.position = PositionTete;
		//sacrifice de la tete
		Rejet = 0;
	}
}