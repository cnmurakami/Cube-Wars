using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace FATEC.CubeWars.Behaviours {
	public class UnitCount : MonoBehaviour {

		public static int maxUnits;
		public static int playerUnits;
		public static int enemyUnits;
		public Text unitDisplay;
		// Use this for initialization
		void Start() {
			maxUnits=50;
			unitDisplay.text=playerUnits+"/"+enemyUnits.ToString();
		}
	
		// Update is called once per frame
		void FixedUpdate() {
			var players=GameObject.FindGameObjectsWithTag("Player").Length;
			var enemies=GameObject.FindGameObjectsWithTag("Enemy").Length;
			var bases=GameObject.FindGameObjectsWithTag("EnemyBase").Length;
			playerUnits=players-1;
			enemyUnits=enemies-bases;
			unitDisplay.text=playerUnits+"/"+maxUnits.ToString();
		}
	}
}