using UnityEngine;
using System.Collections;
using UnityEngine.UI;


namespace FATEC.CubeWars.Behaviours {
	/// <summary>
	/// Warns the player when his base is under attack
	/// </summary>

	public class Warning : BaseBehaviour {
		public Text warningMsg;
		public static int compareDamage;
		public static bool msgDetect;
		public static string msg;
		public static Color col;
		public static int count;
		public Canvas warningPanel;

		void Start() {
			compareDamage=0;
			count=0;
			//warningMsg.text="YOUR BASE IS UNDER ATTACK!";
			warningPanel.enabled=false;
		}

		// Update is called once per frame
		void FixedUpdate() {
			if (msgDetect==true) {
				showMsg(msg, col);
			}
			else if (compareDamage==1) {
				showMsg("YOUR BASE IS UNDER ATTACK!", Color.red);
			}
		}

		void showMsg(string msg, Color col) {
			count++;
			warningMsg.color=col;
			if (count<=120) {
				warningMsg.text=msg;
				warningPanel.enabled=true;
			}
			else {
				count=0;
				msgDetect=false;
				compareDamage=0;
				warningPanel.enabled=false;
			}
		}
	}
}