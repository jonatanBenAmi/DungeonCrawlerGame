using UnityEngine;
using System.Collections;

public class Sentry_Enemy : Enemy_Charactor {
	
	
	public override void Start () 
	{
		// giving variables values fitting for there purpose
		GameObject player = GameObject.Find("Avatar");
		
		target = player.transform;
		movementSpeed = 7.0f;
		defence = 15.0f;
		armorStrength = 0.0f;
		stuned = false;
		affectTimer = 0f;
		timerTick = false;
		contactAttack = 20.0f;
		
		charactorTimer = new Event_Timer(affectTimer, true);
	}
	
	public override void Update () 
	{
		// find player 
		GameObject player = GameObject.Find("Avatar");
		// find scrips for the weapon and the player
		Enemy_Weapon script = gameObject.GetComponent<Enemy_Weapon>();
		Player_Charactor charScript = player.GetComponent<Player_Charactor>();

		// if enemy is dead
		if(defence < 1)
		{
			// adds enemykills to player counter
			charScript.EnemyKills++;
			// explosion on position
			Instantiate(explosionGraphics, transform.position, transform.rotation);
			// destroy object
			Destroy (gameObject);
		}
		// if timer is true
		if(charactorTimer.eventTimer())
		{
			timerTick = true;
		}

		if(timerTick)
		{
			// if the enemy is stuned set it to false
			if(stuned)
			{
				stuned = false;
			}
		}
		// if the enemy is stuned then stand still
		if(stuned)
		{
			transform.position = transform.position;
		}
		// else
		else
		{
			// calculate distance to target
			distanceToTarget = Vector3.Distance (transform.position,target.position);
			// if timer ticks change direction
			if(timerTick)
			{
				Vector3 randomDirection = new Vector3 (0, Random.Range (0,180), 0);
				transform.Rotate (randomDirection);
			}
			// if distance is between less then 20 and greater then 6
			if(distanceToTarget > 6 && distanceToTarget < 20)
			{
				// play enemy sound
				audio.volume = 0.3f;
				audio.PlayOneShot(sentrySound);
				// turn to face target
				transform.LookAt (target);
				// move towards target
				transform.position += transform.forward*movementSpeed*Time.deltaTime;
				// fire on target
				script.openFire = true;
			}
			// if distance is less or equal to 6
			else if(distanceToTarget <= 6)
			{
				// play enemy sound
				audio.PlayOneShot(sentrySound);
				// stand still
				transform.position = transform.position;
				// turn to target
				transform.LookAt (target);
			}
			// if nothing else was true then do this
			else 
			{
				// move
				transform.position += transform.forward*movementSpeed*Time.deltaTime;
				// dont shoot
				script.openFire = false;
			}

		}
		// making sure that enemy is in a height so the player can hit it
		if(transform.position.y < 5|| transform.position.y > 7){
			transform.position = new Vector3 (transform.position.x, 6f,transform.position.z);
		}

	}
	public void OnTriggerEnter(Collider other) 
	{
		// turn 150 degress if you hit anything with these tags
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
