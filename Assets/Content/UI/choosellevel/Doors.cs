using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Doors : MonoBehaviour {


	public string SceneName;


	void OnTriggerEnter2D(Collider2D other){
		if (SceneName.Equals( "Level2")) {
			Debug.Log ("Scene lev 2!!!!!!!!!!!! ,lev 1: "+PlayerPrefs.GetInt ("Level1"));
			if (PlayerPrefs.GetInt ("Level1") == 1) {
				SceneManager.LoadScene (SceneName);

			}
		} else {
			Debug.Log ("Scene lev 1!!!!!!!!!!!!");
			SceneManager.LoadScene (SceneName);
		}
	}

	/*// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}*/
}
