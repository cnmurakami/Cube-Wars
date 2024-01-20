using UnityEngine;
using System.Collections;

namespace FATEC.CubeWars.Behaviours {
	/// <summary>
	/// Moves the camera when the mouse is positioned over the borders or the corresponding key is pressed
	/// </summary>
	public class MoveCamera : MonoBehaviour {

		Vector3 mousePos;
		[Tooltip("Velocidade de movimento padrao da camera")]
		public static float scrollSpeed=0.5f;
		[Tooltip("Velocidade de movimento alternativo da camera")]
		public static float altScrollSpeed=scrollSpeed*4;
		public Camera MainCamera;

		/// <summary>
		/// Updates the mouse position and checks if the player is trying to move the camera
		/// </summary>
		void FixedUpdate() {
			if (this.GetComponent<BoxSelection>().isActive==false) {
				mousePos=Input.mousePosition;
				CheckCameraZoom();
				///------------------
				///This section controls the camera proximity value using the Mouse Scroll Wheel or the up and down arrow
				///Instead of using the actual zoom, it uses the properties of the camera's orthographic view size to control the visible area
				///------------------
				if (Input.GetKey(KeyCode.DownArrow) || ((Input.GetAxis("Mouse ScrollWheel")<0)) || Input.GetKey(KeyCode.Q)) {
					MainCamera.orthographicSize+=scrollSpeed;
				}

				if (Input.GetKey(KeyCode.UpArrow) || ((Input.GetAxis("Mouse ScrollWheel")>0)) || Input.GetKey(KeyCode.E)) {
					MainCamera.orthographicSize+=-scrollSpeed;
				}
				///------------------------------------------


				///-----------------
				///This section controls general camera movement across the space using the X and Z axis altogether
				///-----------------

				//If mouse is 5 pixels or less from the left side of the screen or "A" key is pressed,
				//the camera moves in that direction at scrollSpeed or at altScrollSpeed if "SHIFT" key is also pressed
				if (mousePos.x<5 || Input.GetKey(KeyCode.A)) {
					if (Input.GetKey(KeyCode.LeftShift)) {
						this.transform.Translate(-altScrollSpeed, 0, altScrollSpeed, Space.World);
					}
					else {
						this.transform.Translate(-scrollSpeed, 0, scrollSpeed, Space.World);
					}
				}

				//If mouse is 5 pixels or more from the right side of the screen or "D" key is pressed,
				//the camera moves in that direction at scrollSpeed or at altScrollSpeed if "SHIFT" key is also pressed
				if (mousePos.x>Screen.width-5 || Input.GetKey(KeyCode.D)) {
					if (Input.GetKey(KeyCode.LeftShift)) {
						this.transform.Translate(altScrollSpeed, 0, -altScrollSpeed, Space.World);
					}
					else {
						this.transform.Translate(scrollSpeed, 0, -scrollSpeed, Space.World);
					}
				}

				//If mouse is 5 pixels or more from the upper side of the screen or "W" key is pressed,
				//the camera moves in that direction at scrollSpeed or at altScrollSpeed if "SHIFT" key is also pressed
				if (mousePos.y>Screen.height-5 || Input.GetKey(KeyCode.W)) {
					if (Input.GetKey(KeyCode.LeftShift)) {
						this.transform.Translate(altScrollSpeed, 0, altScrollSpeed, Space.World);
					}
					else {
						this.transform.Translate(scrollSpeed, 0, scrollSpeed, Space.World);

					}
				}

				//If mouse is 5 pixels or less from the bottom side of the screen or "S" key is pressed,
				//the camera moves in that direction at scrollSpeed or at altScrollSpeed if "SHIFT" key is also pressed
				if (mousePos.y<5 || Input.GetKey(KeyCode.S)) {
					if (Input.GetKey(KeyCode.LeftShift)) {
						this.transform.Translate(-altScrollSpeed, 0, -altScrollSpeed, Space.World);
					}
					else {
						this.transform.Translate(-scrollSpeed, 0, -scrollSpeed, Space.World);
					}
				}
			}
		}

		/// <summary>
		/// Checks wheter the camera is outside the minimum or maximum zoom proximity value
		/// </summary>
		void CheckCameraZoom() {
			if (MainCamera.orthographicSize<=1) {
				MainCamera.orthographicSize=2;
			}
			else if (MainCamera.orthographicSize>=40) {
				MainCamera.orthographicSize=40;
			}
		}
	}
}