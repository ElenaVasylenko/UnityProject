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

	private LevelStat stats = null;

	Scene scene;
	string scene_name;

	public int totalCoins = 0;
	//public UnityEvent signalOnClick = new UnityEvent();

	// Use this for initialization
	void Start () {
		//Time.timeScale = 0; //stop this world
		//
		scene = SceneManager.GetActiveScene();
		scene_name = scene.name;
		Debug.Log ("close!!!!!!!!!!!!");
		close.signalOnClick.AddListener (this.closePanel);
		background.signalOnClick.AddListener(this.closePanel);

		menu.signalOnClick.AddListener (this.goToMenu);
		repeat.signalOnClick.AddListener (this.repeatLevel);
		coinsLabel.text = LevelController.current.getCoinsLabel();
		fruitsLabel.text = LevelController.current.getFruitsLabel();
		showCrystals ();
		LevelController.current.saveLevelPassed();
		saveLevelStat ();
	}

	// Update is called once per frame
	void Update () {
	}


	void saveLevelStat(){
		Debug.Log ("Save Stats");
		PlayerPrefs.SetInt("coins", 0);

		totalCoins = LevelController.current.coins;

		Debug.Log (totalCoins + " :coins saved");
		PlayerPrefs.SetInt("coins", totalCoins);
		PlayerPrefs.Save ();

		//Temp
		if (LevelController.current.crystals_num == 3)
			stats.hasCrystals = true;

		if (LevelController.current.fruits == LevelController.current.totalFruits)
			stats.hasAllFruits = true;
		
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
		SceneManager.LoadScene (scene.name);
		//LevelController.setSound (false);
	}
}
