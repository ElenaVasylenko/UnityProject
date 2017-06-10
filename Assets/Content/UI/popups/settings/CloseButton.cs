using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class CloseButton : MonoBehaviour {

	public UnityEvent signalOnClick = new UnityEvent();

	public void _onClick() {
		this.signalOnClick.Invoke ();
	}

	void Start(){
		signalOnClick.AddListener(this.onPlay);
	}

	void onPlay() { 
		Debug.Log ("Destroy!!!");

		//Time.timeScale = SettingsBtn.time;
		Destroy (this.gameObject);
	}

}
