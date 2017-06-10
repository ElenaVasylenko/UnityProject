using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystals : Collectable {

	public int color;

	string gemName2 = "gem"; //red
	string gemName3 = "gem (1)"; //green
	string gemName1 = "gem (2)"; //blue


	public void detectColor(string gemName){
		if (gemName == gemName1)
			color = 1;

		if (gemName == gemName2)
			color = 2;

		if (gemName == gemName3)
			color = 3;
	}


	protected override void OnRabitHit (HeroRabbit rabit)
	{
		rabit.crystalTune ();
		SpriteRenderer sr = GetComponent<SpriteRenderer>();
		Debug.Log ("HAAAAAAAAAMW: "+sr.name);
		string gemName = sr.name;
		detectColor (gemName);

		LevelController.current.addCrystals (color);
		this.CollectedHide ();
	}
}
