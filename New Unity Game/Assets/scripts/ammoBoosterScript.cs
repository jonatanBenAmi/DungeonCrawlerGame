using UnityEngine;
using System.Collections;

public class ammoBoosterScript : MonoBehaviour {


	public int[] amountOfBullets;

	void Start()
	{
		amountOfBullets = new int[5];
		int randomSelection = Random.Range (30,60);
		amountOfBullets[0] = randomSelection;
		randomSelection = Random.Range (15,45);
		amountOfBullets[1] = randomSelection;
		randomSelection = Random.Range (15,45);
		amountOfBullets[2] = randomSelection;
		randomSelection = Random.Range (5,15);
		amountOfBullets[3] = randomSelection;
		randomSelection = Random.Range (5,15);
		amountOfBullets[4] = randomSelection;
	}
	void OnTriggerEnter(Collider other)
	{  
		GameObject collisionObject;
		if(other.gameObject.name == "Avatar") 
		{
			collisionObject = other.gameObject;
			
			Controls script = collisionObject.GetComponent<Controls>();
			for(int i = 0; i < 5 ; i ++){
				script.bulletsLeft[i] += amountOfBullets[i];
			}
			Destroy(gameObject);
			
		}
	}

}
