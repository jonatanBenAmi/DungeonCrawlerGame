using UnityEngine;
using System.Collections;

public class grenadeBooster : MonoBehaviour {

	public int amountOfGrenades;

	void Start () {
		amountOfGrenades = 5;
	}

	void OnTriggerEnter(Collider other)
	{  
		GameObject collisionObject;
		if(other.gameObject.name == "Avatar") 
		{
			collisionObject = other.gameObject;
			Controls script = collisionObject.GetComponent<Controls>();
			script.grenadesLeft += amountOfGrenades;
			Destroy(gameObject);
		}
	}
}
