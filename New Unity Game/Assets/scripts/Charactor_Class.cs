using UnityEngine;
using System.Collections;


public class Charactor_Class : MonoBehaviour 
{
	// timer to control internal behavior
	public Event_Timer charactorTimer;
	// howFast can the object move
	public float movementSpeed;
	// how well defended
	public float defence;
	// how strong armor
	public float armorStrength;
	// used to control weapon effect of stun grenade
	protected bool stuned;
	// not used at the moment
	protected float affectTimer;


	// expecting child class to have a override function start()
	public virtual void Start () 
	{
	
	}
	// expecting child class to have a override function Update()
	public virtual void Update () 
	{
	
	}
	// get/set for the bool stuned
	public bool Stuned
	{
		get {return stuned;}
		set {stuned = value;}
	}
}
