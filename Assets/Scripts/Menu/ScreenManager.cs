using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace FATEC.CubeWars.Menu {
	public class ScreenManager : MonoBehaviour {
		public static int page=0;
		public Canvas main;
		public Canvas page1;
		public Canvas page2;
		public Canvas page3;
		public Canvas page4;
		public Canvas page5;

		void Start() {
			page=0;
		}
	
		// Update is called once per frame
		void Update() {
			Disable();
			if (page==0)
				main.enabled=true;
			if (page==1)
				page1.enabled=true;
			if (page==2)
				page2.enabled=true;
			if (page==3)
				page3.enabled=true;
			if (page==4)
				page4.enabled=true;
			if (page==5)
				page5.enabled=true;
		}

		protected void Disable() {
			main.enabled=false;
			page1.enabled=false;
			page2.enabled=false;
			page3.enabled=false;
			page4.enabled=false;
			page5.enabled=false;
		}

		public void Next() {
			if (page<5) {
				page++;
			}
		}

		public void Prev() {
			if (page>0) {
				page--;
			}
		}
	}
}