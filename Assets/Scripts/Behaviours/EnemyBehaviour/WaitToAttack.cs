using UnityEngine;
using System.Collections;

namespace FATEC.CubeWars.Behaviours {
	/// <summary>
	/// Creates a timer for the enemy units to wait to start attacking
	/// </summary>
	public class WaitToAttack : MonoBehaviour {
		private float waitTime;
		[Tooltip("Minimum time to be waited before attacking in seconds")]
		public float MinimumTime=5f;
		[Tooltip("Maximum time to be waited before attacking in seconds")]
		public float MaximumTime=10f;
		//float i=0;

		public static bool canMove;

		// Use this for initialization
		void Start() {
			canMove=false;
			this.waitTime=Random.Range(MinimumTime, MaximumTime);
		}
	
		// Update is called once per frame
		protected void FixedUpdate() {
			if (Time.time>=this.waitTime) {
				canMove=true;
				Warning.msgDetect=true;
				Warning.msg="Enemies are commencing assault";
				Warning.col=Color.yellow;
				Warning.count=0;
				Destroy(this.gameObject);
			}
		}
	}
}