using System;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(PlayerMotion))];
namespace AssemblyCSharp
{

    public abstract class Jambe : Membre
    {
        public float SpeedBonus;

        public int Charge;
        void Start()
        {
            Player.GetComponent<PlayerMotion>().Speed += SpeedBonus;
        }

        public override void Detruire()
        {
            Player.GetComponent<PlayerMotion>().Speed -= SpeedBonus;
            base.Detruire();

        }

        public bool UseShield()
        {
            return 0 < Charge--;
        }


    }

}