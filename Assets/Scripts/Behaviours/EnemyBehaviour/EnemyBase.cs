using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace FATEC.CubeWars.Behaviours {
	/// <summary>
	/// Manages enemy coins and spawn decisions
	/// </summary>

	public class EnemyBase : BaseBehaviour {
		public static int EnemyCoin;
		public GameObject soldier;
		public GameObject tank;
		public GameObject metalGear;
		private int choice;
		private int timer;

		// Use this for initialization
		void Start() {	
			this.timer=0;
			EnemyCoin+=30;
		}

		/// <summary>
		/// Checks if it has more than the maximum amount and coin and limits it
		/// AI waits for frames and then checks if it has enough coins to spawn a unity, then decides if it will spawn a unit and which one
		/// </summary>
		void FixedUpdate() {
			if (EnemyCoin>=PlayerBase.MaximumCoin*CreateBase.baseVal) {
				EnemyCoin=PlayerBase.MaximumCoin*CreateBase.baseVal;
			}
			if (UnitCount.enemyUnits<UnitCount.maxUnits*CreateBase.baseVal) {
				timer++;
				if (timer>=120) {
					choice=Random.Range(0, 1000);
					/// If chance is between 751 and 1000, it will try to spawn a tanke and/or a soldier
					if (choice>750) {
						if (EnemyCoin>=7) {
							Spawn(300, 7, tank);
							//timer=0;
						}
						if (EnemyCoin>=3) {
							Spawn(500, 3, soldier);
							//timer=0;
						}
					}
					/// If after spawning it still has enough coins, it has 50% chance of spawning a metalGear
					if (EnemyCoin>=15) {
						Spawn(500, 15, metalGear);
						//timer=0;
					}
					timer=0;
				}
			}
		}

		/// <summary>
		/// Take a chance at spawning unit
		/// When successfull, spawn it randomly inside RandomCircle
		/// </summary>
		/// <param name="success"> Negative success rate to be spawned (the less this value, more chance to spawn) </param>
		/// <param name="cost"> Cost necessary to spawn unit </param>
		/// <param name="unit"> Unit to be spawned (as of now, can be 'soldier', 'tank' or 'metalGear' </param>
		void Spawn(int success, int cost, UnityEngine.GameObject unit) {
			choice=Random.Range(0, 1000);
			if (choice>=success) {
				EnemyCoin-=cost;
				Vector3 center=transform.position;
				Vector3 pos=RandomCircle(center, 3.0f);
				GameObject tempPrefab=Instantiate(unit) as GameObject;
				tempPrefab.transform.position=pos;
				tempPrefab.GetComponent<NavMeshAgent>().Warp(pos);
				//tempPrefab.transform.position=new Vector3((this.transform.position.x+Random.Range(-5, 5)), (this.transform.position.y), (this.transform.position.z+Random.Range(-5, 5)));
			}
		}

		/// <summary>
		/// Creates a random point inside a given radius. Note that Y axis will always be equal to the center
		/// </summary>
		/// <param name="center"> The transform position of this </param>
		/// <param name="radius"> The desired radius around this</param>
		/// <returns>(pos.x, pos.y, pos.z)</returns>
		Vector3 RandomCircle(Vector3 center, float radius) {
			float ang=Random.value*360;
			Vector3 pos;
			pos.x=center.x+radius*Mathf.Sin(ang*Mathf.Deg2Rad);
			pos.y=center.y;
			pos.z=center.z+radius*Mathf.Cos(ang*Mathf.Deg2Rad);
			return pos;
		}
	}
}
