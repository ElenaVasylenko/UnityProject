using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAudio : MonoBehaviour {
	
	public AudioClip music = null;
	AudioSource musicSource = null;

	public static BackgroundAudio current;

	void Awake() {
		current = this;
	}

	void Start() {
		if (LevelController.current.music_on) {
			musicSource = gameObject.AddComponent<AudioSource> ();
			musicSource.clip = music;
			musicSource.loop = true;
			musicSource.Play ();
		}
	}
		
	public void musicStop(){
			musicSource.Stop ();
		}

	public void musicStart(){
		musicSource.Play ();
	}

}
