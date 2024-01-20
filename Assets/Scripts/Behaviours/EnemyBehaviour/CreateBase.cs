using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace FATEC.CubeWars.Behaviours {
	public class CreateBase : MonoBehaviour {
		private int choice1;
		private int choice2;
		private int choice3;
		public GameObject baseB;

		public static int baseVal=2;
		// Use this for initialization
		void Start() {
			choice1=Random.Range(1, 11);
			choice2=Random.Range(1, 11);
			while (choice2==choice1) {
				choice2=Random.Range(1, 11);
			}
			choice3=Random.Range(1, 11);
			while (choice3==choice2 || choice3==choice1) {
				choice3=Random.Range(1, 11);
			}
			Spawn(choice1);
			Spawn(choice2);
			Spawn(choice3);
		}
	
		// Update is called once per frame
		void Update() {
			var bases=GameObject.FindGameObjectWithTag("EnemyBase");
			if (bases==null) {
				SceneManager.LoadScene("Win");
			}
		}

		void Spawn(int c) {
			GameObject tempPrefab=Instantiate(baseB) as GameObject;
			switch (c) {
				case 1:
					tempPrefab.transform.position=new Vector3(100.05f, 0, -99.89f);
					break;
				case 2:
					tempPrefab.transform.position=new Vector3(105.5f, 0, -45.5f);
					break;
				case 3:
					tempPrefab.transform.position=new Vector3(105.5f, 0, 15.7f);
					break;
				case 4:
					tempPrefab.transform.position=new Vector3(90.5f, 0, 74.9f);
					break;
				case 5:
					tempPrefab.transform.position=new Vector3(-1f, 0, -86.7f);
					break;
				case 6:
					tempPrefab.transform.position=new Vector3(-60.7f, 0, -104f);
					break;
				case 7:
					tempPrefab.transform.position=new Vector3(-102.7f, 0, -68.8f);
					break;
				case 8:
					tempPrefab.transform.position=new Vector3(-102.7f, 0, -97.7f);
					break;
				case 9:
					tempPrefab.transform.position=new Vector3(49.4f, 0, 85f);
					break;
				case 10:
					tempPrefab.transform.position=new Vector3(88.7f, 0, 79.2f);
					break;
			}
		}
	}
}