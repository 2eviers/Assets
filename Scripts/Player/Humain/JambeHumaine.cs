using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class JambeHumaine : Jambe {


	protected override void Update() {
		//on override l'update de membre car il n'y a pas de CurrentRejet pour les membres humains
        DurationUpdate();
	}
}