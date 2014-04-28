using UnityEngine;
using System.Collections;

public class Guard_Enemy : Enemy_Charactor {

	public override void Start () 
	{
		GameObject player = GameObject.Find("Avatar");
		
		target = player.transform;
		movementSpeed = 7.0f;
		defence = 30.0f;
		armorStrength = 20.0f;
		stuned = false;
		affectTimer = 0f;
		timerTick = false;
		
		charactorTimer = new Event_Timer(affectTimer, true);
	}
	
	public override void Update () 
	{

		
		if(defence < 1)
		{
			Instantiate(explosionGraphics, transform.position, transform.rotation);
			Destroy (gameObject);
		}
		
		if(charactorTimer.eventTimer())
		{
			timerTick = true;
		}
		
		if(timerTick)
		{
			if(stuned)
			{
				stuned = false;
			}
		}
		
		if(stuned)
		{
			transform.position = transform.position;
		}
		else
		{
			distanceToTarget = Vector3.Distance (transform.position,target.position);
			
			if(distanceToTarget < 30)
			{
				audio.volume = 0.3f;
				audio.PlayOneShot(sentrySound);
				transform.LookAt (target);
				transform.position += transform.forward*movementSpeed*Time.deltaTime;
			}
			else if(distanceToTarget < 6)
			{
				audio.PlayOneShot(sentrySound);
				transform.position += transform.forward*(movementSpeed/10)*Time.deltaTime;
				transform.LookAt (target);
			}
			else
			{
				transform.position += transform.forward*movementSpeed*Time.deltaTime;
				if(timerTick){
					Vector3 randomDirection = new Vector3 (0, Random.Range (0,180), 0);
					transform.Rotate (randomDirection);
				}
			}
		}
		if(transform.position.y < 5|| transform.position.y > 7){
			transform.position = new Vector3 (transform.position.x, 6f,transform.position.z);
		}
		
		Debug.Log(defence);
	}
	public void OnTriggerEnter(Collider other) 
	{
		if(other.tag == "SpawnPoint"){
			Vector3 randomDirection = new Vector3 (0, 150, 0);
			transform.position += transform.forward*movementSpeed*Time.deltaTime;
			transform.Rotate (randomDirection);
		}
		else if(other.tag == "Enemy"){
			Vector3 randomDirection = new Vector3 (0, 150, 0);
			transform.position += transform.forward*movementSpeed*Time.deltaTime;
			transform.Rotate (randomDirection);
		}
		else if(other.tag == "Terrain"){
			transform.position += transform.forward*movementSpeed*Time.deltaTime;
			transform.Rotate (new Vector3 (0, 150, 0));
		}
		else if(other.tag == "Boundery"){
			transform.position += transform.forward*movementSpeed*Time.deltaTime;
			transform.Rotate (new Vector3 (0, 150, 0));
		}
	}
}
