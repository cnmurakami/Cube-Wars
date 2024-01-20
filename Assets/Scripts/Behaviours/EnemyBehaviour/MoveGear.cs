using UnityEngine;
using System.Collections;

namespace FATEC.CubeWars.Behaviours {
	/// <summary>
	/// Provides movement to the enemy based on the tag of Player units and tower
	/// </summary>
	public class MoveGear : BaseBehaviour {
		Transform nearestObj;
		protected Collider enemyCollider;
		public bool walk;
		private bool offensive;

		void Start() {
			var basea=GameObject.FindGameObjectWithTag("PlayerBase");
			this.transform.LookAt(basea.transform);
			int choice=Random.Range(1, 5);
			if (choice==1) {
				this.offensive=false;
			}
			else {
				this.offensive=true;
			}
			walk=true;
		}

		/// <summary>
		/// Gets the nearest enemy and move towards it
		/// </summary>
		void Update() {
			if (WaitToAttack.canMove==true) {
				if (offensive==true) {
					if (walk==true) {
						var basea=GameObject.FindGameObjectWithTag("PlayerBase");
						this.GetComponent<NavMeshAgent>().Resume();
						this.GetComponent<NavMeshAgent>().destination=basea.transform.position;
					}
					if (walk==false) {
						this.GetComponent<NavMeshAgent>().Stop();
					}
				}
			}
		}
	}
}