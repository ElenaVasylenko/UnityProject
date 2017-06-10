using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitFail : MonoBehaviour {

	public GameObject failPrefab;

	// Use this for initialization
	//void Start () {
	//	failWindow ();
	//}

	void failWindow() {
		GameObject parent = UICamera.first.transform.parent.gameObject;
		//Створити Prefab
		GameObject obj = NGUITools.AddChild (parent, failPrefab);
		//Отримати доступ до компоненту (щоб передати параметри)
		FailPopUp popup = obj.GetComponent<FailPopUp>(); //???
		//...
	}
}
