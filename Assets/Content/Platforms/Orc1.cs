using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orc1 : MonoBehaviour {


	public Vector3 MoveBy;
	public float Speed = 2f;
	Vector3 pointA;
	Vector3 pointB;

	float to_wait = 0;
	bool is_moving_to_A = false;
	bool is_moving_to_B = true;

	GameObject weapon;

	public static int MaxHealth = 1;
	public int CurrentHealth = MaxHealth;

	public Vector3 patrolDistance; 

	public BoxCollider2D headCollider;
	public BoxCollider2D bodyCollider;


	bool isDead(){
		return this.CurrentHealth == 0;
	}


	public AudioClip attackSound = null;
	AudioSource attackSource = null;


	/*float getDirection(){

		Vector3 my_pos = this.transform.position;
		if (is_moving_to_A == false) {
			if (my_pos.x >= pointB.x)
				is_moving_to_A = true;
		}

		if (is_moving_to_A == true) {
			if (my_pos.x <= pointA.x)
				is_moving_to_A = false;
		}

		if (is_moving_to_A == false) {
			if (my_pos.x <= pointB.x)
				return 1;
			else
				return -1;
		}

		if (is_moving_to_A == true) {
			if (my_pos.x >= pointA.x)
				return 1;
			else
				return -1;
		}
	}*/

	// HEALTH

	// Use this for initialization
	void Start()
	{
		this.pointA = this.transform.position;
		this.pointB = this.pointA + patrolDistance;

		attackSource = gameObject.AddComponent<AudioSource> ();
		attackSource.clip = attackSound;
	}

	public void attackTune() {
		attackSource.Play ();
	}

	public void reduceHealth(int n){
		this.CurrentHealth -= n;

		if (this.CurrentHealth < 0)
			this.CurrentHealth = 0;
	}


	bool isArrived(Vector3 pos, Vector3 target) {
		pos.z = 0;
		target.z = 0;
		return Vector3.Distance(pos, target) < 1f;
	}

	bool isRabbitHere() {
		Vector3 rabbit_pos = HeroRabbit.lastRabbit.transform.position;
		if (rabbit_pos.x >= pointA.x && rabbit_pos.x <= pointB.x)
			return true;
		else
			return false;
	}

	IEnumerator onOrcDie(){
		
		Animator animator = GetComponent<Animator> ();
		animator.SetBool ("die", true);
		yield return new WaitForSeconds (3f);
		Destroy (this.gameObject);
	}


	// Update is called once per frame
	void Update()
	{
		float value = Input.GetAxis("Horizontal");
		Vector3 my_pos = this.transform.position;
		Vector3 rabbit_pos = HeroRabbit.lastRabbit.transform.position;
		Vector3 target;

		Animator animator = GetComponent<Animator> ();
		animator.SetBool ("walk", true);


		//CHANGE DIRECTIONS OF ORC

		if(is_moving_to_A) {
			target = this.pointA;
		} else {
			target = this.pointB;
		}

		if (isRabbitHere() == false) {
			animator.SetBool("run",false);
			if (isArrived (target, my_pos)) {
				is_moving_to_A = !is_moving_to_A;
			} else {
				Vector3 destination = target - my_pos;
				destination.z = 0;
				float move = this.Speed = Time.deltaTime;
				float distance = Vector3.Distance (destination, my_pos);

				Vector3 move_vector = destination.normalized * Mathf.Min (move, distance);
				this.transform.position += move_vector;
			}
		}
		//CHANGE FACE ROTATION OF ORC
		SpriteRenderer sr = GetComponent<SpriteRenderer>();

		if (is_moving_to_A)
			sr.flipX = false;
		else
			sr.flipX = true;
	
		// RABBIT IS IN ORC AREA
		if (isRabbitHere()) {
			this.attackTune ();

			if ((rabbit_pos.x - my_pos.x) < 0)
				sr.flipX = false;
			else
				sr.flipX = true;

			//animator.SetBool ("walk", false);
			//
			animator.SetBool("run",true);
			if (isArrived (rabbit_pos, my_pos)) {
				
				animator.SetBool("attack",true);

				if (this.CurrentHealth == 0) {
					animator.SetBool ("run", false);
					StartCoroutine(onOrcDie());
				}
			} else {
				animator.SetBool ("run", true);
			Vector3 destination = rabbit_pos - my_pos;
			destination.z = 0;
			destination.y = 0; //WITHOUT IT ORC FLYES FOLLOWING THE RABBIT
			float move = this.Speed = Time.deltaTime*1.2f;
			float distance = Vector3.Distance (destination, my_pos);

			Vector3 move_vector = destination.normalized * Mathf.Min (move, distance);
			this.transform.position += move_vector;
			}
		}

	}
}
