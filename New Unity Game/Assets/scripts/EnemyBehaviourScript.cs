using UnityEngine;
using System.Collections;

public class EnemyBehaviourScript : MonoBehaviour {
	public Transform exp; // variable used to interset a explosion particle

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}
	void OnCollisionEnter(Collision other){ //detects collision
		if(other.gameObject.name =="Player"){ // if the object collides with the Avartar object
			Instantiate (exp, transform.position, Quaternion.identity); //then istantiate the "exp particle effect"
			Destroy (gameObject); // and destroy the object
		}
	
	}
}
