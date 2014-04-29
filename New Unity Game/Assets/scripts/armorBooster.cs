using UnityEngine;
using System.Collections;

public class armorBooster : MonoBehaviour {

	private float armorIncrease;//Variable to store armorIncrease
	
	void Start()
	{
		armorIncrease = 100.0f;//Sets armorIncrease to be 100
		transform.position = new Vector3 (transform.position.x, 6f,transform.position.z);//Setting the booster to 6 on the Y axis so it does not spawn in the terrain
	}
	void OnTriggerEnter(Collider other)//Collider function
	{  
		GameObject collisionObject;//Creating a GameObject called collisionObject
		if(other.gameObject.name == "Avatar") //If statement checks if avatar collides with this gameObject
		{
			collisionObject = other.gameObject;//collisionObject is set to be avatar
			Player_Charactor script = collisionObject.GetComponent<Player_Charactor>();//Getting the character script to edit armor
			script.armorStrength += armorIncrease;//Adding armorIncrease to the armorStrength
			Destroy(gameObject);//Destroy the booster on collision
		}
	}
}
