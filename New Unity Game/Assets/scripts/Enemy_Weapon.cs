using UnityEngine;
using System.Collections;

public class Enemy_Weapon : Weapons_Class 
{

	public bool openFire;

	public override void Start()
	{
		weaponTimer = new Event_Timer(rateOfFire,true);
		ammunitionChoise = 0;
		ammunitionStock = new int[1]{1000};
		openFire = false;
	}
	
	// Update is called once per frame
	public override void FixedUpdate () 
	{
		if (weaponTimer.eventTimer())
		{
			triggerTick = true;
		}
		if (triggerTick && openFire)
		{
			fireWeapon();
			triggerTick = false;
			weaponTimer.TimeToNextTick = rateOfFire;
			weaponTimer.TimeTicking = 0f;
		}
	}
	public override void fireWeapon()
	{
		if(ammunitionStock[ammunitionChoise] > 0)
		{
			audio.PlayOneShot (gunFire);
			ammunitionStock[ ammunitionChoise]--;
			Instantiate(ammunitionType[ammunitionChoise], barrelEnd.position, barrelEnd.rotation);
		}
	}
}
