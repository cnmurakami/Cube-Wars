using FATEC.CubeWars.Behaviours;
using FATEC.CubeWars.Menu;
using UnityEngine;

namespace FATEC.CubeWars.Behaviours {
	/// <summary>
	/// Select player's NavMesh agents by clicking on them and gives the ability to move them
	/// </summary>
	public class SelectAndMove : MonoBehaviour {
		[Tooltip("Agent to be moved.")]
		public NavMeshAgent agent;
		[Tooltip("Ground tag.")]
		public string groundTag="Ground";
		[Tooltip("Raycast distance.")]
		public float distance=1000.0f;

		/// Color to be changed when the unit is selected
		protected Color sCol=new Vector4(0.125f, 0.773f, 0.827f, 1);
		/// Color to be changed when the unit is descelected
		protected Color nCol=new Vector4(0.161f, 0.196f, 0.573f, 1);

		/// Saves mouse position for selection box
		protected static Vector3 checkBox;

		protected static bool isActive=false;

		/// Sets the object as selected to be moved
		protected bool selected=false;

		private Vector3 camPos;


		/// <summary>
		/// Objects can be selected with left click (left control to select multiples objects) or by click and drag to draw a selection box and moved with right click
		/// </summary>
		protected void Update() {
			if (Pause.isPaused==false) {
				if (Input.GetMouseButton(1)) {
					var ray=Camera.main.ScreenPointToRay(Input.mousePosition);
					RaycastHit hit;
					if (Physics.Raycast(ray, out hit, this.distance)) {
						///If the right clicked space is the ground and the player has a unit selected, it will move towards point
						if (Input.GetMouseButtonDown(1) && hit.collider.CompareTag(this.groundTag) && this.selected==true) {
							this.agent.SetDestination(hit.point);
						}
						if (Input.GetMouseButton(1) && hit.collider.CompareTag(this.groundTag) && this.selected==true) {
							this.agent.SetDestination(hit.point);
						}
					}
				}
				///Manages the selection and movement with a mouse click
				if (Input.GetMouseButton(0) && !((Input.mousePosition.x>(Screen.width-(Screen.width/100*30))) && (Input.mousePosition.y<(Screen.height/100*30)))) {
					var ray=Camera.main.ScreenPointToRay(Input.mousePosition);
					RaycastHit hit;
					if (Physics.Raycast(ray, out hit, this.distance)) {
						if (Input.GetMouseButtonDown(0)) {

							///If the player left click a unit and left ctrl is not pressed, or left click the base, every unit will be deselected
							if ((!Input.GetKey(KeyCode.LeftControl) && hit.collider.CompareTag("Player")) || hit.collider.CompareTag("PlayerBase")) {
								selected=false;
							}
							///Checks if the left mouse clicked on the unit and change its selection state
							if (hit.collider==this.gameObject.GetComponent<BoxCollider>()) {
								if (Input.GetKey(KeyCode.LeftControl)) {
									this.selected=!selected;
								}
								else {
									this.selected=true;
								}
							}
						}
					}

				}
				Box();
				checkSelection();
			}
		}

		/// <summary>
		/// Function to change the unit color
		/// </summary>
		/// <param name="Color to be changed to"></param>
		void ChangeColor(Vector4 col) {
			foreach (Renderer r in GetComponentsInChildren<Renderer>()) {
				r.material.color=col;
			}
		}

		/// <summary>
		/// Changes the unit color based on its select value
		/// </summary>
		void checkSelection() {
			if (this.selected==true) {
				ChangeColor(sCol);
			}
			if (this.selected==false) {
				ChangeColor(nCol);
			}
			
		}

		void Box() {
			/////////////////////////////////////////////////////////////
			///Manages selection within box selection
			if (Input.GetMouseButton(0)) {
				
				if (Input.GetMouseButtonDown(0) && !((Input.mousePosition.x>(Screen.width-(Screen.width/100*30))) && (Input.mousePosition.y<(Screen.height/100*30)))) {
					checkBox=Input.mousePosition;
					isActive=true;
				}
				if (isActive==true && (Input.mousePosition.x>(checkBox.x+50) || Input.mousePosition.x<(checkBox.x-50) ||
				    Input.mousePosition.y>(checkBox.y+50) || Input.mousePosition.y<(checkBox.y-50))) {
					
					if (Input.GetMouseButton(0) && !Input.GetKey(KeyCode.LeftControl)) {
						selected=false;
						checkSelectionBox();
						this.selected=BoxSelection.selection.Contains(camPos);
					}
					if (Input.GetMouseButton(0) && Input.GetKey(KeyCode.LeftControl)) {
						checkSelectionBox();
						if (this.selected==false) {
							this.selected=BoxSelection.selection.Contains(camPos);
						}
					}
				}
			}
			if (!Input.GetMouseButton(0)) {
				isActive=false;
			}
			////////////////////////////////////////////////////////////
		}

		/// <summary>
		/// Checks the box selection position
		/// </summary>
		private Vector3 checkSelectionBox() {
			camPos=Camera.main.WorldToScreenPoint(transform.position);
			camPos.y=BoxSelection.InvertMouseY(camPos.y);
			return camPos;
		}
	}
}