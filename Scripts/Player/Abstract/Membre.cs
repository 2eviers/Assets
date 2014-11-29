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

        public float BonusMultiplicator = 1f;
        [NonSerialized]
        public float TimeDuration = 0;
        private Color color;
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
            Camera.main.GetComponent<GameManager>().scoreManager.RemoveData(this);
            Destroy(gameObject);
        }

        
        protected virtual void Start()
        {
            color = gameObject.GetComponent<Renderer>().material.color;
            CurrentRejet = MaxRejet;
        }

        protected void DurationUpdate()
        {
            TimeDuration += Time.deltaTime;
        }

        void Update()
        {
            DurationUpdate();

            CurrentRejet -= Time.deltaTime;

            gameObject.GetComponent<Renderer>().material.color = (CurrentRejet / MaxRejet) * color;

            Tombe();
        }
    }
}