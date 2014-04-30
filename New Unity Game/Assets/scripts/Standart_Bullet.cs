using UnityEngine;
using System.Collections;

public class Standart_Bullet : Bullet_Class 
{


	public override void Start () 
	{
		damage = 3.0f;//Setting damage to be 3
		penetrationPower = 1;//Setting the penetrationPower to 1
		bulletVelocity = 40.0f;//Setting velocity to 40

		rigidbody.velocity = transform.forward * bulletVelocity;//Setting the bulet to travel forward times the velocity
	}
	

	public override void Update () 
	{
		if(transform.position.y > 10.0f){//if statement checks if bullet is more than 10 away from starting position
			Destroy(gameObject);//Destroy bullet
		}else if(penetrationPower < 1){//Checks if the penetration power is lesser than 1
			Destroy(gameObject);//Destroy bullet
		}
	}

	public override void OnTriggerEnter(Collider other)//Collider function
	{
		GameObject collisionObject;//Creating gameObject calle collisionObject
		bool isArmored;//Boolean isArmored

		collisionObject = other.gameObject;//Setting collisionObject to be the gameObject that it collides with

		if(other.tag == "Enemy")//Checking if the gameObject is an enemy
		{
			if(collisionObject != null)//Checking if the collisionObject is not equal to null
			{
				penetrationPower--;//Minus 1 to the penetration power
				Charactor_Class script = collisionObject.GetComponent<Charactor_Class>();//Getting the character script
				float tmp = script.armorStrength;//Making a temporary float to store the amorStrength
				isArmored = (tmp > 0)? true:false;//If statement that sets isArmored to either true or false depending on tmp to be higher or lower than 0
				
				if(isArmored)//If statement checking if isArmored is true
				{
					script.armorStrength -= damage;//Minus amorstrength with damage
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
