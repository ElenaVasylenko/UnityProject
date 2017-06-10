﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour {

	int coins = 0;
	int fruits = 0;
	int totalFruits = 10;
	int null_nums = 4;//number of nulls in coins counter 0000

	public int crystals_num = 0;
	public bool blue_gem = false;
	public bool red_gem = false;
	public bool green_gem = false;

	static int saved_coins = 0;
	public static bool sound_on = true;
	public static bool music_on = true;

	public UILabel coinsLabel;
	public UILabel fruitsLabel;
	public GameObject failPrefab;

	public GameObject heart1;
	public GameObject heart2;
	public GameObject heart3;

	public GameObject gem1; //blue
	public GameObject gem2; //red
	public GameObject gem3; //green

	public static LevelController current;

	void Awake() {
		current = this;
	}

	void Start(){
		addCoins (0); //to initialize label text with right number format
		this.coins = saved_coins;
	}
	Vector3 startingPosition;
	public void setStartPosition(Vector3 pos) {
		this.startingPosition = pos;

	}
	public void onRabitDeath(HeroRabbit rabit) {
		//При смерті кролика повертаємо на початкову позицію
		//restore health
		rabit.transform.position = this.startingPosition;

		Debug.Log("Health: " + rabit.CurrentHealth);
		if(rabit.CurrentHealth == 2)
			heart1.SetActive(false);

		if(rabit.CurrentHealth == 1)
			heart2.SetActive(false);

		if (rabit.CurrentHealth == 0) {
			heart3.SetActive (false);
			Debug.Log("Failed!!!!!!!!!!");

			StartCoroutine (failLevel());
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

	public IEnumerator failLevel() {
		yield return new WaitForSeconds (2f);
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

		Debug.Log ("coins collected: " + n);
	}

	public void addFruits(int n){
		fruits += n;
		fruitsLabel.text = fruits + " / " + totalFruits;

		Debug.Log ("fruits collected: " + n);
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
