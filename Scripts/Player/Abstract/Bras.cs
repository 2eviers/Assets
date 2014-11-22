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
            return 0 < Charge--;
        }
    }

}