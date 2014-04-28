using UnityEngine;
using System.Collections;

public class healthBooster : MonoBehaviour {

	private float defenceIncrease;
	private int liveIncrease;

	void Start()
	{
		defenceIncrease = 100.0f;
		liveIncrease = 1;
		transform.position = new Vector3 (transform.position.x, 6f,transform.position.z);
	}
	void OnTriggerEnter(Collider other)
	{  
		GameObject collisionObject;
		// all objects with the Enemy tag
		// will take one of you health values
		if(other.gameObject.name == "Avatar") 
		{
			collisionObject = other.gameObject;
			
			Player_Charactor script = collisionObject.GetComponent<Player_Charactor>();
			script.defence = defenceIncrease;
			script.Lives = liveIncrease;
			Destroy(gameObject);
		}
	}
}
