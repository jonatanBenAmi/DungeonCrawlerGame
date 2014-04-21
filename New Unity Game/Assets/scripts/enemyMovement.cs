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

	public float ticTime;
	public float RandNum;

	public AudioClip MonsterSound;

	// Use this for initialization
	void Start () 
	{
		Target = GameObject.Find("Avatar");
		timeToTurn = 0.0f;
		MinDist = 0;
		ticTime = 500.0f;
		myTransform = transform;
	}
	
	// Update is called once per frame
	void Update () {
		if(ticTime>0){
			ticTime -= 1;
		}else if(ticTime==0){
			ticTime = 500;
		}

		Distance = Vector3.Distance (myTransform.position,Target.transform.position);

		if(Distance<30)
		{
			audio.volume = 0.3f;
			transform.LookAt (Target.transform);
			transform.position += transform.forward*MoveSpeed*Time.deltaTime;

		}else{
			audio.volume = 0f;
			transform.position += transform.forward*1*Time.deltaTime;
			if(ticTime==500){
				RandNum = Random.Range (0,360);
				Vector3 randomDirection = new Vector3 (0, RandNum, 0);
				transform.Rotate (randomDirection);
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
