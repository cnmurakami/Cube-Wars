using UnityEngine;
using System.Collections;

namespace FATEC.CubeWars.Behaviours {
	/// <summary>
	/// Generates random variations for unit's movement speed, shooting delay and detection radius
	/// </summary>
	public class Fitness : MonoBehaviour {
		private float fitnesse;


		// Use this for initialization
		void Start() {
			fitnesse=Random.Range(-1f, 1f);
			this.GetComponent<NavMeshAgent>().speed+=fitnesse;
			fitnesse=Random.Range(-0.5f, 0.5f);
			this.GetComponentInChildren<DetectAndFire>().delay+=fitnesse;
			fitnesse=Random.Range(-1f, 1f);
			this.GetComponentInChildren<SphereCollider>().radius+=fitnesse;
		}
	}
}