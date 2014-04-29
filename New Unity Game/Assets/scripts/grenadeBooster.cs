using UnityEngine;
using System.Collections;

public class grenadeBooster : MonoBehaviour {

	public int[] amountOfGrenades;//Creating array to hold the new grenades

	void Start () {
		amountOfGrenades = new int[5] {20,10,10,10,10};//Adding grenades to the array
		transform.position = new Vector3 (transform.position.x, 6f,transform.position.z);//Setting the booster to 6 on the Y axis so it does not spawn in the terrai
	}

	void OnTriggerEnter(Collider other)//Collider function
	{  
		GameObject collisionObject;//Creating GameObject called collisionObject
		if(other.gameObject.name == "Avatar")//If statement checks if avatar collides with this gameObject
		{
			collisionObject = other.gameObject;//collisionObject is set to be avatar
			Player_Charactor script = collisionObject.GetComponent<Player_Charactor>();//Getting the character script to edit the amount of grenades
			for(int i = 0; i < 5 ; i ++){//Running a for loop to add grenades to the 0-4 places in the grenadeStock array
				script.grenadeStock[i] += amountOfGrenades[i];//Adding the grenades! (5 place is explosives)
			}
			Destroy(gameObject);//Destroys the booster on collision
		}
	}
}
