using UnityEngine;
using System.Collections;

public class firerateBooster : MonoBehaviour {

	public float increaseFirerate;
	public float boosterTime;
	
	// Update is called once per frame
	void Update () 
	{
		increaseFirerate = 8f;
		boosterTime = 1000.0f;

		transform.position = new Vector3 (transform.position.x, 6f,transform.position.z);
	}

	void OnTriggerEnter(Collider other)
	{  
		GameObject collisionObject;
		GameObject weapon;
		
		if(other.gameObject.name == "Avatar") 
		{
			collisionObject = other.gameObject;
			weapon = collisionObject.transform.FindChild("AK_47_Model").gameObject;
			Ak47_Weapon script = weapon.GetComponent<Ak47_Weapon>();

			script.rateOfFire = increaseFirerate;
			script.boosterTimer.TimerIsOn = true;
			script.boosterTimer.TimeTicking = 0f;
			script.boosterTimer.TimeToNextTick = boosterTime;
			Destroy(gameObject);
			
		}
	}
}
