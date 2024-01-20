using UnityEngine;
using System.Collections;
using FATEC.CubeWars.Behaviours;

namespace FATEC.CubeWars.Behaviours {
	public class Minimap : MonoBehaviour {
		public Camera MinimapCamera;
		public Camera MainCamera;

		// Use this for initialization
		void Start() {

		}

		// Update is called once per frame
		void FixedUpdate() {
			if (Input.GetMouseButton(1) && (Input.mousePosition.x>(Screen.width-(Screen.width/100*30))) && (Input.mousePosition.y<(Screen.height/100*30))) {
				MinimapCamera.enabled=false;
			}
			else {
				MinimapCamera.enabled=true;
			}
			if (MainCamera.GetComponent<BoxSelection>().isActive==false && (Input.mousePosition.x>(Screen.width-(Screen.width/100*30))) && (Input.mousePosition.y<(Screen.height/100*30))) {
				if (Input.GetMouseButton(0)) {
					RaycastHit hit;
					Ray ray=MinimapCamera.ScreenPointToRay(Input.mousePosition);
					if (Physics.Raycast(ray, out hit)) {
						MainCamera.transform.position=new Vector3(hit.point.x-40, MainCamera.transform.position.y, hit.point.z-50);
					}
				}
			}
		}
	}
}