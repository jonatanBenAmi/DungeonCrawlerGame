using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]  //makes sure that we have the character controller script

public class Controls : MonoBehaviour {

	public float moveMentSpeed = 10.0f; //used determine the move speed 10 instances per frame.
	public float verticalVelocity = 0;

	private float fireRate;
	private float boosterTime;
	private float jumpspeed;
	private float nextFire;

	public GameObject bullet;
	public Transform shotSpawn;
	public Transform target;

	public AudioClip shotSound;

	public int health; // mounght og lives(how many times you can be hit by the objects
	public Texture heart; // variable that will store my Health icon

	
	CharacterController cc;


	void Start () 
	{
		boosterTime = 0.0f;
		health = 3;
		fireRate = 1.0f;
		nextFire = 0.0f;
		jumpspeed = 6.0f;
     	cc = GetComponent<CharacterController>(); //to declare our character
	}

	void Update () 
	{
		if (boosterTime != 0){
			boosterTime -= Time.time;
		}else {
			fireRate = 0.2f;
		}
		if (Input.GetButton ("Fire1") && Time.time > nextFire) 
		{
			audio.PlayOneShot (shotSound);
			nextFire = Time.time + fireRate;
			Instantiate(bullet, shotSpawn.position, shotSpawn.rotation); //as GameObject;
		}
		if(health ==0){   // if my health is 0, then restart the game
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
		 
	                                                
		

		

		//loosing health by enemy impact



		
	
	
	
	}
	// detects collosion with different objects
	void OnTriggerEnter(Collider other)
	{  
		// all objects with the Enemy tag
		// will take one of you health values
		if(other.gameObject.tag =="Enemy"){ 
			health--;
		}else if(other.gameObject.name == "firerateBooster") {
			fireRate = 0.05f;
			boosterTime = 100.0f;
			Destroy(other.gameObject);
		}

	}

	//GUI on the SCREEN

	void OnGUI(){ //function that instantiates what you wish to diskplay on the game screen.
		if(health!=0){ // if the health is not zero
			for (int i=0;i<health;i++){ //for loop used to print out 
				int posx = 50+50*i; //variable 
				GUI.DrawTexture(new Rect(posx,50,50,50),heart);
			}
			
		} 
	
	}
}
	
