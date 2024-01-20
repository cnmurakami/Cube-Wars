using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

namespace FATEC.CubeWars.Menu {
	public class InstructionsScreen : MonoBehaviour {
		public Button nextButton;
		public Button prevButton;
		public Button startButton;
		public Button backButton;

		void Start() {
			nextButton=nextButton.GetComponent<Button>();
			prevButton=prevButton.GetComponent<Button>();
			backButton=backButton.GetComponent<Button>();
			backButton=backButton.GetComponent<Button>();
		}
	
		// Update is called once per frame
		public void Next() {
			ScreenManager.page++;
		}

		public void Prev() {
			ScreenManager.page--;
		}

		public void StartGame() {
			SceneManager.LoadScene("Stage");
		}

		public void Back() {
			ScreenManager.page=0;
			SceneManager.LoadScene("Start");
		}

	}
}