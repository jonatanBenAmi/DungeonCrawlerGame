using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]  //makes sure that we have the character controller script

public class Controls : MonoBehaviour {
	public float moveMentSpeed = 10.0f; //used determine the move speed 10 instances per frame.
	public float verticalVelocity = 0;
	public float jumpspeed = 10.0f;
	public float fireRate = 0.05f;
	private float nextFire = 0;
	public float depth = 10; //using for mouse look
	public GameObject bullet;
	public Transform shotSpawn;
	public Transform target;
	public AudioClip shotSound;
	public int health; // mounght og lives(how many times you can be hit by the objects
	public Texture heart; // variable that will store my Health icon

	
	CharacterController cc;
	// Use this for initialization
	void Start () {
     cc = GetComponent<CharacterController>(); //to declare our character
		health = 1;

	}
	
	 
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton ("Fire1") && Time.time > nextFire) {
			audio.PlayOneShot (shotSound);
			nextFire = Time.time + fireRate;
				Instantiate(bullet, shotSpawn.position, shotSpawn.rotation); //as GameObject;
		}
		if(health ==0){   // if my health is 0, then restart the game
			Application.LoadLevel(0);
		}
		
		//movement
		
		float forwardSpeed=Input.GetAxis ("Vertical")*moveMentSpeed; //taking input from the keyboard(up and down) and multiplying with speed
		float sideSpeed= Input.GetAxis("Horizontal")*moveMentSpeed;
		
		verticalVelocity += Physics.gravity.y * Time.deltaTime;
		
	    if(cc.isGrounded && Input.GetButtonDown("Jump")){
			verticalVelocity = jumpspeed;
		}
		
		Vector3 speed = new Vector3(sideSpeed, verticalVelocity,-forwardSpeed);
		
		speed = transform.rotation * speed;
		
		
		
	
		
		
  
		
		cc.Move (speed * Time.deltaTime);   // uses the CharacterController script, moving it in the moveDirection
		 
	                                               //Time.deltaTime gives a smooth transission 
		

		

		//loosing health by enemy impact



		
	
	
	
	}
	void OnTriggerEnter(Collider other){  // detects collosion with different objects
		
		if(other.gameObject.tag =="Enemy"){ //all objects with the Enemy tag
			health--;
		} // will take one of you health values
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
	
