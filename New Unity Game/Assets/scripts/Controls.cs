using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]  //makes sure that we have the character controller script

public class Controls : MonoBehaviour {

	public float moveMentSpeed = 10.0f; //used determine the move speed 10 instances per frame.
	public float verticalVelocity = 0;

	private float jumpspeed;
	private float nextFire;

	public float fireRate;
	public float boosterTime;

	public int health;
	public int bulletsLeft;
	public int grenadesLeft;


	public GameObject bullet;
	public GameObject grenade;
	public Transform shotSpawn;
	public Transform grenadeSpawn;
	public Transform target;
	public AudioClip shotSound;
	
	 // mounght og lives(how many times you can be hit by the objects
	public Texture healthGui; // variable that will store my Health icon
	public Texture ammoGui; 


	private float timer;

	CharacterController cc;


	void Start () 
	{
		bulletsLeft = 30;
		boosterTime = 0.0f;
		health = 3;
		fireRate = 0.5f;
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
		if (Input.GetButton ("Fire1") && Time.time > nextFire && bulletsLeft > 0) 
		{
			audio.PlayOneShot (shotSound);
			bulletsLeft--;
			nextFire = Time.time + fireRate;
			Instantiate(bullet, shotSpawn.position, shotSpawn.rotation); //as GameObject;
		}
		if (Input.GetButton ("Fire2") && Time.time > nextFire && grenadesLeft > 0) 
		{
			grenadesLeft--;
			nextFire = Time.time + fireRate;
			Instantiate(grenade, grenadeSpawn.position, grenadeSpawn.rotation); //as GameObject;
		}
		if(health < 0){   // if my health is 0, then restart the game
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
				int posy = 50*i; //variable 
				GUI.DrawTexture(new Rect(0,posy,50,50),healthGui);
			}
		} 
		if(bulletsLeft > 30){ // if the health is not zero
			int numOfmags = bulletsLeft/30;
			for (int i=0;i<numOfmags;i++){ //for loop used to print out 
				int posy = 25*i; //variable 
				GUI.DrawTexture(new Rect(Screen.width - 50,posy,50,25),ammoGui);
			}
		} 
	}
}
	
