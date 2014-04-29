using UnityEngine;
using System.Collections;

public class ammoBoosterScript : MonoBehaviour {


	public int[] amountOfBullets;//Creating array to hold amount of bullets

	void Start()
	{
		amountOfBullets = new int[4];//Setting the array to hold 4 integers
		int randomSelection = Random.Range (150,200);//Creating integer that chooses a random number between 150 and 200
		amountOfBullets[0] = randomSelection;//Sets the 0'th place in the array to hold the random number
		randomSelection = Random.Range (100,145);//Set the integer to hold a new number between 100 and 145
		amountOfBullets[1] = randomSelection;//Sets the 1'st place in the array to hold the new random number
		randomSelection = Random.Range (15,45);//Same goes for the last two places
		amountOfBullets[2] = randomSelection;
		randomSelection = Random.Range (15,45);
		amountOfBullets[3] = randomSelection;

		transform.position = new Vector3 (transform.position.x, 6f,transform.position.z);//Setting the booster to 6 on the Y axis so it does not spawn in the terrai
	}
	void OnTriggerEnter(Collider other)//Collider function
	{  
		GameObject collisionObject;//Creating a GameObject called collisionObject
		GameObject weapon;//Creating a GameObject called weapon

		if(other.gameObject.name == "Avatar")  //If statement checks if avatar collides with this gameObject
		{
			collisionObject = other.gameObject;//collisionObject is set to be avatar
			weapon = collisionObject.transform.FindChild("AK_47_Model").gameObject;//sets weapon to be the AK47 which is attached to the avatar
			Ak47_Weapon script = weapon.GetComponent<Ak47_Weapon>();//Gets the AK47 script to edit the ammunition
			for(int i = 0; i < 4 ; i ++){//Running a for loop to add ammunition to the 0-3 places in the ammunitionStock array
				script.ammunitionStock[i] += amountOfBullets[i];//Adding the ammunition
			}
			Destroy(gameObject);//Destroy the booster on collision
			
		}
	}

}
