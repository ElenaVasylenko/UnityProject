using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SettingsPopUp : MonoBehaviour {

	public MyButton sound;
	public MyButton music;
	public CloseButton close;
	public CloseButton background;

	public Sprite soundOn;
	public Sprite soundOff;
	public Sprite musicOn;
	public Sprite musicOff;

	//public UnityEvent signalOnClick = new UnityEvent();

	// Use this for initialization
	void Start () {
		Debug.Log ("close!!!!!!!!!!!!");
		close.signalOnClick.AddListener (this.closePanel);
		background.signalOnClick.AddListener(this.closePanel);

		sound.signalOnClick.AddListener (this.OffMySound);
		//music.signalOnClick.AddListener (this.OffMusic());

	}

	// Update is called once per frame
	void Update () {
	}

	void closePanel() {
		Debug.Log ("Destroy!!!");

		//Time.timeScale = SettingsBtn.time;
		Destroy (this.gameObject);
	}
		


	void OffMySound() {
		Debug.Log ("Change!!!!");
		sound.GetComponent<UI2DSprite> ().sprite2D = soundOff;
		sound.GetComponent<UIButton> ().normalSprite2D = soundOff;
		//LevelController.setSound (false);
	}
}
