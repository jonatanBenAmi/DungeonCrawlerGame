using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]  //makes sure that we have the character controller script

public class Controls : MonoBehaviour {

	public float moveMentSpeed = 10.0f; //used determine the move speed 10 instances per frame.
	public float verticalVelocity = 0;

	private float jumpspeed;
	private float nextFire;
	private int bulletChoise;
	private int grenadeChoise;
	public int[] bulletsLeft;
	public int[] grenadesLeft;

	public float fireRate;
	public float throwRate;
	public float boosterTime;

	public int health;


	public GameObject bullet;
	public GameObject grenade;
	public GameObject powerGrenade;

	public Transform shotSpawn;
	public Transform grenadeSpawn;
	//public Transform target;
	public AudioClip shotSound;
	
	 // mounght og lives(how many times you can be hit by the objects
	public Texture healthGui; // variable that will store my Health icon
	public Texture ammoGui; 
	public Texture grenadeGui; 
	public Texture powerGrenadeGui; 
	public Texture firerateGui; 

	//private float timer;

	CharacterController cc;


	void Start () 
	{
		bulletsLeft = new int[2]{0,0};
		grenadesLeft = new int[2]{0,0};
		bulletChoise = 0;
		grenadeChoise = 1;
		boosterTime = 0.0f;
		health = 3;
		fireRate = 0.5f;
		throwRate = 2.0f;
		nextFire = 0.0f;
		jumpspeed = 6.0f;
     	cc = GetComponent<CharacterController>(); //to declare our character
	}

	void Update () 
	{
		if (boosterTime > 0){
			boosterTime -= Time.deltaTime;
		}else {
			fireRate = 0.5f;
		}
		if (Input.GetButton ("Fire1") && Time.time > nextFire && bulletsLeft[bulletChoise] > 0) 
		{
			if(bulletChoise == 0 && bulletsLeft[0] > 0){
				audio.PlayOneShot (shotSound);
				bulletsLeft[bulletChoise]--;
				nextFire = Time.time + fireRate;
				Instantiate(bullet, shotSpawn.position, shotSpawn.rotation); //as GameObject;
			}

		}
		if (Input.GetButton ("Fire2") && Time.time > nextFire ) 
		{
			if(grenadeChoise == 0 && grenadesLeft[0] > 0){
				grenadesLeft[0]--;
				nextFire = Time.time + throwRate;
				Instantiate(grenade, grenadeSpawn.position, grenadeSpawn.rotation); //as GameObject;
			}else if (grenadeChoise == 1 && grenadesLeft[1] > 0){
				grenadesLeft[1]--;
				nextFire = Time.time + throwRate;
				Instantiate(powerGrenade, grenadeSpawn.position, grenadeSpawn.rotation); //as GameObject;
			}
		}
		if(Input.GetKeyDown(KeyCode.Alpha1)){
			if(++bulletChoise > 1)
			{
				bulletChoise = 0;
			}
		}else if(Input.GetKeyDown(KeyCode.Alpha2)){
			grenadeChoise++;
			if(grenadeChoise > 1){
				grenadeChoise = 0;
			}
		}


		if(health < 1){   // if my health is 0, then restart the game
			Application.LoadLevel(0);
		}
		
		//movement
		//taking input from the keyboard(up and down) and multiplying with speed
		float forwardSpeed=Input.GetAxis ("Vertical")*moveMentSpeed; 
		float sideSpeed= Input.GetAxis("Horizontal")*moveMentSpeed;
	
		verticalVelocity += Physics.gravity.y * Time.deltaTime;
		if (verticalVelocity < -1){
			verticalVelocity = -1;
		}

	    if(cc.isGrounded && Input.GetButtonDown("Jump")){
			verticalVelocity = jumpspeed;
		}
		// uses the CharacterController script, moving it in the moveDirection
		// Time.deltaTime gives a smooth transission
		Vector3 speed = new Vector3(sideSpeed, verticalVelocity,-forwardSpeed);
		speed = transform.rotation * speed;
		cc.Move (speed * Time.deltaTime);   


	}
	// detects collosion with different objects
	void OnTriggerEnter(Collider other)
	{ 
		if(other.gameObject.tag =="Enemy")
		{ 
			health--;
		}
	}


	//GUI on the SCREEN

	void OnGUI(){ //function that instantiates what you wish to diskplay on the game screen.
		if(health!=0){ // if the health is not zero
			for (int i=0;i<health;i++){ //for loop used to print out 
				int posy = 60*i; //variable 
				GUI.DrawTexture(new Rect(0,posy,60,60),healthGui);
			}
		} 
		if(boosterTime > 0){
			GUI.TextField(new Rect(Screen.width/2,0,80,60), "Booster " + boosterTime);
			GUI.DrawTexture(new Rect(Screen.width/2 + 6,20,70,30),firerateGui);
		}
		if(bulletChoise == 0)
		{
			GUI.TextField(new Rect(Screen.width - 80,0,80,60),bulletsLeft[0] + "x ");
			GUI.DrawTexture(new Rect(Screen.width - 60,16,50,40),ammoGui);
		}else if(bulletChoise == 1)
		{
			GUI.TextField(new Rect(Screen.width - 80,0,80,60),bulletsLeft[1] + "x ");
			//GUI.DrawTexture(new Rect(Screen.width - 60,16,50,50),ammoGui);
		}
		if(grenadeChoise == 0)
			{
			GUI.TextField(new Rect(Screen.width - 80,60,80,60),grenadesLeft[0] + "x ");
			GUI.DrawTexture(new Rect(Screen.width - 55,66,50,50),grenadeGui);
		}else if(grenadeChoise == 1)
			{
			GUI.TextField(new Rect(Screen.width - 80,60,80,60),grenadesLeft[1] + "x ");
			GUI.DrawTexture(new Rect(Screen.width - 55,66,50,50),powerGrenadeGui);
		}
	}
}
	
