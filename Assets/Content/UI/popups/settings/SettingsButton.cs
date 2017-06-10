using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SettingsButton : MonoBehaviour {
	
	public UnityEvent signalOnClick = new UnityEvent();
	//public MyButton settingsBtn;
	public GameObject settingsPrefab;

	// Use this for initialization
	void Start () {
		signalOnClick.AddListener (this.showSettings);
	}

	public void _onClick() {
		this.signalOnClick.Invoke ();
	}

	void showSettings() {
		GameObject parent = UICamera.first.transform.parent.gameObject;
		//Створити Prefab
		GameObject obj = NGUITools.AddChild (parent, settingsPrefab);
		//Отримати доступ до компоненту (щоб передати параметри)
		SettingsPopUp popup = obj.GetComponent<SettingsPopUp>();
		//...
	}
	// Update is called once per frame
	void Update () {
		
	}
}
