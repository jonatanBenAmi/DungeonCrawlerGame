using UnityEngine;
using System.Collections;

public class Enemy_Charactor : Charactor_Class
{
	public GameObject explosionGraphics;
	public AudioClip sentrySound;
	
	protected float distanceToTarget;
	protected Transform target;
	protected bool timerTick;
	protected float tmpDefence;
	protected float contactAttack;


	public virtual void Start () 
	{
	
	}
	


	public virtual void Update () 
	{
	
	}

	public Transform Target
	{
		set {target = value;}
	}
	public float ContactAttack
	{
		get {return contactAttack;}
		set {contactAttack = value;}
	}
}
