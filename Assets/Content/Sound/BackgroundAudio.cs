using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAudio : MonoBehaviour {
	
	public AudioClip music = null;
	AudioSource musicSource = null;

	void Start() {
		musicSource = gameObject.AddComponent<AudioSource>();
		musicSource.clip = music;
		musicSource.loop = true;
		musicSource.Play ();
	}
}
