using UnityEngine;
using System.Collections;

public class skullEnemy : MonoBehaviour {

	bool playerInZone;
	Vector3 movementVector;

	public float MovementSpeed;

	CharacterController cc;
	// Use this for initialization
	void Start () {
		cc = GetComponent<CharacterController>();

		playerInZone = false;
		movementVector = new Vector3(0.0f,0.0f,0.0f);
	}
	
	// Update is called once per frame
	void Update () {
		if (playerInZone == true){
			Debug.Log("inthezone");
		}
	
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Avatar"){
			playerInZone = true;
		}
	}
	void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "Avatar"){
			playerInZone = false;
		}
	}
}
