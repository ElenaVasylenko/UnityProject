using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour {
	
	private LevelStat stats = null;

	public int coins = 0;
	public int fruits = 0;
	public int totalFruits = 10;
	int null_nums = 4; //current of nulls currents counter 0000

	public int crystals_num = 0;
	public bool blue_gem = false;
	public bool red_gem = false;
	public bool green_gem = false;

	static int saved_coins = 0;
	static int allcurrent;
	public bool sound_on ;
	public bool music_on ;

	public bool hasCrystals;
	public bool hasAllFruits;
	public static int levelPassed = 0;

	public static int gemsLev1 = 0;
	public static int gemsLev2 = 0;

	public UILabel coinsLabel;
	public UILabel fruitsLabel;
	public GameObject failPrefab;

	public GameObject heart1;
	public GameObject heart2;
	public GameObject heart3;

	public GameObject gem1; //blue
	public GameObject gem2; //red
	public GameObject gem3; //green

	Scene scene;
	string scene_name ;

	int health = 3;

	public static LevelController current;

	void Awake() {
		current = this;
	}

	void Start(){
		scene = SceneManager.GetActiveScene ();
		scene_name = scene.name;
		sound_on = true;
		music_on = true;
		saved_coins = PlayerPrefs.GetInt("coins", 0);
		//PlayerPrefs.SetInt("Level1",0); // Обнуляємо попередню історію про пройденість рівня
		PlayerPrefs.GetInt(scene_name,0);
		PlayerPrefs.GetInt("gem1");
		PlayerPrefs.GetInt("gem2");
		Debug.Log ("GEEEEEEEEEEEEEEEM1!!!!!! "+PlayerPrefs.GetInt ("gem1"));
		Debug.Log ("GEEEEEEEEEEEEEEEM2!!!!!! "+PlayerPrefs.GetInt ("gem2"));
		//levelPassed = PlayerPrefs.GetInt(scene_name,0);
		//Debug.Log ("LEVEL PASSED??????? "+levelPassed);
		addCoins (0); //to initialize label text with right number format
		this.coins = saved_coins;
	}

	Vector3 startingPosition;

	public void setStartPosition(Vector3 pos) {
		this.startingPosition = pos;

	}

	public void onRabitDeath(HeroRabbit rabit) {
		//При currentкролика повертаємо на початкову позицію
		//restore health
		rabit.transform.position = this.startingPosition;
		health--;

		Debug.Log("Health: " + rabit.CurrentHealth);
		if(rabit.CurrentHealth == 2)
			heart1.SetActive(false);

		if(rabit.CurrentHealth == 1)
			heart2.SetActive(false);

		if (rabit.CurrentHealth == 0) {
			heart1.SetActive(false);
			heart2.SetActive(false);
			heart3.SetActive (false);
			Debug.Log("Failed!!!!!!!!!!");

			StartCoroutine (failLevel(rabit));
			//SceneManager.LoadScene("LevelChoose");
			//rabit.CurrentHealth = 3;

		}
	}
	public string getCoinsLabel(){
		return coinsLabel.text;
	} 

	public string getFruitsLabel(){
		return fruitsLabel.text;
	} 

	public void saveLevelPassed(){
		if (scene_name.Equals ("Level1")) {
			Debug.Log ("save scene 1!!!!!!!!!!!");
			PlayerPrefs.SetInt ("Level1", 1);
		}
		if (scene_name.Equals ("Level2")) {
			Debug.Log ("save scene 2!!!!!!!!!!!");
			PlayerPrefs.SetInt ("Level2", 1);
		}
		PlayerPrefs.Save ();
	} 

	public void saveGems(){
		Debug.Log ("SAVE CRYSTALS!!!!!!!!!!!! "+crystals_num);
		if (scene_name.Equals ("Level1") && crystals_num >= 3) {
			Debug.Log ("save gems 1 !!!!!!!!!!!");
			PlayerPrefs.SetInt ("gem1", 1);
		}
		if (scene_name.Equals ("Level2") && crystals_num >= 3) {
			Debug.Log ("save gems 2!!!!!!!!!!!");
			PlayerPrefs.SetInt ("gem2", 1);
		}
		PlayerPrefs.Save ();
	} 

	public IEnumerator failLevel(HeroRabbit rabbit) {
		rabbit.failTune ();
		yield return new WaitForSeconds (1f);
		//Знайти батьківський елемент
		GameObject parent = UICamera.first.transform.parent.gameObject;
		//	GameObject parent = UICamera.first.transform.SetParent(gameObject);
		//Створити Prefab
		GameObject obj = NGUITools.AddChild (parent, failPrefab);
		//Отримати доступ до компоненту (щоб передати параметри)
		obj.GetComponent<FailPopUp>();
	}
		
	public void addCoins(int n){
		crystals_num += 1;

		this.coins += n;
		saved_coins += n;

		string c = "" + saved_coins;
		string coins_counter = "";

		int gaps = null_nums - c.Length;
		Debug.Log (gaps);

		for(int i= 0; i < gaps; i++){
			coins_counter = coins_counter+"0";
		}

		coins_counter += "" + saved_coins;
		coinsLabel.text = coins_counter;
		PlayerPrefs.SetInt ("coins", saved_coins);
		PlayerPrefs.Save ();
		Debug.Log ("coins collected: " + n);
	}

	public void addFruits(int n){
		fruits += n;
		fruitsLabel.text = fruits + " / " + totalFruits;

		Debug.Log ("fruits collected: " + n);
	}

	//LIFES 7 HW
	public void addLifes(HeroRabbit rabbit){
		
		if (rabbit.CurrentHealth < 3) {
			rabbit.CurrentHealth++;
			if (!heart1.activeInHierarchy)
				heart1.SetActive (true);
			else {
				heart2.SetActive (true);
				}
		}
	}

	public void addCrystals(int n){
		
		if (n == 1) {
			gem1.SetActive (false);
			blue_gem = true;
		}

		if (n == 2) {
			gem2.SetActive (false);
			red_gem = true;
		}

		if (n == 3) {
			gem3.SetActive (false);
			green_gem = true;
		}

		crystals_num++;
		Debug.Log ("crystals collected: " + n);
	}

	public void oopsMushroom(int n){
		Debug.Log ("oops mushroom catched: " + n);
	}

	public void oopsBomb(int n){
		Debug.Log ("oops bomb catched: " + n);
	}

}
