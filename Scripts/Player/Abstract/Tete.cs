using System;
using System.Collections.Generic;
using UnityEngine;

namespace AssemblyCSharp
{



    public abstract class Tete : Membre
    {
        public float Cooldown;
        protected float LastUse;
        public int Charge;

        public bool IsEmpty()
        {
            return Charge <= 0;
        }

        public void UseCompetence()
        {
            
            // si le membre est mort
            if (IsDead())
                return;
            // si le cooldown n'est pas écoulé. 
            if (Time.time < LastUse + Cooldown)
                return;

            LastUse = Time.time;

            // si plus de charge
            if (IsEmpty())
                return;

            Charge--;
            ActiveCompetence();
        }

        protected abstract void ActiveCompetence();



    }

}