using UnityEngine;
using System.Collections;

namespace FATEC.CubeWars.Behaviours {
	/// <summary>
	/// Gives coins based on time
	/// </summary>

	public class TimeCoin : BaseBehaviour {
		public GameObject baseA;
		private int timer;
		protected int amount;

		void Start() {
			timer=0;
		}

		void FixedUpdate() {
			Time();
		}

		void Time() {
			timer++;
			if (timer>=300) {
				ChanceCalc();
				PlayerBase.PlayerCoin+=amount;
				if (amount>0) {
					baseA.GetComponent<PlayerBase>().timer=0;
					baseA.GetComponent<PlayerBase>().Cost="  Time Bonus +"+amount;
				}
				ChanceCalc();
				EnemyBase.EnemyCoin+=amount*CreateBase.baseVal;
				timer=0;
			}
		}

		void ChanceCalc() {
			int chance=Random.Range(1, 101);
			if (chance<=35) {
				amount=2;
			}
			else if (chance<=65) {
				amount=1;
			}
			else if (chance<=85) {
				amount=3;
			}
			else if (chance<=95) {
				amount=0;
			}
			else {
				amount=4;
			}
		}
	}
}