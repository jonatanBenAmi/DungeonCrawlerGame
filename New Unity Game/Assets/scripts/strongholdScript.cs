using UnityEngine;
using System.Collections;

public class strongholdScript : MonoBehaviour {

	public int defence;
	public GameObject player;
	public GameObject exp;

	void Start () {
		defence = 50;
		player = GameObject.Find("Avatar");
	}
	
	// Update is called once per frame
	void Update () {
		if(defence < 0){
			Instantiate(exp, transform.position, transform.rotation);
			Controls script = player.GetComponent<Controls>();
			script.checkPoint = player.transform.position;
			Destroy(gameObject);
		}
	}
	void OnTriggerEnter(Collider other)
	{  
		if(other.tag == "Bullet"){
			defence--;
			Instantiate(exp, transform.position, transform.rotation);
			Destroy(other.gameObject); //this will destroy the bullet
			//this will destoy the enemy  //ends execution of function and return control back to unities game loop
		}
	}
}
