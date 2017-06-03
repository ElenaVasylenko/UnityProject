using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : Collectable {

	protected override void OnRabitHit(HeroRabbit rabit)
	{
		//rabit.reduceHealth (3);
		//rabit.onHealthChange();
		rabit.sizeNormalize (1);
		this.CollectedHide ();
	}

	float my_direction =0;
	public float timeToDestroy = 4f;
	public float timeToWait = 3f;
	//SpriteRenderer sr = GetComponent<SpriteRenderer>();

	float last_carrot = 0;
	public float speed = 4;
	SpriteRenderer sr;

		//class Carrot
		void Start()
		{
			StartCoroutine(destroyLater());
		}

		void Update(){
		
			sr = GetComponent<SpriteRenderer>();
		if (sr.flipX == false){
				this.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
			}
			else{
				this.transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
			}
		}

		IEnumerator destroyLater(){
		yield return new WaitForSeconds(timeToDestroy);
			Destroy(this.gameObject);
		}
		
		public void launch(float direction){
		sr = GetComponent<SpriteRenderer>();
		if (direction>0)
			sr.flipX = false;

		else
			sr.flipX = true;
		
		StartCoroutine(launchCarrot(timeToWait));
		}
		
	IEnumerator launchCarrot(float duration){
			sr = GetComponent<SpriteRenderer>();
			yield return new WaitForSeconds(duration);

		if (sr.flipX == false){
				this.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
			}
			else{
				this.transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
			}
		}

}


