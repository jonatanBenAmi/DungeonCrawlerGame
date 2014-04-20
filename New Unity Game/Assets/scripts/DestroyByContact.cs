using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {
	public GameObject exp;

	public void OnTriggerEnter(Collider other) {
		if(other.tag == "Bullet"){
			Instantiate(exp, transform.position, transform.rotation);
			Destroy(other.gameObject); //this will destroy the bullet
			Destroy (gameObject); //this will destoy the enemy  //ends execution of function and return control back to unities game loop
		}

	}
}
