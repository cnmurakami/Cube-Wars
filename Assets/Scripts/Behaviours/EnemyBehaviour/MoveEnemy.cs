using UnityEngine;
using System.Collections;

namespace FATEC.CubeWars.Behaviours {
	/// <summary>
	/// Provides movement to the enemy based on the tag of Player units and tower
	/// </summary>
	public class MoveEnemy : BaseBehaviour {
		Transform nearestObj;
		Transform nearestCoin;
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
						this.GetComponent<NavMeshAgent>().Resume();
						GetNearestTaggedObject();
						this.GetComponent<NavMeshAgent>().destination=nearestObj.transform.position;
					}
					if (walk==false) {
						this.GetComponent<NavMeshAgent>().Stop();
					}
				}
			}
		}


		/// <summary>
		/// Creates a list with the position of all enemies and arrange them by closest
		/// </summary>
		/// <returns> Closest enemy in the list </returns>
		Transform GetNearestTaggedObject() {
			var nearestDistanceSqr=Mathf.Infinity;
			var taggedGameObjects=GameObject.FindGameObjectsWithTag("Detector");

			foreach (GameObject obj in taggedGameObjects) {

				var objectPos=obj.transform.position;
				var distanceSqr=(objectPos-transform.position).sqrMagnitude;

				if (distanceSqr<nearestDistanceSqr) {
					nearestObj=obj.transform;
					nearestDistanceSqr=distanceSqr;
				}
			}
			return nearestObj;
		}

	}
}