using UnityEngine;
using System.Collections;

public class explosivesBooster : MonoBehaviour {

	public int amountOfExplosives;//variable to store amount of explosives
	
	void Start () 
	{
		amountOfExplosives = 5; //Amount of explosives this booster gives
		transform.position = new Vector3 (transform.position.x, 6f,transform.position.z);//Setting the booster to 6 on the Y axis so it does not spawn in the terrai
	}
	
	void OnTriggerEnter(Collider other)//Collider function
	{  
		GameObject collisionObject;//Creating a GameObject called collisionObject
		if(other.gameObject.name == "Avatar") //If statement checks if avatar collides with this gameObject
		{
			collisionObject = other.gameObject;//collisionObject is set to be avatar
			Player_Charactor script = collisionObject.GetComponent<Player_Charactor>();//Getting the character script to edit the amount of explosives
			script.grenadeStock[5] += amountOfExplosives;//Adds 5 explosives to the 5 place in the grenadeStock array
			Destroy(gameObject);//Destroy the booster on collision
		}
	}
}
