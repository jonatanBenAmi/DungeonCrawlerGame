using UnityEngine;
using System.Collections;

public class firerateBooster : MonoBehaviour {

	public float increaseFirerate;
	public float boosterTime;
	
	// Update is called once per frame
	void Update () 
	{
		increaseFirerate = 0.2f;
		boosterTime = 50.0f;
	}

	void OnTriggerEnter(Collider other)
	{  
		GameObject collisionObject;
		if(other.gameObject.name == "Avatar") 
		{
			collisionObject = other.gameObject;
			
			Controls script = collisionObject.GetComponent<Controls>();
			script.fireRate = increaseFirerate;
			script.boosterTime = boosterTime;
			Destroy(gameObject);
			
		}
	}
}
