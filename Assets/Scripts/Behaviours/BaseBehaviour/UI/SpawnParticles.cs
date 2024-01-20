using UnityEngine;
using System.Collections;

namespace FATEC.CubeWars.Behaviours {
	public class SpawnParticles : MonoBehaviour {
		public ParticleSystem particles;
		public float particleScale=1f;
		protected Vector3 _scale;
		protected ParticleSystem pr;
		protected Vector4 color;
		//private ParticleSystem ps;

		// Use this for initialization
		void Start() {
			if (this.CompareTag("Player")) {
				this.color=new Vector4(0, 0, 1f, 1f);
			}
			else {
				this.color=new Vector4(1f, 0, 0, 1f);
			}
			_scale.x=_scale.y=_scale.z=particleScale;
			pr=Instantiate(particles) as ParticleSystem;
			pr.transform.position=this.transform.position;
			pr.transform.localScale=_scale;
			pr.startColor=this.color;
			//ps=this.GetComponent<ParticleSystem>();
		}
	
		// Update is called once per frame
		/*void Update() {
			if (ps) {
				if (!ps.isAlive()) {
					Destroy(this.pr.gameObject);
				}
			}
	
		}*/
	}
}