using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPopUp : MonoBehaviour {
	
	public MyButton menu;
	public MyButton repeat;
	public MyButton close;
	public MyButton background;

	public UILabel coinsLabel;
	public UILabel fruitsLabel;

	public GameObject gem1; //red
	public GameObject gem2; //blue
	public GameObject gem3; //green


	//public UnityEvent signalOnClick = new UnityEvent();

	// Use this for initialization
	void Start () {
		Time.timeScale = 0; //stop this world
		Debug.Log ("close!!!!!!!!!!!!");
		close.signalOnClick.AddListener (this.closePanel);
		background.signalOnClick.AddListener(this.closePanel);

		menu.signalOnClick.AddListener (this.goToMenu);
		repeat.signalOnClick.AddListener (this.repeatLevel);
		coinsLabel.text = LevelController.current.getCoinsLabel();
		fruitsLabel.text = LevelController.current.getFruitsLabel();
		showCrystals ();
	}

	// Update is called once per frame
	void Update () {
	}

	void showCrystals(){
			
			if(LevelController.current.blue_gem == false)
				gem2.SetActive (false);

			if(LevelController.current.red_gem == false)
				gem1.SetActive (false);

			if(LevelController.current.green_gem == false)
				gem3.SetActive (false);
	}

	void closePanel() {
		SceneManager.LoadScene("MainMenu");
	}
		
	void goToMenu() {
		SceneManager.LoadScene("MainMenu");
	}

	void repeatLevel() {
		SceneManager.LoadScene ("Level2");
		//LevelController.setSound (false);
	}
}
