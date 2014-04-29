using UnityEngine;
using System.Collections;

public class firerateBooster : MonoBehaviour {

	public float increaseFirerate;//Variable to hold the number for increasing firerate
	public float boosterTime;//Variable to hold the time in which the boost takes place

	void Update () 
	{
		increaseFirerate = 8f;//Setting the variable to be 8
		boosterTime = 1000.0f;//Setting the variable to be 1000

		transform.position = new Vector3 (transform.position.x, 6f,transform.position.z);//Setting the booster to 6 on the Y axis so it does not spawn in the terrain
	}

	void OnTriggerEnter(Collider other)//Collider function
	{  
		GameObject collisionObject;//Creating a GameObject called collisionObject
		GameObject weapon;//Creating a GameObject called weapon
		
		if(other.gameObject.name == "Avatar") //If statement checks if avatar collides with this gameObject
		{
			collisionObject = other.gameObject;//collisionObject is set to be avatar
			weapon = collisionObject.transform.FindChild("AK_47_Model").gameObject;//sets weapon to be the AK47 which is attached to the avatar
			Ak47_Weapon script = weapon.GetComponent<Ak47_Weapon>();//Gets the AK47 script to edit the fireRate
			script.rateOfFire = increaseFirerate;//Sets the rateOfFire to be the increaseFirerate
			script.boosterTimer.TimerIsOn = true;//Sets the timer to true
			script.boosterTimer.TimeTicking = 0f;//Sets TimeTicking to be 0, basically to a starting position
			script.boosterTimer.TimeToNextTick = boosterTime;//Sets TimeToNextTick to be boosterTime, tells how long the booster needs to be
			Destroy(gameObject);//Destroy the booster on collision
			
		}
	}
}
