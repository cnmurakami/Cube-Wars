using UnityEngine;
using System.Collections;

namespace FATEC.CubeWars.Behaviours {
	/// <summary>
	/// Detects an enemy and fires.
	/// </summary>
	[RequireComponent(typeof(Collider))]
	public class DetectAndFire : BaseBehaviour {
		[Tooltip("Tag used to detect enemies.")]
		public string enemyTag="Enemy";
		[Tooltip("Projectile prefab.")]
		public GameObject projectilePrefab;
		[Tooltip("Fire rate delay (seconds).")]
		public float delay=1.0f;
		[Tooltip("Fire local position.")]
		public Vector3 firePosition;

		/// <summary>Reference to the weapon coroutine.</summary>
		protected Coroutine weapon;
		/// <summary>Reference to the enemy being attacked.</summary>
		protected Collider enemyCollider;
		/// <summary>Reference to the enemy Transform.</summary>
		protected Transform enemyTransform;

		/// <summary>Current enemy being targeted.</summary>
		protected Collider enemy {
			get { return this.enemyCollider; }
			set {
				if (value==null) {
					if (this.enemyCollider==null)
						return;

					//If there's no enemy, stop firing.
					this.StopCoroutine(this.weapon);
					this.weapon=null;
					this.enemyCollider=null;
					this.enemyTransform=null;
				}
				else {
					//If there's an enemy, starts firing.
					this.enemyCollider=value;
					this.enemyTransform=this.enemyCollider.GetComponent<Transform>();
					this.weapon=this.StartCoroutine(this.Fire());
				}
			}
		}

		protected void OnTriggerStay(Collider other) {
			//If the current enemy is destroyed, checks whether
			//any other colliders staying on the trigger are
			//enemies that can be targeted.
			if (this.enemy==null && other.CompareTag(this.enemyTag)) {
				this.enemy=other;
			}
		}

		protected void OnTriggerEnter(Collider other) {
			if (this.enemyCollider!=null || !other.CompareTag(this.enemyTag)) {
				return;
			}

			this.enemy=other;
			foreach (MoveEnemy w in this.GetComponentsInParent<MoveEnemy>()) {
				w.walk=false;
			}
			foreach (MoveGear w in this.GetComponentsInParent<MoveGear>()) {
				w.walk=false;
			}
		}

		protected void OnTriggerExit(Collider other) {
			if (this.enemyCollider==other) {
				this.enemy=null;
				foreach (MoveEnemy w in this.GetComponentsInParent<MoveEnemy>()) {
					w.walk=true;
				}
				foreach (MoveGear w in this.GetComponentsInParent<MoveGear>()) {
					w.walk=true;
				}
			}
		}

		protected void FixedUpdate() {
			if (this.enemyTransform!=null) {
				this.transform.LookAt(this.enemyTransform);
			}
		}

		/// <summary>
		/// Fires projectiles in given fire rate delay.
		/// </summary>
		protected IEnumerator Fire() {
			while (true) {
				if (this.enemyTransform==null) {
					this.enemy=null;
					foreach (MoveEnemy w in this.GetComponentsInParent<MoveEnemy>()) {
						w.walk=true;
					}
					foreach (MoveGear w in this.GetComponentsInParent<MoveGear>()) {
						w.walk=true;
					}
					break;
				}

				var projectile=Instantiate(this.projectilePrefab);
				projectile.GetComponent<Transform>().position=
																	this.transform.TransformPoint(this.firePosition);
				projectile.GetComponent<MoveToTarget>().targetPosition=
																	this.enemyTransform.position;

				yield return new WaitForSeconds(this.delay);
			}
		}
	}
}