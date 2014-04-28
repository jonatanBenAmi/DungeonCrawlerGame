using UnityEngine;
using System.Collections;

public class Grenade_Class : MonoBehaviour 
{

	protected Event_Timer grenadeTimer;
	public float damage;
	public float fuseTime;
	public float throwSpeed;
	protected bool explode;
	
	public GameObject explosionGraphics;
	public AudioClip explosionSound;

	public void Start () 
	{
		explode = false;
		grenadeTimer = new Event_Timer(fuseTime, true);
		rigidbody.velocity = transform.forward * throwSpeed;
	}

	public virtual void Update () 
	{
	
	}

	public virtual void OnTriggerStay(Collider other)
	{
		
	}
}
