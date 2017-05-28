using System.Collections;
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

	// HEALTH
	public static int MaxHealth = 3;
	public int CurrentHealth = MaxHealth;

	// Use this for initialization
	void Start()
	{
		myBody = this.GetComponent<Rigidbody2D>();
		this.heroParent = this.transform.parent;
		LevelController.current.setStartPosition(transform.position);
	}


	static void MakeChild(Transform obj, Transform my_parent){
		obj.transform.parent = my_parent;
	}

	public void addHealth(int n){
		this.CurrentHealth += n;

		if (this.CurrentHealth > MaxHealth)
			this.CurrentHealth = MaxHealth;

		this.onHealthChange ();
	}

	public void reduceHealth(int n){
		this.CurrentHealth -= n;

		if (this.CurrentHealth < 0)
			this.CurrentHealth = 0;

		this.onHealthChange ();
	}
		
	public void onHealthChange(){

		if (this.CurrentHealth == 3) {
			this.transform.localScale = Vector3.one;
		//} //else if (this.CurrentHealth == 2) {
			//this.transform.localScale = Vector3.one * 2;
		//} else if (this.CurrentHealth == 3) {
			//this.transform.localScale = Vector3.one * 3;
		}else if (this.CurrentHealth == 0) {
			LevelController.current.onRabitDeath (this);
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
		if (this.isGrounded)
		{
			animator.SetBool("jump", false);
		}
		else
		{
			animator.SetBool("jump", true);
		}


	}
}


