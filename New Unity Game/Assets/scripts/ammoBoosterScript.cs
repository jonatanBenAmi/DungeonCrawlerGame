using UnityEngine;
using System.Collections;

public class ammoBoosterScript : MonoBehaviour {


	public int[] amountOfBullets;

	void Start()
	{
		amountOfBullets = new int[4];
		int randomSelection = Random.Range (150,200);
		amountOfBullets[0] = randomSelection;
		randomSelection = Random.Range (100,145);
		amountOfBullets[1] = randomSelection;
		randomSelection = Random.Range (15,45);
		amountOfBullets[2] = randomSelection;
		randomSelection = Random.Range (15,45);
		amountOfBullets[3] = randomSelection;

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
			for(int i = 0; i < 4 ; i ++){
				script.ammunitionStock[i] += amountOfBullets[i];
			}
			Destroy(gameObject);
			
		}
	}

}
