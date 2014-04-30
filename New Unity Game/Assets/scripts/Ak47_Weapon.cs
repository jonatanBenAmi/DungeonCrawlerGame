using UnityEngine;
using System.Collections;

public class Ak47_Weapon : Weapons_Class 
{
	public Event_Timer boosterTimer; //timer used to limit the amount of time for rateOfFire booster

	public override void Start()
	{
		weaponTimer = new Event_Timer(rateOfFire,true); //constructor to the timer of the fireRate
		boosterTimer = new Event_Timer(rateOfFire,false);//constuctor to time of the booster timer
		ammunitionChoise = 0; //variable that stores what number of bullet type your are in possession of
		ammunitionStock = new int[4]{100,100,100,100}; //array that holds the amounth of bullets for each type of bullet
	}
	public override void FixedUpdate() //override function to the weapon Class
	{

		Debug.Log(weaponTimer.eventTimer()); //This is a useful tool when we had problems
		if (weaponTimer.eventTimer())//if this is true, that we can shoot bullets
		{
			triggerTick = true;

		}
		if (boosterTimer.eventTimer()) //resets after booster
		{
			rateOfFire = 15f; //reset firerate to 15
			boosterTimer.TimerIsOn = false; //turns of the timer
		}
		if (Input.GetButton ("Fire1")) //if the fire button on the mouse is pressed
		{
			if (triggerTick) //check if this is true (if the timer is true and your gun is loaded)
			{
				fireWeapon();  //call the fire weapon function   
				triggerTick = false; //resets the weapons timer
				weaponTimer.TimeToNextTick = rateOfFire; // the next two resets the timer
				weaponTimer.TimeTicking = 0f;
			}
		}
		if(Input.GetAxis("Mouse ScrollWheel") != 0) //the mouse wheel is scrolled and the scoll value is not 0
		{
			ammunitionChoise += (int)Input.GetAxisRaw("Mouse ScrollWheel"); //ammunition choise corresponces to the mouse scrollwheel sensivity value
			if(ammunitionChoise > ammunitionStock.Length - 1){ //if the choice is bigger than the options available,
				ammunitionChoise = 0; //then reset it to the first choise
			}else if (ammunitionChoise < 0){ //if it is less than 0(the first choise), then resets to the last possible weapon option
				ammunitionChoise = ammunitionStock.Length - 1;
			}
		}
	}
	public override void fireWeapon() //function that chooses the a type of ammunition and fire the right amounth of bullets
	{
		if(ammunitionStock[ammunitionChoise] > 0) //choose the ammunition type
		{
			audio.PlayOneShot (gunFire[0]); //plays the gunfire sound when a shot is fired
			ammunitionStock[ ammunitionChoise]--; //when a shot is fired, you have one bullet less
			Instantiate(ammunitionType[ammunitionChoise], barrelEnd.position, barrelEnd.rotation); //spawns the bullet from the tip of the barrel position
		}else if(ammunitionStock[ammunitionChoise]==0){
			audio.PlayOneShot (gunFire[1]);
		}
	}
	void OnGUI() // whole GUI function displaying the type of bullet accessed and how many bullets available
	{ 
		GUI.TextField(new Rect(Screen.width - 160,0,160,80),	ammunitionType[ammunitionChoise].name + ": \n" +
		              ammunitionStock[ ammunitionChoise] + "x ");
		GUI.DrawTexture(new Rect(Screen.width - 150,36,140,26),ammunitionGui[ammunitionChoise]);
	}
}
