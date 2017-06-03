using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Collectable {

	protected override void OnRabitHit (HeroRabbit rabit)
	{
		//rabit.reduceHealth (1);
		rabit.sizeNormalize(3);
		LevelController.current.oopsBomb(1);
		this.CollectedHide ();
	}
}

