using UnityEngine;
using System.Collections;

public class ammoBoosterScript : MonoBehaviour {

	public string boosterType;

	//ammo boosters

	public int amountOfBullets;

	public float increaseFirerate;
	public float boosterTime;

	//health boosters

	public int healthIncrease;


	void Start()
	{
		healthIncrease = 1;
	}
}
