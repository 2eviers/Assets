using System;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(CharacterMotor))];
namespace AssemblyCSharp
{
    public abstract class Membre : MonoBehaviour

    {
        [NonSerialized]
        public float CurrentRejet;

        public float MaxRejet;
        public GameObject Player;

        public bool IsDead()
        {
            return CurrentRejet <= 0;
        }


        private void Tombe()
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

        public virtual void Detruire()
        {
            Destroy(gameObject);
        }

        void Start()
        {
            CurrentRejet = MaxRejet;
        }

        void Update()
        {
            CurrentRejet -= Time.deltaTime;

            Tombe();
        }
    }
}