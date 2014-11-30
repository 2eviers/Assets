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
		[SerializeField]
		private Sprite _spriteInactive;
		[SerializeField]
		private Sprite _spriteActive;
		private bool _activeHead;

        public bool IsEmpty()
        {
            return Charge <= 0;
        }

		private void HeadChange(){

			var sr = gameObject.GetComponent<SpriteRenderer> ();
			if (_activeHead) {
								if ((Time.time - LastUse) > Cooldown) {
										sr.sprite = _spriteInactive;
					_activeHead = false;
								}
						} else {
								_activeHead = true;
				sr.sprite = _spriteActive;
						}
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
			HeadChange ();
        }

        protected abstract void ActiveCompetence();

		protected override void Update(){
			if(_activeHead) HeadChange();
			base.Update();
		}

    }

}