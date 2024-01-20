using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace FATEC.CubeWars.Behaviours {
	/// <summary>
	/// Provides health to a game object and takes action when it reaches 0.
	/// </summary>
	[RequireComponent(typeof(Collider))]
	public class Health : BaseBehaviour {
		[Tooltip("Available health.")]
		public int hp=5;
		[Tooltip("Coins give after death")]
		public int defeatCoins=3;
		[Tooltip("Slider health.")]
		public Slider healthSlider;
		[Tooltip("Tag used to check for collisions.")]
		public string collisionTag="Projectile";
		/// <summary>
		/// Currently available health.
		/// </summary>
		protected int currentHp;

		protected void Start() {

			this.currentHp=this.hp;
		}

		protected void OnTriggerEnter(Collider other) {
			if (other.CompareTag(this.collisionTag)) {
				this.ReceiveDamage();
			}
		}

		protected void OnCollisionEnter(Collision collision) {
			if (collision.collider.CompareTag(this.collisionTag)) {
				this.ReceiveDamage();
			}
		}

		protected void FixedUpdate() {
			healthSlider.value=currentHp/(float)hp;
		}

		/// <summary>
		/// Makes the current game object receives damage.
		/// </summary>
		protected void ReceiveDamage() {
			this.currentHp-=1;
			if (this.CompareTag("PlayerBase")) {
				Warning.compareDamage=1;
			}

			///Compare the tag of the current object if HP reaches zero and takes action based on it
			if (this.currentHp<=0) {
				if (this.CompareTag("Enemy")) {
					PlayerBase.PlayerCoin+=defeatCoins;
				}
				else if (this.CompareTag("EnemyBase")) {
					PlayerBase.PlayerCoin+=defeatCoins;
				}
				else if (this.CompareTag("PlayerBase")) {
					SceneManager.LoadScene("GameOver");
				}
				else {
					EnemyBase.EnemyCoin+=defeatCoins/CreateBase.baseVal;
				}
				Destroy(this.gameObject);
			}
		}
	}
}