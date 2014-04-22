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

	public int defence;

	public AudioClip MonsterSound;

	// Use this for initialization
	void Start () 
	{
		Target = GameObject.Find("Avatar");
		timeToTurn = 0.0f;
		MinDist = 0;
		ticTime = 500.0f;
		defence = 3;
		myTransform = transform;
	}

	void Update () {

		if(ticTime>0){
			ticTime -= 1;
		}else if(ticTime==0){
			ticTime = 500;
		}


		if(defence < 0)
		{
			Instantiate(exp, transform.position, transform.rotation);
			Destroy (gameObject);
		}

		Distance = Vector3.Distance (myTransform.position,Target.transform.position);
		if(Distance<30)
		{
			audio.volume = 0.3f;
			audio.PlayOneShot(MonsterSound);
			transform.LookAt (Target.transform);
			transform.position += transform.forward*MoveSpeed*Time.deltaTime;

		}else{
			audio.volume = 0f;
			transform.position += transform.forward*3*Time.deltaTime;
			if(ticTime==500){
				RandNum = Random.Range (0,360);
				Vector3 randomDirection = new Vector3 (0, RandNum, 0);
				transform.Rotate (randomDirection);
			}else if(transform.position.y > 6){
				Vector3 randomDirection = new Vector3 (0, 180, 0);
				transform.Rotate (randomDirection);
			}
		}
		//Debug.Log(transform.position.y);
	}

	
	public void OnTriggerEnter(Collider other) {
		if(other.tag == "Bullet"){
			defence--;
			if(defence < 1){
				Instantiate(exp, transform.position, transform.rotation);
				Destroy(other.gameObject); //this will destroy the bullet
				Destroy (gameObject);
			}else{
				Destroy(other.gameObject); //this will destroy the bullet
			}
		}
		if(other.tag == "Terrain"){
			Vector3 randomDirection = new Vector3 (0, 150, 0);
			transform.Rotate (randomDirection);
			Debug.Log(transform.position);
		}else if(other.tag == "SpawnPoint"){
			Vector3 randomDirection = new Vector3 (0, 150, 0);
			transform.Rotate (randomDirection);
			Debug.Log(transform.position);
		}else if(other.tag == "Enemy"){
			Vector3 randomDirection = new Vector3 (0, 150, 0);
			transform.Rotate (randomDirection);
			Debug.Log(transform.position);
		}else if(other.tag == "Water"){
			Vector3 randomDirection = new Vector3 (0, 150, 0);
			transform.Rotate (randomDirection);
			Debug.Log(transform.position);
		}

	}

}
