using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playing : MonoBehaviour {

	public StartButton playButton;

	void Start () {
		playButton.signalOnClick.AddListener (this.onPlay);
	}
	void onPlay() {
		SceneManager.LoadScene ("LevelChoose");
	}
}
