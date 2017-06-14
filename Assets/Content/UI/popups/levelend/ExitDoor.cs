using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour {

	public GameObject winPrefab;

	void OnTriggerEnter2D(Collider2D collider) {
		Debug.Log("Exit door!!!!!!!!!!!!!!!!!!!!!!!!!!");
		HeroRabbit rabit = collider.GetComponent<HeroRabbit>();
		if(rabit != null) {
			winWindow (rabit);
			//this.OnRabitHit (rabit); ........
		}
	}

	void winWindow(HeroRabbit rabbit) {
		
		GameObject parent = UICamera.first.transform.parent.gameObject;
		//Створити Prefab
		GameObject obj = NGUITools.AddChild (parent, winPrefab);
		//Отримати доступ до компоненту (щоб передати параметри)
		WinPopUp popup = obj.GetComponent<WinPopUp>(); //???
		rabbit.winTune();
		//...
	}
}
