using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class TeteRobot : Tete {

	public GameObject FulgurotetePrefab;

	
	protected override void ActiveCompetence() {
		//on instancie une fulguro tete
        Vector3 PositionTete = Player.GetComponent<PlayerAction>().TeteContain.transform.position;
		PositionTete.x += 2;
		GameObject Fulgurotete = (GameObject) Instantiate (FulgurotetePrefab);
		Fulgurotete.transform.position = PositionTete;
		//sacrifice de la tete
		CurrentRejet = 0;
	}
}