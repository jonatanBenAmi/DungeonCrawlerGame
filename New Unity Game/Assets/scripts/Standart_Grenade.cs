using UnityEngine;
using System.Collections;

public class Standart_Grenade : Grenade_Class 
{
	
	public override void Update () 
	{
		if(explode)
		{
			Instantiate(explosionGraphics, transform.position, transform.rotation);
			AudioSource.PlayClipAtPoint(explosionSound, transform.position);
			Destroy(gameObject);
		}
		if(grenadeTimer.eventTimer())
		{
			explode = true;
		}
	}
	
	public override void OnTriggerStay(Collider other)
	{
		GameObject collisionObject;

		if(explode == true)
		{
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
