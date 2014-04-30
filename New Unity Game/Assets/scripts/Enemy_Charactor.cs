using UnityEngine;
using System.Collections;

public class Enemy_Charactor : Charactor_Class
{
	// as this extends Charactor class it hold the same variable 
	// as charactor_class

	// unityDefined gameobject need to be public in order for us to assign
	// them in inspector

	// explosion/unity
	public GameObject explosionGraphics;
	// the enemy sound is stored in this variable
	public AudioClip sentrySound;

	// used to determine if the enemy has a target
	protected float distanceToTarget;

	// if it has a target its tranform is saved in this var
	protected Transform target;
	// stores the timers responce
	protected bool timerTick;

	// holds the enemies defence before stun
	protected float tmpDefence;
	// how much damage the player will get on impact with
	// the enemy
	protected float contactAttack;

	// expecting child class to have a override function start()
	public virtual void Start () 
	{
	
	}
	

	// expecting child class to have a override function Update()
	public virtual void Update () 
	{
	
	}
	// set for Target
	public Transform Target
	{
		set {target = value;}
	}
	// set/get ContactAttack
	public float ContactAttack
	{
		get {return contactAttack;}
		set {contactAttack = value;}
	}
}
