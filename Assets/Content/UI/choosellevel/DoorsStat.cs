using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsStat : MonoBehaviour {

	public GameObject gem;
	public GameObject levelPassed;
	public GameObject fruit;

	public string SceneName;

	// Use this for initialization
	void Start () {
		gemsStat ();
		doorStat ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void gemsStat(){
		if (SceneName.Equals( "Level2")) {
			
			//Debug.Log ("Scene lev 2!!!!!!!!!!!! ,lev 1: "+PlayerPrefs.GetInt ("Level1"));
			if (PlayerPrefs.GetInt ("gem2") == 1) {
				Debug.Log ("GEMS STAT1");
				gem.SetActive (false);
			}


			} if (SceneName.Equals( "Level1")) {
			if (PlayerPrefs.GetInt ("gem1") == 1) {
				Debug.Log ("GEMS STAT");
				gem.SetActive (false);
			}
			}
	}


	public void doorStat(){
		if (SceneName.Equals( "Level1")) {
			Debug.Log ("door1 zzzzzzzzzzzzzzzzzzzzzzzzz");
			//Debug.Log ("Scene lev 2!!!!!!!!!!!! ,lev 1: "+PlayerPrefs.GetInt ("Level1"));
			if (PlayerPrefs.GetInt ("Level1") == 1) {
				Debug.Log ("door1 STAT");
				levelPassed.SetActive (false);
			}


		} if (SceneName.Equals( "Level2")) {
			if (PlayerPrefs.GetInt ("Level2") == 1) {
				Debug.Log ("door2 STAT");
				levelPassed.SetActive (false);
			}
		}
	}
}
