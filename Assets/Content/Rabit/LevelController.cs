﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {
	
	public static LevelController current;
	void Awake() {
		current = this;
	}

	Vector3 startingPosition;
	public void setStartPosition(Vector3 pos) {
		this.startingPosition = pos;
	}
	public void onRabitDeath(HeroRabbit rabit) {
		//При смерті кролика повертаємо на початкову позицію
		rabit.transform.position = this.startingPosition;
	}

	public void addCoins(int n){
		Debug.Log ("coins collected: " + n);
	}

	public void addFruits(int n){
		Debug.Log ("fruits collected: " + n);
	}

	public void addCrystals(int n){
		Debug.Log ("crystals collected: " + n);
	}

	public void oopsMushroom(int n){
		Debug.Log ("mushroom catched: " + n);
	}

}
