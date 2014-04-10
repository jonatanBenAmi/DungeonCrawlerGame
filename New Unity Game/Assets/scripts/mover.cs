using UnityEngine;
using System.Collections;

public class mover : MonoBehaviour {
	public float speed = 20;
	GameObject player;
	// Use this for initialization
	void Start () {
		rigidbody.velocity = transform.forward * speed;
	}

	void OnTriggerExit(Collider other) {
		Destroy(other.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
