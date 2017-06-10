using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruits : Collectable {
	
	protected override void OnRabitHit(HeroRabbit rabit){
		rabit.fruitTune ();
		LevelController.current.addFruits (1);
		this.CollectedHide();
	}
}
