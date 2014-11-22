using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class TeteAlien : Tete {
	
	void Start() {
		Cooldown = 5f;
		Charge = 3;
	}
	
	protected override void ActiveCompetence() {
		//permet de reveler les scientifiques caches
	}
}