using UnityEngine;
using System.Collections;

public class explosivesBooster : MonoBehaviour {

	public int amountOfExplosives;
	
	void Start () {
		amountOfExplosives = 5;
	}
	
	void OnTriggerEnter(Collider other)
	{  
		GameObject collisionObject;
		if(other.gameObject.name == "Avatar") 
		{
			collisionObject = other.gameObject;
			Controls script = collisionObject.GetComponent<Controls>();
			script.grenadesLeft[5] +=  amountOfExplosives;
			Destroy(gameObject);
		}
	}
}
