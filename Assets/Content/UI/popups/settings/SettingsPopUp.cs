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

		if (LevelController.current.sound_on == false ) {
			sound.GetComponent<UI2DSprite> ().sprite2D = soundOff;
			sound.GetComponent<UIButton> ().normalSprite2D = soundOff;
		}

		if (LevelController.current.music_on == false ) {
			music.GetComponent<UI2DSprite> ().sprite2D = musicOff;
			music.GetComponent<UIButton> ().normalSprite2D = musicOff;
			BackgroundAudio.current.musicStop ();
		}

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
		if (LevelController.current.sound_on) {
			sound.GetComponent<UI2DSprite> ().sprite2D = soundOff;
			sound.GetComponent<UIButton> ().normalSprite2D = soundOff;
			LevelController.current.sound_on = false;
			//SoundManager.Instance.setSoundOn (false);
		} else {
			sound.GetComponent<UI2DSprite> ().sprite2D = soundOn;
			sound.GetComponent<UIButton> ().normalSprite2D = soundOn;
			LevelController.current.sound_on = true;
			//SoundManager.Instance.setSoundOn (true);
		}
		//LevelController.setSound (false);
	}

	void OffMyMusic() {
		Debug.Log ("Change m!!!!");
		if (LevelController.current.music_on) {
			music.GetComponent<UI2DSprite> ().sprite2D = musicOff;
			music.GetComponent<UIButton> ().normalSprite2D = musicOff;
			LevelController.current.music_on = false;
			BackgroundAudio.current.musicStop ();
		} else {
			music.GetComponent<UI2DSprite> ().sprite2D = musicOn;
			music.GetComponent<UIButton> ().normalSprite2D = musicOn;
			LevelController.current.music_on = true;
			BackgroundAudio.current.musicStart ();
		}
		//LevelController.setSound (false);
	}
}
