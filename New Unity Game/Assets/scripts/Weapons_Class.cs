using UnityEngine;
using System.Collections;

public class Weapons_Class : MonoBehaviour
{
	// timer to control firerate
	protected Event_Timer weaponTimer;

	// how fast should the weapon fire 
	public float rateOfFire;
	// were should bullets be fired from
	public Transform barrelEnd;
	// array to hold the bullet prefabs
	public GameObject[] ammunitionType;
	// how much ammunition of each
	public int[] ammunitionStock;
	// pictures of bullets
	public Texture[] ammunitionGui;
	// store audio
	public AudioClip[] gunFire;
	// timerTick
	protected bool triggerTick;
	// what bullet to fire 
	protected int ammunitionChoise;
	// expect an override function in child class 
	public virtual void Start()
	{

	}
	// expect an override function in child class
	public virtual  void FixedUpdate()
	{

	}
	// expect an override function in child class
	public virtual void fireWeapon()
	{

	}
	// get/set for ammo choise
	public int AmmunitionChoise
	{
		get {return ammunitionChoise;}
		set {ammunitionChoise = value;}
	}
}
