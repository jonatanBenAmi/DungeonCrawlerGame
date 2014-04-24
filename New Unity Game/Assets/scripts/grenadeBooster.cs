using UnityEngine;
using System.Collections;

public class grenadeBooster : MonoBehaviour {

	public int[] amountOfGrenades;

	void Start () {
		amountOfGrenades = new int[5] {5,3,3,2,1};
	}

	void OnTriggerEnter(Collider other)
	{  
		GameObject collisionObject;
		if(other.gameObject.name == "Avatar") 
		{
			collisionObject = other.gameObject;
			Controls script = collisionObject.GetComponent<Controls>();
			for(int i = 0; i < 5 ; i ++){
				script.grenadesLeft[i] += amountOfGrenades[i];
			}
			Destroy(gameObject);
		}
	}
}
