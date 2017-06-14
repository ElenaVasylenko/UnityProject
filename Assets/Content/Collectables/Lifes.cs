using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifes : Collectable {

	// Use this for initialization
	protected override void OnRabitHit (HeroRabbit rabit){
		rabit.crystalTune ();
		LevelController.current.addLifes (rabit);
		this.CollectedHide ();
	}
}
