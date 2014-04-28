using UnityEngine;
using System.Collections;

public class Weapons_Class : MonoBehaviour
{

	protected Event_Timer weaponTimer;

	public float rateOfFire;
	public Transform barrelEnd;
	public GameObject[] ammunitionType;
	public int[] ammunitionStock;

	public Texture[] ammunitionGui; 
	public AudioClip gunFire;

	protected bool triggerTick;
	protected int ammunitionChoise;

	public virtual void Start()
	{

	}
	public virtual  void FixedUpdate()
	{

	}
	public virtual void fireWeapon()
	{

	}
	
	public int AmmunitionChoise
	{
		get {return ammunitionChoise;}
		set {ammunitionChoise = value;}
	}
}
