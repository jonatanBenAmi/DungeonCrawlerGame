using UnityEngine;
using System.Collections;

public class grenadeScript : MonoBehaviour {

	public int damage;
	public int type;

	public float throwSpeed;

	public AudioClip grenadeSound;
	public GameObject exp;
	public float fuseTimer;

	private float stunTime;

	private float timeToDeto;

	void Start () 
	{
		timeToDeto = fuseTimer + Time.time;
		rigidbody.velocity = transform.forward * throwSpeed;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(timeToDeto == 0)
		{
			Instantiate(exp, transform.position, transform.rotation);
			Destroy(gameObject);
			AudioSource.PlayClipAtPoint(grenadeSound, transform.position);
		}
		else if(timeToDeto < Time.time)
		{
			timeToDeto = 0;
		}
	}

	public void OnTriggerStay(Collider other) 
	{
		GameObject collisionObject;
		if(timeToDeto == 0){
			if(type < 3){
				if(other.tag == "Player")
				{	
					collisionObject = other.gameObject;
					Controls script = collisionObject.GetComponent<Controls>();
					script.health -= damage;
				}
				else if(other.tag == "Enemy" )
				{
					collisionObject = other.gameObject;
					enemyMovement script = collisionObject.GetComponent<enemyMovement>();
					script.defence -= damage;
				
				}
				else if(other.tag == "SpawnPoint" )
				{
					collisionObject = other.gameObject;
					strongholdScript script = collisionObject.GetComponent<strongholdScript>();
					script.defence -= damage;
			 	}
			}else if(type == 4){
				if(other.tag == "Player")
				{	
					collisionObject = other.gameObject;
					Controls script = collisionObject.GetComponent<Controls>();
					script.health -= damage;
				}
				else if(other.tag == "Enemy" )
				{
					collisionObject = other.gameObject;
					enemyMovement script = collisionObject.GetComponent<enemyMovement>();
					script.stuned = true;
					script.timeToTurn = 500.0f;
					script.ticTime = 0.0f;
				}else if(other.tag == "SpawnPoint" )
				{
					collisionObject = other.gameObject;
					strongholdScript script = collisionObject.GetComponent<strongholdScript>();
					script.defence -= damage;
				}
			}else if (type > 4){
				if(other.tag == "Player")
				{	
					collisionObject = other.gameObject;
					Controls script = collisionObject.GetComponent<Controls>();
					script.health -= damage;
				}
				else if(other.tag == "Enemy" )
				{
					collisionObject = other.gameObject;
					enemyMovement script = collisionObject.GetComponent<enemyMovement>();
					script.defence -= damage;
					
				}
				else if(other.tag == "SpawnPoint" )
				{
					collisionObject = other.gameObject;
					strongholdScript script = collisionObject.GetComponent<strongholdScript>();
					script.defence -= damage;
				}
			}
		}
	}
}
