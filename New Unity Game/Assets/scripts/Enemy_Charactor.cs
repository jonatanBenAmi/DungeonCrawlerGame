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
}
