using UnityEngine;
using System.Collections;

public class Dart_Bullet : Bullet_Class {

	public override void Start () 
	{
		damage = 3.0f;
		penetrationPower = 3;
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
		
		if(other.tag == "Enemy")
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
	}

}
