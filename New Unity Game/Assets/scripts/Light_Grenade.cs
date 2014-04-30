using UnityEngine;
using System.Collections;

public class Light_Grenade : Grenade_Class {  //extends the grenade class and starts the countdown


	public override void Update () 
	{
		transform.Rotate(Vector3.forward * 600 * Time.deltaTime);

		if(explode) //is explode is set to true
		{
			Instantiate(explosionGraphics, transform.position, transform.rotation); //instantiate the explosionGraphics at the grenade position and rotation
			AudioSource.PlayClipAtPoint(explosionSound, transform.position); //play the audioClip from the postion *boooooom!*
			Destroy(gameObject); //and destroy the gameObject of the grenade
		}
		if(grenadeTimer.eventTimer()) //allows the grenade to explode
		{
			explode = true;
		}
	}

	public override void OnTriggerStay(Collider other) //if hitting a object stay at this position
	{
		GameObject collisionObject; //variable that holds the collision Object of the grenade

		GameObject player = GameObject.Find("Avatar"); //variable that finds the tagget avatar

		if(other.tag == "Enemy" ) //if the enemy
		{
			collisionObject = other.gameObject; //sets the collision object to an enemy
			Enemy_Charactor script = collisionObject.GetComponent<Enemy_Charactor>(); //add the enemy_charactor scrpit to the current collision object
			script.Target = transform; //do the magic of the grenade against the enemy and make the enemy follow the grenade
		}
		if(explode)
		{
			if(other.tag == "Enemy" ) //if the grenade does not catch the attention of the enemy, make the enemy still look at the player
			{
				collisionObject = other.gameObject;
				Enemy_Charactor script = collisionObject.GetComponent<Enemy_Charactor>();
				script.Target = player.transform;
			}
		}
	}
}
