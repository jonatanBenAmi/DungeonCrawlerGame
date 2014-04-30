using UnityEngine;
using System.Collections;

public class Bullet_Class : MonoBehaviour 
{
	public float damage; //holds the damage
	protected int penetrationPower; //holds the penetration power
	protected float bulletVelocity; //the velocity of the bullet
	
	public virtual void  Start () 
	{
		
	}
	public virtual void Update () 
	{
	
	}
	public virtual void OnTriggerEnter(Collider other)
	{

	}
	public virtual void OnTriggerStay(Collider other)
	{
		
	}
	public virtual void OnCollisionEnter(Collision col)
	{

	}
	public float BulletVelocity
	{
		get { return bulletVelocity;}  //getting and setting the value of the bullet velocity, which will be used in the childs of bullet_class
		set {bulletVelocity = value;}
	}
}
