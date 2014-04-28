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
				Charactor_Class script = collisionObject.GetComponent<Charactor_Class>();
				script.Stuned = true;
				script.charactorTimer.TimeToNextTick = 1000.0f;
				script.charactorTimer.TimeTicking = 0.0f;
			}
			if(other.tag == "Player" )
			{
				collisionObject = other.gameObject;
				Charactor_Class script = collisionObject.GetComponent<Charactor_Class>();
				script.Stuned = true;
				script.charactorTimer.TimeToNextTick = 200.0f;
				script.charactorTimer.TimeTicking = 0.0f;
			}
		}
	}
}
