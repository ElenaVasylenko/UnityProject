using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orc2 : MonoBehaviour {


	public Vector3 MoveBy;
	public float Speed = 2f;
	Vector3 pointA;
	Vector3 pointB;
	public float last_carrot = 0;

	public float radius;
	float to_wait = 0;
	bool is_moving_to_A = false;
	bool is_moving_to_B = true;

	public GameObject carrot;

	public static int MaxHealth = 1;
	public int CurrentHealth = MaxHealth;

	public Vector3 patrolDistance; 

	public BoxCollider2D headCollider;
	public BoxCollider2D bodyCollider;

	public AudioClip attackSound = null;
	AudioSource attackSource = null;

	bool isDead(){
		return this.CurrentHealth == 0;
	}

	void launchCarrot(float dir)
	{  
		//Створюємо копію Prefab
		GameObject obj = Instantiate(this.carrot) as GameObject;
		//Розміщуємо в просторі
		obj.transform.position = new Vector3(this.transform.position.x, this.transform.position.y+0.6f,0);
		//Запускаємо в рух
		obj.GetComponent<Carrot>().launch(dir);
	}


	void Start()
	{
		this.pointA = this.transform.position;
		this.pointB = this.pointA + patrolDistance;

		attackSource = gameObject.AddComponent<AudioSource> ();
		attackSource.clip = attackSound;
	}


	public void attackTune() {
		if(LevelController.current.sound_on)
		attackSource.Play ();
	}

	//HEALTH
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
		Vector3 my_pos = this.transform.position;
		float distance = Vector3.Distance (rabbit_pos, my_pos);
		if (distance <= radius)
			return true;
		else
			return false;
	}

	IEnumerator onOrcDie(){
		Animator animator = GetComponent<Animator> ();
		animator.SetBool ("die", true);
		yield return new WaitForSeconds (0.3f);
		Destroy (this.gameObject);
	}
		
	// Update is called once per frame
	void Update()
	{
		float value = Input.GetAxis("Horizontal");
		Vector3 my_pos = this.transform.position;
		Vector3 rabbit_pos = HeroRabbit.lastRabbit.transform.position;
		Vector3 target;

		//CHANGE FACE ROTATION OF ORC
		SpriteRenderer sr = GetComponent<SpriteRenderer>();
		sr.flipY = false;

		Animator animator = GetComponent<Animator> ();
		animator.SetBool ("walk", true);
		animator.SetBool ("attack", false);


		//CHANGE DIRECTIONS OF ORC

		if(is_moving_to_A) {
			target = this.pointA;
		} else {
			target = this.pointB;
		}

		if (isRabbitHere() == false) {


			if (is_moving_to_A)
				sr.flipX = false;
			else
				sr.flipX = true;
			
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



		// RABBIT IS IN ORC AREA
		if (isRabbitHere()) {
			this.attackTune ();
			animator.SetBool ("walk", false);
			//animator.SetBool ("attack", true)
			//animator.SetBool ("idle", true);

			if ((rabbit_pos.x - my_pos.x) < 0)
				sr.flipX = false;
			else
				sr.flipX = true;
			
			if (Time.time - last_carrot > 1.0f){
				GetComponent<Animator>().SetBool("attack", true);
				last_carrot = Time.time;

				//SpriteRenderer sr1 = this.GetComponent<SpriteRenderer>();
				if (sr.flipX == false){
					launchCarrot(-1);
				}
				else{
					launchCarrot(1);
				}

			}
		}
			
	}
		
}
