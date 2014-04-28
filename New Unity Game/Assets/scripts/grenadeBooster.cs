using UnityEngine;
using System.Collections;

public class grenadeBooster : MonoBehaviour {

	public int[] amountOfGrenades;

	void Start () {
		amountOfGrenades = new int[5] {5,5,5,5,5};
		transform.position = new Vector3 (transform.position.x, 6f,transform.position.z);
	}

	void OnTriggerEnter(Collider other)
	{  
		GameObject collisionObject;
		if(other.gameObject.name == "Avatar") 
		{
			collisionObject = other.gameObject;
			Player_Charactor script = collisionObject.GetComponent<Player_Charactor>();
			for(int i = 0; i < 5 ; i ++){
				script.grenadeStock[i] += amountOfGrenades[i];
			}
			Destroy(gameObject);
		}
	}
}
