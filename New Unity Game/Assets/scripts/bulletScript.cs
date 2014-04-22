using UnityEngine;
using System.Collections;

public class bulletScript : MonoBehaviour {

	public float speed = 20;
	// Use this for initialization
	void Start () {
		rigidbody.velocity = transform.forward * speed;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
