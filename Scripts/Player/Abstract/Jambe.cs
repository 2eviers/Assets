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
            base.Start();
            Player.GetComponent<PlayerMotion>().Speed += SpeedBonus;
        }

        public override void Detruire()
        {

            Player.GetComponent<PlayerMotion>().Speed -= SpeedBonus;
            base.Detruire();
        }



    }

}