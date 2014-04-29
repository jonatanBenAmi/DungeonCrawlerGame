using UnityEngine;
using System.Collections;

public class Dart_Bullet : Bullet_Class {

	public override void Start () 
	{
		damage = 3.0f;  //overall bullet damage to health
		penetrationPower = 3; //how many enemies the bullet can penetrate
		bulletVelocity = 40.0f; //Bullet Velocity
		
		rigidbody.velocity = transform.forward * bulletVelocity; //make the bullet shoot forward
	}
	
	
	public override void Update () 
	{
		if(transform.position.y > 10.0f){ //if the bullet is located higher than 10.0f 
			Destroy(gameObject); //then destory the bullet
		}else if(penetrationPower < 1){ //if the penetration power is less than 1
			Destroy(gameObject); //destroy the bullet
		}
	}
	
	public override void OnTriggerEnter(Collider other)
	{
		GameObject collisionObject;
		
		if(other.tag == "Enemy")
		{
			penetrationPower--; //if the bullet hits an enemy, it will only be able to penetrate two more 
			collisionObject = other.gameObject; //get the characteristics of the enemy gameobject
			Charactor_Class script = collisionObject.GetComponent<Charactor_Class>();
			bool isArmored = (script.armorStrength > 0)? true:false; //evaluates

			if(isArmored)  //if this is set to true
			{
				script.armorStrength -= 3 * damage; //then this will happen
				script.defence -= damage;
			}
			else
			{
				script.defence -= damage; 
			}
		}
		if(other.tag == "Player")
		{
			penetrationPower--;
			collisionObject = other.gameObject;
			Charactor_Class script = collisionObject.GetComponent<Charactor_Class>();
			bool isArmored = (script.armorStrength > 0)? true:false;
			
			if(isArmored)
			{
				script.armorStrength -= 3 * damage;
				script.defence -= damage;
			}
			else
			{
				script.defence -= damage;
			}
		}
	}
	
	public override void OnCollisionEnter(Collision col)
	{
		GameObject collisionObject;
		
		if(col.gameObject.tag == "Terrain")
		{
			penetrationPower = 0;
		}else if(col.gameObject.tag == "SpawnPoint")
		{
			penetrationPower = 0;
		}
		else if(col.gameObject.tag == "Bullet")
		{
			penetrationPower--;
		}
	}

}
