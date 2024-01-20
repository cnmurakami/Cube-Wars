using UnityEngine;
using System.Collections;
using FATEC.CubeWars.Menu;

namespace FATEC.CubeWars.Behaviours {
	public class BoxSelection : MonoBehaviour {
		public Texture2D selectionHighlight=null;
		public static Rect selection=new Rect(0, 0, 0, 0);
		private Vector3 inBox=-Vector3.one;
		public bool isActive=false;
		public Camera minimap;
		private Vector2 mousePosition;
		protected Vector3 startPoint;
		protected Vector3 check;
		// Use this for initialization

		// Update is called once per frame
		private void Update() {
			if (Pause.isPaused==false) {
				CheckCamera();
			}
		}

		private void CheckCamera() {
			if (Input.GetMouseButtonDown(0) && !((Input.mousePosition.x>(Screen.width-(Screen.width/100*30))) && (Input.mousePosition.y<(Screen.height/100*30))) && isActive==false) {
				startPoint=Input.mousePosition;
				isActive=true;
			}
			if (Input.GetMouseButton(0) && isActive==true && (Input.mousePosition.x>(startPoint.x+50) || Input.mousePosition.x<(startPoint.y-50) ||
			    Input.mousePosition.y>(startPoint.y+50) || Input.mousePosition.y<(startPoint.y-50))) {
				inBox=startPoint;
			}
			if (Input.GetMouseButton(0) && isActive==true && (Input.mousePosition.x>(Screen.width-(Screen.width/100*30))) && (Input.mousePosition.y<(Screen.height/100*30))) {
				minimap.enabled=false;
			}
			if (Input.GetMouseButton(0) && isActive==true && !((Input.mousePosition.x>(Screen.width-(Screen.width/100*30))) && (Input.mousePosition.y<(Screen.height/100*30)))) {
				minimap.enabled=true;
			}
			if (Input.GetMouseButtonUp(0)) {
				inBox=-Vector3.one;
				isActive=false;
				minimap.enabled=true;
			}
			if (Input.GetMouseButton(0)) {
				selection=new Rect(inBox.x, InvertMouseY(inBox.y), Input.mousePosition.x-inBox.x, InvertMouseY(Input.mousePosition.y)-InvertMouseY(inBox.y));
				if (selection.width<0) {
					selection.x+=selection.width;
					selection.width=-selection.width;
				}
				if (selection.height<0) {
					selection.y+=selection.height;
					selection.height=-selection.height;
				}
			}

		}

		private void OnGUI() {
			if (inBox!=-Vector3.one) {
				GUI.color=new Color(1, 1, 1, 0.5f);
				GUI.DrawTexture(selection, selectionHighlight);
			}
		}

		public static float InvertMouseY(float y) {
			return Screen.height-y;
		}
	}
}