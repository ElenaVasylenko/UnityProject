﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroRabbit : MonoBehaviour {

	Transform heroParent = null;

	public float speed = 1;
	//float value = Input.GetAxis("Horizontal");
	Rigidbody2D myBody = null;
	bool isGrounded = false;
	bool JumpActive = false;
	float JumpTime = 0f;
	public float MaxJumpTime = 2f;
	public float JumpSpeed = 2f;
	public bool orcIsDead = false;

	//public bool rabbitIsBig = false;

	//	HEALTH
	public static int MaxHealth = 3;
	public int CurrentHealth = MaxHealth;
	public static HeroRabbit lastRabbit = null;

	AudioController ac;

	//	SOUNDS
	public AudioClip runSound = null;
	public AudioClip groundSound = null;
	public AudioClip dieSound = null;
	public AudioClip crystalSound = null;
	public AudioClip coinSound = null;
	public AudioClip mushroomSound = null;
	public AudioClip fruitSound = null;
	public AudioClip bombSound = null;
	public AudioClip winSound = null;
	public AudioClip failSound = null;

	AudioSource runSource = null;
	AudioSource groundSource = null;
	AudioSource dieSource = null;
	AudioSource crystalSource = null;
	AudioSource coinSource = null;
	AudioSource mushroomSource = null;
	AudioSource fruitSource = null;
	AudioSource bombSource = null;
	AudioSource winSource = null;
	AudioSource failSource = null;

	void Awake() {
		lastRabbit = this;
	}

	void Start(){

		ac = GetComponent<AudioController> ();
		myBody = this.GetComponent<Rigidbody2D>();
		this.heroParent = this.transform.parent;
		LevelController.current.setStartPosition(transform.position);

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

		failSource = gameObject.AddComponent<AudioSource> ();
		failSource.clip = failSound;

		winSource = gameObject.AddComponent<AudioSource> ();
		winSource.clip = winSound;

	}
		
	public void runTune() {
		if(LevelController.current.sound_on)
		runSource.Play ();
	}

	public void groundTune() {
		if(LevelController.current.sound_on)
		groundSource.Play ();
	}

	public void failTune() {
		if(LevelController.current.sound_on)
			failSource.Play ();
	}

	public void winTune() {
		if(LevelController.current.sound_on)
			winSource.Play ();
	}

	public void coinTune() {
		if(LevelController.current.sound_on)
		coinSource.Play ();
	}

	public void fruitTune() {
		if(LevelController.current.sound_on)
		fruitSource.Play ();
	}

	public void crystalTune() {
		if(LevelController.current.sound_on)
		crystalSource.Play ();
	}

	public void mushroomTune() {
		if(LevelController.current.sound_on)
		mushroomSource.Play ();
	}

	public void bombTune() {
		if(LevelController.current.sound_on)
		bombSource.Play ();
	}

	public void dieTune() {
		if(LevelController.current.sound_on)
		dieSource.Play ();
	}

	public void muteSounds(){
		dieSource.Stop ();
		mushroomSource.Stop ();
		bombSource.Stop ();
		crystalSource.Stop ();
		fruitSource.Stop ();
		runSource.Stop ();
		groundSource.Stop ();
	}


	static void MakeChild(Transform obj, Transform my_parent){
		obj.transform.parent = my_parent;
	}

	public void addHealth(int n){
		this.CurrentHealth += n;

		if (this.CurrentHealth > MaxHealth)
			this.CurrentHealth = MaxHealth;

		//this.onHealthChange ();
	}

	public void reduceHealth(int n){
		if (isRabbitBig ()) {
			this.transform.localScale = Vector3.one;
		} else {
			Debug.Log ("REDUCED BY : " + n);
			this.CurrentHealth -= n;

			if (this.CurrentHealth < 0)
				this.CurrentHealth = 0;

			StartCoroutine (ressurection ());
		}
	}

	bool isRabbitBig(){
		return this.transform.localScale == Vector3.one * 2;
	}

	IEnumerator ressurection(){
		
		Animator animator = GetComponent<Animator> ();
		animator.SetBool("die",true);
		this.dieTune ();
		
		yield return new WaitForSeconds (2.0f);
		LevelController.current.onRabitDeath (this);
		animator.SetBool("die",false);
		animator.SetBool("run",true);

	}

	public void onHealthChange(){
	
		StartCoroutine (ressurection ());

	}


	// NEW CODE
	public void OnTriggerEnter2D(Collider2D collider){

		if (this.CurrentHealth > 0 && orcIsDead == false) {
			Orc1 orc = collider.gameObject.GetComponent<Orc1> ();

			if (orc != null ) {
				if (collider == orc.bodyCollider ) {
					Debug.Log ("body!!!!!!!!!!!!!!!");
					this.reduceHealth (3);
				}
				if (collider == orc.headCollider) {
					Debug.Log ("head!!!!!!!!!!!");
					orcIsDead = true;
					orc.reduceHealth (3);
				}
			}
		}
	}


	// Update is called once per frame
	void FixedUpdate()
	{
		//[-1, 1]
		float value = Input.GetAxis("Horizontal");

		Animator animator = GetComponent<Animator> ();

		if(Mathf.Abs(value) > 0) {
			animator.SetBool ("run", true);

		} else {
			animator.SetBool ("run", false);

			if(LevelController.current.sound_on)
			this.runTune ();
		}


		if (Mathf.Abs(value) > 0)
		{
			Vector2 vel = myBody.velocity;
			vel.x = value * speed;
			myBody.velocity = vel;
			
		}
		SpriteRenderer sr = GetComponent<SpriteRenderer>();
		if (value < 0)
		{
			sr.flipX = true;
		}
		else if (value > 0)
		{
			sr.flipX = false;
		}

		Vector3 from = transform.position + Vector3.up * 0.3f;
		Vector3 to = transform.position + Vector3.down * 0.1f;
		int layer_id = 1 << LayerMask.NameToLayer("Ground");
		//Перевіряємо чи проходить лінія через Collider з шаром Ground
		RaycastHit2D hit = Physics2D.Linecast(from, to, layer_id);

		if (hit)
		{
			isGrounded = true;

			if (hit.transform != null && hit.transform.GetComponent<MovingPlatform> () != null) {
				MakeChild (this.transform, hit.transform);
			}
		}
		else
		{
			isGrounded = false;
			MakeChild (this.transform, this.heroParent);
		}
			

		//Намалювати лінію (для розробника)
		Debug.DrawLine(from, to, Color.red);

		if (Input.GetButtonDown("Jump") && isGrounded)
		{
			this.JumpActive = true;
		}
		if (this.JumpActive)
		{
			//Якщо кнопку ще тримають
			if (Input.GetButton("Jump"))
			{
				this.JumpTime += Time.deltaTime;
				if (this.JumpTime < this.MaxJumpTime)
				{
					Vector2 vel = myBody.velocity;
					vel.y = JumpSpeed * (1.0f - JumpTime / MaxJumpTime);
					myBody.velocity = vel;
				}
			}
			else
			{
				this.JumpActive = false;
				this.JumpTime = 0;
			}
		}

		//Animator animator = GetComponent<Animator>();
		if (this.isGrounded){
			animator.SetBool("jump", false);
			
		}
		else{
			animator.SetBool("jump", true);

			this.groundTune ();
		}


	}
}


