using UnityEngine;
using System.Collections;

public class explosivesBooster : MonoBehaviour {

	public int amountOfExplosives;
	
	void Start () 
	{
		amountOfExplosives = 5;
		transform.position = new Vector3 (transform.position.x, 6f,transform.position.z);
	}
	
	void OnTriggerEnter(Collider other)
	{  
		GameObject collisionObject;
		if(other.gameObject.name == "Avatar") 
		{
			collisionObject = other.gameObject;
			Player_Charactor script = collisionObject.GetComponent<Player_Charactor>();
			script.grenadeStock[5] += amountOfExplosives;
			Destroy(gameObject);
		}
	}
}
