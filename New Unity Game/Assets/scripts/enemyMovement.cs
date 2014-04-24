using UnityEngine;
using System.Collections;

public class enemyMovement : MonoBehaviour {

	GameObject Target;

	public GameObject exp;

	public int MoveSpeed = 5;
	public int MinDist;
	public float timeToTurn;

	private Transform myTransform;
	private float Distance;

	public float ticTime;
	public float RandNum;

	public float defence;
	public float attack;
	public bool stuned;
	private float defenceBeforeStun;


	public AudioClip MonsterSound;

	// Use this for initialization
	void Start () 
	{
		Target = GameObject.Find("Avatar");
		timeToTurn = 500.0f;
		MinDist = 0;
		ticTime = 0.0f;
		stuned = false;
		defenceBeforeStun = 0;
		myTransform = transform;
	}

	void Update () {

		if(ticTime < timeToTurn){
			ticTime ++;
		}else if(ticTime == timeToTurn ){
			ticTime = 0;
			timeToTurn = 500.0f;
			if(stuned == true){
				defence = defenceBeforeStun;
				defenceBeforeStun = 0;
				stuned = false;
			}
		}
		if(defence < 1)
		{
			Instantiate(exp, transform.position, transform.rotation);
			Destroy (gameObject);
		}

		if(stuned == true)
		{
			transform.position = transform.position;
			if(defenceBeforeStun == 0){
				defenceBeforeStun = defence;
				defence = defence * 0.30f;
			}
		}
		else{
			Distance = Vector3.Distance (myTransform.position,Target.transform.position);
			if(Distance < 30)
			{
				audio.volume = 0.3f;
				audio.PlayOneShot(MonsterSound);
				transform.LookAt (Target.transform);
				transform.position += transform.forward*MoveSpeed*Time.deltaTime;
				
			}else{
				audio.volume = 0.0f;
				transform.position += transform.forward*MoveSpeed*Time.deltaTime;
				if(ticTime == timeToTurn - 1){
					RandNum = Random.Range (0,180);
					Vector3 randomDirection = new Vector3 (0, RandNum, 0);
					transform.Rotate (randomDirection);
				}
			}
		}
		if(transform.position.y < 5|| transform.position.y > 6){
			transform.position = new Vector3 (transform.position.x,  5.5f,transform.position.z);
		}

	}

	
	public void OnTriggerEnter(Collider other) 
	{
		if(other.tag == "SpawnPoint"){
			Vector3 randomDirection = new Vector3 (0, 150, 0);
			transform.position += transform.forward*MoveSpeed*Time.deltaTime;
			transform.Rotate (randomDirection);
		}
		else if(other.tag == "Enemy"){
			Vector3 randomDirection = new Vector3 (0, 150, 0);
			transform.position += transform.forward*MoveSpeed*Time.deltaTime;
			transform.Rotate (randomDirection);
		}
		else if(other.tag == "Terrain"){
			transform.position += transform.forward*MoveSpeed*Time.deltaTime;
			transform.Rotate (new Vector3 (0, 150, 0));
		}
		else if(other.tag == "Boundery"){
			transform.position += transform.forward*MoveSpeed*Time.deltaTime;
			transform.Rotate (new Vector3 (0, 150, 0));
		}
	}



}
