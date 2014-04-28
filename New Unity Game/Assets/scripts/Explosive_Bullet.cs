using UnityEngine;
using System.Collections;

public class Explosive_Bullet : Bullet_Class {

	public GameObject explosionGraphics;
	private float triggerRadius;
	private bool expandAttack;

	public override void Start () 
	{
		damage = 10.0f;
		penetrationPower = 2;
		bulletVelocity = 40.0f;

		expandAttack = false;
		triggerRadius = 10.0f;

		rigidbody.velocity = transform.forward * bulletVelocity;
	}
	
	
	public override void Update () 
	{
		if(transform.position.y > 10.0f)
		{
			Instantiate(explosionGraphics, transform.position, transform.rotation);
			Destroy(gameObject);
		}
		else if(penetrationPower < 1)
		{
			Instantiate(explosionGraphics, transform.position, transform.rotation);
			Destroy(gameObject);
		}
		else if(expandAttack == true)
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
	}

}
