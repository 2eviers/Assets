﻿using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class TetePoulpe : Tete {
	
	void Start() {
		Cooldown = 0;
		Charge = 0;
	}
	
	protected override void ActiveCompetence() {
		return;
	}
}