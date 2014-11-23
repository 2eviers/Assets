using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class TeteHumaine : Tete {

	void Start() {
		Cooldown = 0;
		Charge = 0;
	}

	protected override void ActiveCompetence() {
		return;
	}

	void Update() {
		//on override l'update de membre car il n'y a pas de CurrentRejet pour les membres humains
	}
}