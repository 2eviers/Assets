using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class TetePoulet : Tete {
	
	
	protected override void ActiveCompetence() {
		if (this.gameObject.audio != null)
			this.gameObject.audio.Play ();
	}
}