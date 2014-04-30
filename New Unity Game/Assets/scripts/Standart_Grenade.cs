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

		if(explode == true) //if the explode is set to true
		{
			if(other.tag == "Player" || other.tag == "Enemy" ) //and the object object are an enemy or our avatar(selfdamage)
			{	
				collisionObject = other.gameObject; //set the collision object to either the enemy or the avatar
				Charactor_Class script = collisionObject.GetComponent<Charactor_Class>(); //add thecharactor scrpit to the current collision object
				if(script.armorStrength > 0) //if the streng of the armor is above 0
				{
					script.armorStrength -= damage; //do damage to the armor
				}
				script.defence -= damage; //but also the general health
			}
	
			else if(other.tag == "SpawnPoint" ) //the same but with here doing damage to the stronghold instead
			{
				collisionObject = other.gameObject;
				strongholdScript script = collisionObject.GetComponent<strongholdScript>();
				script.defence -= damage;
			}
		}
	}
}
