using UnityEngine;
using System.Collections;

public class enemyMovement : MonoBehaviour {

	GameObject Target;

	public GameObject exp;

	public int MoveSpeed = 5;
	public int MinDist;
	private float timeToTurn;

	private Transform myTransform;
	private float Distance;

	// Use this for initialization
	void Start () 
	{
		Target = GameObject.Find("Avatar");
		timeToTurn = 0.0f;
		MinDist = 0;
		myTransform = transform;
	}
	
	// Update is called once per frame
	void Update () 
	{
		Distance = Vector3.Distance (myTransform.position,Target.transform.position);

		if(Distance<30)
		{
			transform.LookAt (Target.transform);

			if(Vector3.Distance (transform.position,Target.transform.position) >=MinDist)
			{
				transform.position += transform.forward*MoveSpeed*Time.deltaTime;
			}
		}

	}

	
	public void OnTriggerEnter(Collider other) {
		if(other.tag == "Bullet"){
			Instantiate(exp, transform.position, transform.rotation);
			Destroy(other.gameObject); //this will destroy the bullet
			Destroy (gameObject); //this will destoy the enemy  //ends execution of function and return control back to unities game loop
		}
		
	}
}
