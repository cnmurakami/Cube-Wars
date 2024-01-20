using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using FATEC.CubeWars.Menu;


namespace FATEC.CubeWars.Behaviours {
	/// <summary>
	/// Stores Player coins and creates Player units
	/// </summary>

	public class PlayerBase : BaseBehaviour {
		public static int PlayerCoin;
		public static int MaximumCoin;
		public GameObject soldier;
		public GameObject tank;
		public GameObject metalGear;
		public Text coinBoard;
		public float distance=1000.0f;
		public Canvas SpawnPanel;
		private int PanelEnabled;
		public string Cost;
		public int timer;
		private int newCoin;

		/// <summary>
		/// Starts the Coin board and gives the Player initial coins
		/// </summary>
		void Start() {
			PanelEnabled=1;
			PlayerCoin=30;
			MaximumCoin=100;
			timer=0;
			coinBoard.text="Coins: "+PlayerCoin.ToString();
			TogglePanel();
			Cost="";
		}

		/// <summary>
		/// Detects if the player wants to create a new unit and checks if it is possible
		/// Also updates the UI
		/// </summary>
		void Update() {
			if (Pause.isPaused==false) {
				timer++;
				if (PlayerCoin>MaximumCoin) {
					PlayerCoin=MaximumCoin;
					Cost="   Coin pocket FULL!";
					timer=0;
				}
				coinBoard.text="Coins:                          "+PlayerCoin.ToString()+" "+Cost.ToString();
				if (Input.GetMouseButtonDown(0)) {
					var ray=Camera.main.ScreenPointToRay(Input.mousePosition);
					RaycastHit hit;
					if (Physics.Raycast(ray, out hit, this.distance)) {
						if (hit.collider==this.GetComponent<BoxCollider>()) {
							TogglePanel();
						}
						else if (hit.transform.gameObject.name==("Soldier1UI")) {
							Spawn(3, soldier);
						}
						else if (hit.transform.gameObject.name==("Soldier2UI")) {
							Spawn(7, tank);
						}
						else if (hit.transform.gameObject.name==("Soldier3UI")) {
							Spawn(15, metalGear);
						}
						else {
							if (PanelEnabled==1) {
								TogglePanel();
							}
						}
					}
				}
				if (timer>=60) {
					Cost="";
					timer=0;
				}
			}
		}

		/// <summary>
		/// Spawns a unit
		/// </summary>
		/// <param name="spawnCost"> Necessary coins to create a unit </param>
		/// <param name="unit"> Unit to be created (as of now, can be 'soldier', 'tank' or 'metalGear' </param>
		void Spawn(int spawnCost, UnityEngine.GameObject unit) {
			if (PlayerCoin>=spawnCost && UnitCount.playerUnits<UnitCount.maxUnits) {
				PlayerCoin-=spawnCost;
				Cost="  Unit cost: -"+spawnCost;
				timer=0;
				//Get the position of this to generate a radius to spawn
				Vector3 center=transform.position;
				Vector3 pos=RandomCircle(center, 5.0f);
				//Spawn the object
				GameObject tempPrefab=Instantiate(unit) as GameObject;
				tempPrefab.transform.position=pos;
			}
			else if (PlayerCoin<=spawnCost) {
				Cost="   Insuficient Coins!";
				timer=0;
			}
			else {
				Cost="   Max Units On Field Reached!";
				timer=0;
			}
		}

		/// <summary>
		/// Creates a random point inside a given radius. Note that Y axis will always be equal to the center
		/// </summary>
		/// <param name="center"> The transform position of this </param>
		/// <param name="radius"> The desired radius around this</param>
		/// <returns>(pos.x, pos.y, pos.z)</returns>
		Vector3 RandomCircle(Vector3 center, float radius) {
			float ang=Random.value*360;
			Vector3 pos;
			pos.x=center.x+radius*Mathf.Sin(ang*Mathf.Deg2Rad);
			pos.y=center.y;
			pos.z=center.z+radius*Mathf.Cos(ang*Mathf.Deg2Rad);
			return pos;
		}

		void TogglePanel() {
			PanelEnabled*=-1;
			SpawnPanel.enabled=!SpawnPanel.enabled;
			foreach (MeshRenderer r in SpawnPanel.GetComponentsInChildren<MeshRenderer>()) {
				r.enabled=!r.enabled;
			}

			foreach (SphereCollider r in SpawnPanel.GetComponentsInChildren<SphereCollider>()) {
				if (r.GetComponent<SphereCollider>()!=null) {
					r.GetComponent<SphereCollider>().enabled=!r.GetComponent<SphereCollider>().enabled;
				}
			}
		}
	}
}