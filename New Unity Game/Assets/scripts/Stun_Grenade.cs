using UnityEngine;
using System.Collections;

public class Stun_Grenade : Grenade_Class //use the grenade_classs
{

	public override void Update () 
	{
		if(explode) //if explode
		{
			Instantiate(explosionGraphics, transform.position, transform.rotation); //instantiate the explosion, at the position and rotation of the object
			AudioSource.PlayClipAtPoint(explosionSound, transform.position); //blay the *boooom*
			Destroy(gameObject); //and destroy the grenade object
		}
		if(grenadeTimer.eventTimer()) //the same as former grenade scripts
		{
			explode = true;
		}
	}
	
	public override void OnTriggerStay(Collider other) //same as former grenade scripts
	{
		GameObject collisionObject;

		if(explode)
		{
			if(other.tag == "Enemy" ) //if the grenade explodes at the enemy
			{
				collisionObject = other.gameObject; //set the collision to the enemy object/same as other grenades
				Charactor_Class script = collisionObject.GetComponent<Charactor_Class>(); //look at the other grenade scripts fx stungreade
				script.Stuned = true; //sets it to true so that the enemy is able to stand still
				script.charactorTimer.TimeToNextTick = 1000.0f; //the stand still value
				script.charactorTimer.TimeTicking = 0.0f;
			}
			if(other.tag == "Player" )  //same here, but different because it is headed at a player/the avatar
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
