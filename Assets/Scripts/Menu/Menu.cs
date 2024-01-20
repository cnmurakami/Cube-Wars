using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace FATEC.CubeWars.Menu {
	public class Menu : MonoBehaviour {
		public Button startButton;
		public Button InstButton;
		public Button exitButton;


		// Use this for initialization
		public void Start() {
			startButton=startButton.GetComponent<Button>();
			InstButton=InstButton.GetComponent<Button>();
			exitButton=exitButton.GetComponent<Button>();
		}

		// Update is called once per frame
		public void StartGame() {
			SceneManager.LoadScene("Stage");
		}

		public void ExitGame() {
			Application.Quit();
		}

		public void MainMenu() {
			SceneManager.LoadScene("Start");
		}

		public void InstMenu() {
			ScreenManager.page=1;
		}
	}
}