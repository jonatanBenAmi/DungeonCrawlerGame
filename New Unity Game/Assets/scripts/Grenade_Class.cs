using UnityEngine;
using System.Collections;

public class Grenade_Class : MonoBehaviour 
{

	protected Event_Timer grenadeTimer; //will be used to master the fuseTime of the grenade and 
	public float damage; //variable that holds the damage value
	public float fuseTime; //variable that holds the fuse time of the grenade
	public float throwSpeed; //variable that holds the throw speed
	protected bool explode; //variable that is used to "simulate" an explosion in code
	
	public GameObject explosionGraphics; //Variable that is used to store the explosion graphic taken from unitys own assets
	public AudioClip explosionSound; //variable that will hold the sound effect 

	public void Start () 
	{
		explode = false; //is set to false from the start and when hitting a object, it will be set to true and dialate the trigger/collider
		grenadeTimer = new Event_Timer(fuseTime, true); //here you have a new eventtimer that loops arcoding to the fuseTime
		rigidbody.velocity = transform.forward * throwSpeed; //generating the throw of the grenade mowing it forward and arcoding to the throwspeed
	}

	public virtual void Update () 
	{
	
	}

	public virtual void OnTriggerStay(Collider other) //it stays in the area insted of outside the area
	{
		
	}
}
