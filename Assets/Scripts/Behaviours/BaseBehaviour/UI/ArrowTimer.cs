using UnityEngine;
using System.Collections;
using FATEC.CubeWars.Behaviours;

namespace FATEC.CubeWars.Behaviours {
	public class ArrowTimer : MonoBehaviour {
		protected int timer;
		protected float alpha;
		protected float distance=1000.0f;
		protected Vector3 origin;
		RaycastHit hit;

		void Start() {
			this.timer=0;
			origin=transform.position;
		}

		// Update is called once per frame
		void FixedUpdate() {
			if (Input.GetMouseButton(1)) {
				var ray=Camera.main.ScreenPointToRay(Input.mousePosition);
				if (Physics.Raycast(ray, out hit, this.distance) && hit.collider.CompareTag("Ground")) {
					transform.position=hit.point;
				}
				this.timer=1;
			}
			if (this.timer==1) {
				if (Input.GetMouseButtonDown(0)) {
					var ray=Camera.main.ScreenPointToRay(Input.mousePosition);
					if (Physics.Raycast(ray, out hit, this.distance) && !hit.collider.CompareTag(this.tag)) {
						transform.position=origin;
					}

				}
			}

		}

		protected void OnCollisionEnter(Collision collision) {
			if (collision.collider.CompareTag("Player") && !Input.GetMouseButton(1)) {
				transform.position=origin;
			}
		}
	}
}