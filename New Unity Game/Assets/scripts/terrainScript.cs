using UnityEngine;
using System.Collections;

public class terrainScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Bullet"){
			Debug.Log(this.gameObject + ": Other: " + other.gameObject.name);
			Destroy(other.gameObject);
		}
	}
}
