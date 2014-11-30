using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class TeteHumaine : Tete {

	protected override void ActiveCompetence() {
		return;
	}

	protected override void Update() {
		//on override l'update de membre car il n'y a pas de CurrentRejet pour les membres humains
        DurationUpdate();
	}
}