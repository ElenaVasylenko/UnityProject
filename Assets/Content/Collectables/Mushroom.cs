using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : Collectable {

	protected override void OnRabitHit (HeroRabbit rabit)
	{
		
		rabit.reduceHealth (1);
		rabit.transform.localScale = Vector3.one * 2;
		LevelController.current.oopsMushroom(1);
		this.CollectedHide();
	}
}
