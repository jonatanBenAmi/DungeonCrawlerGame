using UnityEngine;
using System.Collections;

public class Enemy_Weapon : Weapons_Class 
{
	// bool to control fire 
	public bool openFire;
	// set initial values 
	public override void Start()
	{
		// timer starts at start up
		weaponTimer = new Event_Timer(rateOfFire,true);
		// give value in range of the array
		ammunitionChoise = 0;
		ammunitionStock = new int[1]{1000};
		openFire = false;
	}
	
	// Update is called once per frame
	public override void FixedUpdate () 
	{
		// can the weapon fire 
		if (weaponTimer.eventTimer())
		{
			triggerTick = true;
		}
		// if the player is in sight and the gun is ready to fire 
		if (triggerTick && openFire)
		{
			// fire weapon
			fireWeapon();
			// trickerTimer reset
			triggerTick = false;
			weaponTimer.TimeToNextTick = rateOfFire;
			weaponTimer.TimeTicking = 0f;
		}
	}
	public override void fireWeapon()
	{
		// if there is ammunition left
		if(ammunitionStock[ammunitionChoise] > 0)
		{
			// play audio
			audio.PlayOneShot (gunFire[0]);
			// subtract from stock
			ammunitionStock[ ammunitionChoise]--;
			// fire bullet from the position barrelend
			Instantiate(ammunitionType[ammunitionChoise], barrelEnd.position, barrelEnd.rotation);
		}
	}
}
