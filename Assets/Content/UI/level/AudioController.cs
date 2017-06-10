using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {

	public AudioClip runSound = null;
	public AudioClip groundSound = null;
	public AudioClip dieSound = null;
	public AudioClip crystalSound = null;
	public AudioClip coinSound = null;
	public AudioClip mushroomSound = null;
	public AudioClip fruitSound = null;
	public AudioClip bombSound = null;

	AudioSource runSource = null;
	AudioSource groundSource = null;
	AudioSource dieSource = null;
	AudioSource crystalSource = null;
	AudioSource coinSource = null;
	AudioSource mushroomSource = null;
	AudioSource fruitSource = null;
	AudioSource bombSource = null;

	// Use this for initialization
	void Start () {
		runSource = gameObject.AddComponent<AudioSource> ();
		runSource.clip = runSound;

		groundSource = gameObject.AddComponent<AudioSource> ();
		groundSource.clip = groundSound;

		dieSource = gameObject.AddComponent<AudioSource> ();
		dieSource.clip = dieSound;

		crystalSource = gameObject.AddComponent<AudioSource> ();
		crystalSource.clip = crystalSound;

		coinSource = gameObject.AddComponent<AudioSource> ();
		coinSource.clip = coinSound;

		mushroomSource = gameObject.AddComponent<AudioSource> ();
		mushroomSource.clip = mushroomSound;

		fruitSource = gameObject.AddComponent<AudioSource> ();
		fruitSource.clip = fruitSound;

		bombSource = gameObject.AddComponent<AudioSource> ();
		bombSource.clip = bombSound;
	}

	public void runTune() {
		runSource.Play ();
	}

	public void groundTune() {
		groundSource.Play ();
	}

	public void coinTune() {
		coinSource.Play ();
	}

	public void fruitTune() {
		fruitSource.Play ();
	}

	public void crystalTune() {
		crystalSource.Play ();
	}

	public void mushroomTune() {
		mushroomSource.Play ();
	}

	public void bombTune() {
		bombSource.Play ();
	}

	public void dieTune() {
		dieSource.Play ();
	}

	// Update is called once per frame
	void Update () {
		
	}
}
