﻿using UnityEngine;
using System.Collections;

public class healthBooster : MonoBehaviour {

	public int lifeIncrease;

	void Start()
	{
		lifeIncrease = 1;
	}
	void OnTriggerEnter(Collider other)
	{  
		GameObject collisionObject;
		// all objects with the Enemy tag
		// will take one of you health values
		if(other.gameObject.name == "Avatar") 
		{
			collisionObject = other.gameObject;
			
			Controls script = collisionObject.GetComponent<Controls>();
			script.life += lifeIncrease;
			Destroy(gameObject);
		}
	}
}
