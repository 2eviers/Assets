using System;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(CharacterMotor))];
namespace AssemblyCSharp
{
    public abstract class Membre : MonoBehaviour

    {

        public float Rejet;
        public GameObject Player;

        public bool IsDead()
        {
            return Rejet <= 0;
        }


        protected void Tombe()
        {
            //si le membre n'est pas mort il ne se passe rien
            if (!IsDead())
                return;

            //sinon le membre tombe red mort.
            Detruire();
        }
        public void Jeter()
        {
            Detruire();
        }

        protected virtual void Detruire(){}

        void Update()
        {
            Rejet -= Time.deltaTime;
            Tombe();
        }
    }
}