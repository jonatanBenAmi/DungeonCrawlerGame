using UnityEngine;
using System.Collections;


public class Charactor_Class : MonoBehaviour 
{

	public Event_Timer charactorTimer;

	public float movementSpeed;
	public float defence;
	public float armorStrength;

	protected bool stuned;
	protected float affectTimer;

	public virtual void Start () 
	{
	
	}

	public virtual void Update () 
	{
	
	}
	public bool Stuned
	{
		get {return stuned;}
		set {stuned = value;}
	}
}
