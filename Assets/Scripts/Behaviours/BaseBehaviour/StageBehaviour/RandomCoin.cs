using UnityEngine;
using System.Collections;

namespace FATEC.CubeWars.Behaviours {
	public class RandomCoin : MonoBehaviour {
		public GameObject coin;
		public Canvas CoinShow;
		private int time=0;
		int release;

		// Use this for initialization
		void Start() {
			release=Random.Range(1800, 3600);
		}
		
		// Update is called once per frame
		void FixedUpdate() {
			var hasCoin=GameObject.FindGameObjectWithTag("Coin");
			if (hasCoin==null) {
				Toggle(false);
			}
			else {
				Toggle(true);
			}
			time++;
			if (time>=release) {
				int chance=Random.Range(0, 1000);
				if (chance>=950) {
					GameObject.Instantiate(coin);// as GameObject;
					Warning.msgDetect=true;
					Warning.msg="A SUPER COIN APPEARED!";
					Warning.col=Color.green;
					Warning.count=0;
					release=Random.Range(1800, 3600);
					time=0;
				}
			}
		}

		void Toggle(bool c) {
			CoinShow.enabled=c;
			foreach (MeshRenderer r in CoinShow.GetComponentsInChildren<MeshRenderer>()) {
				r.enabled=c;
			}
		}
	}
}