using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		if(other.tag == "Boundary"){
			return;  //ends execution of function and return control back to unities game loop
		}
		Destroy(other.gameObject); //this will destroy the bullet
		Destroy (gameObject); //this will destoy the enemy
	}
}
