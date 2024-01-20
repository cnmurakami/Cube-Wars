using UnityEngine;
using System.Collections;

namespace FATEC.CubeWars.Behaviours {
				/// <summary>
				/// Destroys the game object on collision.
				/// 
				/// It's recommended to use layers to prevent unwanted collisions.
				/// </summary>
				[RequireComponent(typeof(Collider))]
				public class DestroyOnCollide : BaseBehaviour {
								protected void OnTriggerEnter(Collider other) {
												Destroy(this.gameObject);
								}

								protected void OnCollisionEnter(Collision collision) {
												Destroy(this.gameObject);
								}
				}
}