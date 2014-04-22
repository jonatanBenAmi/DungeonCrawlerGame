using UnityEngine;
using System.Collections;

public class grenadeBooster : MonoBehaviour {

	public int amountOfGrenades;
	public int grenadeChoise;

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
			if(grenadeChoise == 0){
				script.grenadesLeft[grenadeChoise] += amountOfGrenades;
			}
			else if(grenadeChoise == 1){
				script.grenadesLeft[grenadeChoise] += amountOfGrenades;
			}
			Destroy(gameObject);
		}
	}
}
