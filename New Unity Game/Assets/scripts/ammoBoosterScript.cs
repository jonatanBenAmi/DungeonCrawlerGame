using UnityEngine;
using System.Collections;

public class ammoBoosterScript : MonoBehaviour {


	public int amountOfBullets;

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
			script.bulletsLeft += amountOfBullets;
			Destroy(gameObject);
			
		}
	}
}
