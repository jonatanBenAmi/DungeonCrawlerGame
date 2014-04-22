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
			Destroy(other.gameObject);
		}else if(other.gameObject.tag == "Enemy"){
			GameObject collisionObject;
			collisionObject = other.gameObject;
			enemyMovement script = collisionObject.GetComponent<enemyMovement>();
			Vector3 randomDirection = new Vector3 (0, 150, 0);
			other.transform.Rotate (randomDirection);
		}
	}
}
