using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class TeteRobot : Tete {
	
	void Start() {
		Cooldown = 0;
		Charge = 0;
	}
	
	protected override void ActiveCompetence() {
		return;
	}
}