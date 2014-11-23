using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class JambeHumaine : Jambe {

	void Start() {
		SpeedBonus = 5f;
	}

	void Update() {
		//on override l'update de membre car il n'y a pas de CurrentRejet pour les membres humains
	}
}