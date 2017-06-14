using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FailPopUp : MonoBehaviour {

	public MyButton menu;
	public MyButton repeat;
	public MyButton close;
	public MyButton background;
	Scene current;
	string scene_name;
	//Scene current = SceneManager.GetActiveScene;
	//public UnityEvent signalOnClick = new UnityEvent();

	// Use this for initialization
	void Start () {
		//Time.timeScale = 0; //stop this world
		//scene_name = current.name;
		current = SceneManager.GetActiveScene();
		Debug.Log ("close!!!!!!!!!!!!");
		close.signalOnClick.AddListener (this.closePanel);
		background.signalOnClick.AddListener(this.closePanel);

		menu.signalOnClick.AddListener (this.goToMenu);
		repeat.signalOnClick.AddListener (this.repeatLevel);

	}

	// Update is called once per frame
	void Update () {
	}

	void closePanel() {
		Debug.Log ("Destroy!!!");
		//Destroy (this.gameObject);
		SceneManager.LoadScene("MainMenu");
	}

	void goToMenu() {
		Debug.Log ("to menu!!!!");
		SceneManager.LoadScene("MainMenu");
	}

	void repeatLevel() {
		Debug.Log ("repeat!!!!");
		SceneManager.LoadScene (current.name);
		//LevelController.setSound (false);
	}
}
