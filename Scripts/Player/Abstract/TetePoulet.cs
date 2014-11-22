using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class TetePoulet : Tete {
	
	void Start() {
		Cooldown = 0.5f;
		Charge = 1000;
	}
	
	protected override void ActiveCompetence() {
		if (this.gameObject.audio != null)
			this.gameObject.audio.Play ();
	}
}