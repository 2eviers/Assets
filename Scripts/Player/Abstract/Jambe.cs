using System;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(PlayerMotion))];
namespace AssemblyCSharp
{

    public abstract class Jambe : Membre
    {
        public float SpeedBonus;

        protected override void Start()
        {
            Player.GetComponent<PlayerMotion>().Speed += SpeedBonus;
            base.Start();
        }

        public override void Detruire()
        {
<<<<<<< HEAD
			//Debug.Log (Player.GetComponent<PlayerMotion> ().Speed);
            Player.GetComponent<PlayerMotion>().Speed -= SpeedBonus;
			//Debug.Log (Player.GetComponent<PlayerMotion> ().Speed);
			base.Detruire();
			//Debug.Log (Player.GetComponent<PlayerMotion> ().Speed);
=======
            Player.GetComponent<PlayerMotion>().Speed -= SpeedBonus;
            base.Detruire();
>>>>>>> origin/master
        }



    }

}