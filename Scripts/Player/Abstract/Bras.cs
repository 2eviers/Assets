using System;
using System.Collections.Generic;
using UnityEngine;

namespace AssemblyCSharp
{
    public abstract class Bras : Membre
    {

        public int Charge;

        public bool UseShield()
        {
            //Debug.Log("Nombre de charge : " + Charge);
            bool test = 0 < Charge;
            Charge --;
            return test;
        }
    }

}