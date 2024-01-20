using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace FATEC.CubeWars.Menu {
				public class Pause : MonoBehaviour {
								public Button exitButton;
								public Button pauseButton;
								public static bool isPaused = false;
								public Canvas PauseMenu;


								// Use this for initialization
								public void Start() {
												PauseMenu.enabled=false;
												exitButton=exitButton.GetComponent<Button>();
												pauseButton=pauseButton.GetComponent<Button>();
								}

								// Update is called once per frame
								protected void Update() {
												if(Input.GetKeyDown(KeyCode.Escape)) {
																PauseGame();
												}
								}

								public void PauseGame() {
												if (isPaused==false) {
																Time.timeScale=0;
																isPaused=true;
																PauseMenu.enabled=true;
												}
												else {
																Time.timeScale=1;
																isPaused=false;
																PauseMenu.enabled=false;
												}

								}

								public void MainMenu() {
												SceneManager.LoadScene("Start");
												Time.timeScale=1;
												isPaused=false;
								}
				}
}