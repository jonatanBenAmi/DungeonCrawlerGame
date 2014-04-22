using UnityEngine;
using System.Collections;

public class ammoBoosterScript : MonoBehaviour {


	public int amountOfBullets;
	public int bulletChoise;

	void Start()
	{
		amountOfBullets = 30;
	}
	void OnTriggerEnter(Collider other)
	{  
		GameObject collisionObject;
		if(other.gameObject.name == "Avatar") 
		{
			collisionObject = other.gameObject;
			
			Controls script = collisionObject.GetComponent<Controls>();
			if(bulletChoise == 0){
				script.bulletsLeft[bulletChoise] += amountOfBullets;
			}
			else if(bulletChoise == 1){
				script.bulletsLeft[bulletChoise] += amountOfBullets;
			}

			Destroy(gameObject);
			
		}
	}
}
