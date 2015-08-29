using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class TeteAlien : Tete {
	
	protected override void ActiveCompetence() {
		//permet de reveler les scientifiques caches
		StartCoroutine (AC ());
	}

	IEnumerator AC() {
		Ennemy[] EnnemyList = (Ennemy[]) Resources.FindObjectsOfTypeAll (typeof(Ennemy));
		for (int i = 0; i < 10*Cooldown; i++) {
			yield return new WaitForSeconds (0.1f);
			foreach (Ennemy e in EnnemyList) {
				if (e.IsHiddenScientist)
					e.GetComponent<Renderer>().material.color = Color.green;
			}
		}
	}
}