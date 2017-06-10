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


	bool sound_on = true;
	bool music_on = true;
	//public UnityEvent signalOnClick = new UnityEvent();

	// Use this for initialization
	void Start () {
		Debug.Log ("close!!!!!!!!!!!!");
		close.signalOnClick.AddListener (this.closePanel);
		background.signalOnClick.AddListener(this.closePanel);
		music.signalOnClick.AddListener (this.OffMyMusic);
		sound.signalOnClick.AddListener (this.OffMySound);
	}

	// Update is called once per frame
	void FixedUpdate () {

	
	}

	void closePanel() {
		Debug.Log ("Destroy!!!");

		//Time.timeScale = SettingsBtn.time;
		Destroy (this.gameObject);
	}
		
	void OffMySound() {
		Debug.Log ("Change!!!!");
		if (sound_on) {
			sound.GetComponent<UI2DSprite> ().sprite2D = soundOff;
			sound.GetComponent<UIButton> ().normalSprite2D = soundOff;
			sound_on = false;
		} else {
			sound.GetComponent<UI2DSprite> ().sprite2D = soundOn;
			sound.GetComponent<UIButton> ().normalSprite2D = soundOn;
			sound_on = true;
		}
		//LevelController.setSound (false);
	}

	void OffMyMusic() {
		Debug.Log ("Change m!!!!");
		if (music_on) {
			music.GetComponent<UI2DSprite> ().sprite2D = musicOff;
			music.GetComponent<UIButton> ().normalSprite2D = musicOff;
			music_on = false;
		} else {
			music.GetComponent<UI2DSprite> ().sprite2D = musicOn;
			music.GetComponent<UIButton> ().normalSprite2D = musicOn;
			music_on = true;
		}
		//LevelController.setSound (false);
	}
}
