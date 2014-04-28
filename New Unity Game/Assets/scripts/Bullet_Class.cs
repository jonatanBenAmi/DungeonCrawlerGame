using UnityEngine;
using System.Collections;

public class Bullet_Class : MonoBehaviour 
{
	public float damage;
	protected int penetrationPower;
	protected float bulletVelocity;
	
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
		get { return bulletVelocity;}
		set {bulletVelocity = value;}
	}
}
