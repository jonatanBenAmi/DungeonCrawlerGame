using UnityEngine;
using System.Collections;

public class Ak47_Weapon : Weapons_Class 
{

	public override void Start()
	{
		weaponTimer = new Event_Timer(rateOfFire,true);
		ammunitionChoise = 0;
		ammunitionStock = new int[4]{100,100,100,100};
	}
	public override void FixedUpdate()
	{
		if (weaponTimer.eventTimer())
		{
			triggerTick = true;
		}
		if (Input.GetButton ("Fire1")) 
		{
			if (triggerTick)
			{
				fireWeapon();
				triggerTick = false;
				weaponTimer.TimeToNextTick = rateOfFire;
				weaponTimer.TimeTicking = 0f;
			}
		}
		if(Input.GetAxis("Mouse ScrollWheel") != 0)
		{
			ammunitionChoise += (int)Input.GetAxisRaw("Mouse ScrollWheel");
			if(ammunitionChoise > ammunitionStock.Length - 1){
				ammunitionChoise = 0;
			}else if (ammunitionChoise < 0){
				ammunitionChoise = ammunitionStock.Length - 1;
			}
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
