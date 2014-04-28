using UnityEngine;
using System.Collections;

public class Standart_Bullet : Bullet_Class 
{


	public override void Start () 
	{
		damage = 3.0f;
		penetrationPower = 1;
		bulletVelocity = 40.0f;

		rigidbody.velocity = transform.forward * bulletVelocity;
	}
	

	public override void Update () 
	{
		if(transform.position.y > 10.0f){
			Destroy(gameObject);
		}else if(penetrationPower < 1){
			Destroy(gameObject);
		}
	}

	public override void OnTriggerEnter(Collider other)
	{
		GameObject collisionObject;
		bool isArmored;

		collisionObject = other.gameObject;

		if(other.tag == "Enemy")
		{
			if(collisionObject != null)
			{
				penetrationPower--;
				Charactor_Class script = collisionObject.GetComponent<Charactor_Class>();
				float tmp = script.armorStrength;
				isArmored = (tmp > 0)? true:false;
				
				if(isArmored)
				{
					script.armorStrength -= damage;
				}
				else
				{
					script.defence -= damage;
				}
			}
		}
		if(other.tag == "Player")
		{
			penetrationPower--;
			Charactor_Class script = collisionObject.GetComponent<Charactor_Class>();
			isArmored = (script.armorStrength > 0)? true:false;
			
			if(isArmored)
			{
				script.armorStrength -= damage;
			}
			else
			{
				script.defence -= damage;
			}
		}
	}

	public override void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.tag == "Terrain")
		{
			penetrationPower = 0;
		}
		else if(col.gameObject.tag == "SpawnPoint")
		{
			penetrationPower = 0;
		}
		else if(col.gameObject.tag == "Bullet")
		{
			penetrationPower = 0;
		}
	}

}
