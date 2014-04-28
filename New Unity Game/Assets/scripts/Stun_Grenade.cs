using UnityEngine;
using System.Collections;

public class Stun_Grenade : Grenade_Class 
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

		if(explode)
		{
			if(other.tag == "Enemy" )
			{
				collisionObject = other.gameObject;
				enemyMovement script = collisionObject.GetComponent<enemyMovement>();
				script.stuned = true;
				script.enemyTimer.TimeToNextTick = 1000.0f;
				script.enemyTimer.TimeToNextTick = 0.0f;
			}
		}
	}
}
