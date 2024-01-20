using UnityEngine;
using System.Collections;

namespace FATEC.CubeWars.Behaviours {
	public class Coin : MonoBehaviour {
		protected int time=0;

		public ParticleSystem particles;
		public float particleScale=1f;
		protected Vector3 _scale;
		protected ParticleSystem pr;
		protected Vector4 color;

		// Use this for initialization
		void Start() {
			Vector3 position=new Vector3(Random.Range(-100f, 100f), 0, Random.Range(-100f, 100f));
			NavMeshHit hit;
			NavMesh.SamplePosition(position, out hit, 10, 1);
			position=hit.position;
			this.transform.position=position;
			//this.transform.position=new Vector3(transform.position.x,0 , transform.position.z);
		}
	
		// Update is called once per frame
		void FixedUpdate() {
			time++;
			if (time>=1800) {
				Warning.msgDetect=true;
				Warning.msg="You lost a SUPER COIN...";
				Warning.col=Color.blue;
				Warning.count=0;
				Destroy(this.gameObject);
			}
		}

		protected void OnTriggerEnter(Collider other) {
			if (other.CompareTag("Player")) {
				PlayerBase.PlayerCoin+=30;
				Warning.msgDetect=true;
				Warning.msg="SUPER COIN Collected! +30 Coins!";
				Warning.col=Color.green;
				Warning.count=0;
				Shine();
				Destroy(this.gameObject);
			}
			if (other.CompareTag("Enemy")) {
				EnemyBase.EnemyCoin+=30;
				Warning.msgDetect=true;
				Warning.msg="You lost a SUPER COIN...";
				Warning.col=Color.blue;
				Warning.count=0;
				Shine();
				Destroy(this.gameObject);
			}

			
		}

		void Shine() {
			this.color=new Vector4(0.614f, 1f, 0.252f, 1f);
			_scale.x=_scale.y=_scale.z=particleScale;
			pr=Instantiate(particles) as ParticleSystem;
			pr.transform.position=this.transform.position;
			pr.transform.localScale=_scale;
			pr.startColor=this.color;
		}
	}
}