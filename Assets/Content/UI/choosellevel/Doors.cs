﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Doors : MonoBehaviour {


	public string SceneName;

	void OnTriggerEnter2D(Collider2D other){
		       SceneManager.LoadScene(SceneName);
		}

	/*// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}*/
}