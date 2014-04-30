using UnityEngine;
using System.Collections;

public class Explosive_Bullet : Bullet_Class {

	public GameObject explosionGraphics; //storing the explosion in graphics
	private float triggerRadius; //will hold the radius of the trigger
	private bool expandAttack; // if set to true, dialate the collider of the bullet (will be used for this)

	public override void Start () 
	{
		damage = 10.0f; //set damage value to ten
		penetrationPower = 2; //set penetration power to 2
		bulletVelocity = 40.0f;  //the velocity to 40

		expandAttack = false;  //stand at false, will change to true later
		triggerRadius = 10.0f; //set the trigger radiue

		rigidbody.velocity = transform.forward * bulletVelocity; //moves the bullet forward arcoding to the velocity
	}
	
	
	public override void Update () 
	{
		if(transform.position.y > 10.0f) //makes sure that the bullet won't fly to hight
		{
			Instantiate(explosionGraphics, transform.position, transform.rotation);
			Destroy(gameObject);
		}
		else if(penetrationPower < 1) //if the penetration power is under 1, also make the bullet explode
		{
			Instantiate(explosionGraphics, transform.position, transform.rotation);
			Destroy(gameObject);
		}
		else if(expandAttack == true)  //will be used to make the collider expand when the bullet explodes
		{
			SphereCollider thisCollider = transform.GetComponent<SphereCollider>();
			thisCollider.radius = triggerRadius;
		}
	}
	
	public override void OnTriggerEnter(Collider other)
	{
		GameObject collisionObject;
		
		if(other.tag == "Enemy")
		{
			if(expandAttack == false)
			{
				expandAttack = true;
			}
			else if(expandAttack == true)
			{
				collisionObject = other.gameObject;
				Charactor_Class script = collisionObject.GetComponent<Charactor_Class>();
				bool isArmored = (script.armorStrength > 0)? true:false;
				
				if(isArmored)
				{
					script.armorStrength -= damage;
					script.defence -= damage;
				}
				else
				{
					script.defence -= damage;
				}
				penetrationPower = 0;
			}
		}
		else if(other.tag == "Player")
		{
			if(expandAttack == true)
			{
				collisionObject = other.gameObject;
				Charactor_Class script = collisionObject.GetComponent<Charactor_Class>();
				bool isArmored = (script.armorStrength > 0)? true:false;
				
				if(isArmored)
				{
					script.armorStrength -= damage;
					script.defence -= damage;
				}
				else
				{
					script.defence -= damage;
				}
				penetrationPower = 0;
			}
		}
		else if(other.tag == "SpawnPoint")
		{
			if(expandAttack == true)
			{
				collisionObject = other.gameObject;
				strongholdScript script = collisionObject.GetComponent<strongholdScript>();

				script.defence -= damage;

				penetrationPower = 0;
			}
		}
	}
	
	public override void OnCollisionEnter(Collision col)
	{
		GameObject collisionObject;

		penetrationPower--;

		if(col.gameObject.tag == "Terrain")
		{
			if(expandAttack == false)
			{
				expandAttack = true;
			}
		}
		else if(col.gameObject.tag == "SpawnPoint")
		{
			if(expandAttack == false)
			{
				expandAttack = true;
			}
			else if(expandAttack == true)
			{
				collisionObject = col.gameObject;
				strongholdScript script = collisionObject.GetComponent<strongholdScript>();
				script.defence -= damage;
				penetrationPower = 0;
			}
		}
		else if(col.gameObject.tag == "Bullet")
		{
			penetrationPower--;
		}
	}

}
