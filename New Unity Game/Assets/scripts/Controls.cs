using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]  //makes sure that we have the character controller script

public class Controls : MonoBehaviour {

	public float moveMentSpeed = 10.0f; //used determine the move speed 10 instances per frame.
	public float verticalVelocity = 0;

	private float jumpspeed;
	private float nextFire;

	private const int typesOfBullets = 6; 

	private int bulletChoise;
	private int grenadeChoise;
	public int[] bulletsLeft;
	public int[] grenadesLeft;

	public float fireRate;
	public float throwRate;
	public float boosterTime;

	public float health;
	public int life;
	public Vector3 checkPoint;


	public GameObject[] bullet;
	public GameObject[] grenade;

	public Transform shotSpawn;
	public Transform grenadeSpawn;
	
	public AudioClip shotSound;

	public Texture healthGui; 
	public Texture[] ammoGui; 
	public Texture[] grenadeGui; 
	public Texture firerateGui; 

	//private float timer;

	CharacterController cc;


	void Start () 
	{
		bulletChoise = 0;
		grenadeChoise = 0;

		bulletsLeft = new int[5]{0,0,0,0,0};
		grenadesLeft = new int[6]{0,0,0,0,0,0};

		checkPoint = transform.position;

		fireRate = 0.5f;
		boosterTime = 0.0f;
		health = 100.0f;
		life = 3;
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
		if (health < 0){
			transform.position = checkPoint;
			life--;
			health = 100.0f;
		}
		if(life < 1){   // if my health is 0, then restart the game
			Application.LoadLevel(0);
		}

		if (Input.GetButton ("Fire1") && Time.time > nextFire) 
		{
			if(bulletChoise == 1 && bulletsLeft[bulletChoise] > 0){
				audio.PlayOneShot (shotSound);
				bulletsLeft[bulletChoise]--;
				nextFire = Time.time + fireRate;
				Instantiate(bullet[bulletChoise], new Vector3(shotSpawn.position.x  , shotSpawn.position.y + 1, shotSpawn.position.z), shotSpawn.rotation);
				Instantiate(bullet[bulletChoise], shotSpawn.position, shotSpawn.rotation);
				Instantiate(bullet[bulletChoise], new Vector3(shotSpawn.position.x , shotSpawn.position.y - 1, shotSpawn.position.z), shotSpawn.rotation);
			}
			if(bulletsLeft[bulletChoise] > 0){
				audio.PlayOneShot (shotSound);
				bulletsLeft[bulletChoise]--;
				nextFire = Time.time + fireRate;
				Instantiate(bullet[bulletChoise], shotSpawn.position, shotSpawn.rotation); //as GameObject;
			}

		}
		if (Input.GetButton ("Fire2") && Time.time > nextFire ) 
		{
			if(grenadesLeft[grenadeChoise] > 0){
				grenadesLeft[grenadeChoise]--;
				nextFire = Time.time + throwRate;
				Instantiate(grenade[grenadeChoise], grenadeSpawn.position, grenadeSpawn.rotation); //as GameObject;
			}
		}
		if(Input.GetKeyDown(KeyCode.Alpha1)){
			if(++bulletChoise > bulletsLeft.Length - 1)
			{
				bulletChoise = 0;
			}
		}else if(Input.GetKeyDown(KeyCode.Alpha2)){
			if(++grenadeChoise > grenadesLeft.Length - 1){
				grenadeChoise = 0;
			}
		}
				
		//movement
		//taking input from the keyboard(up and down) and multiplying with speed
		float forwardSpeed=Input.GetAxis ("Vertical")*moveMentSpeed; 
		float sideSpeed= Input.GetAxis("Horizontal")*moveMentSpeed;
	
		verticalVelocity += Physics.gravity.y * Time.deltaTime;


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
		GameObject collisionObject;
		if(other.gameObject.tag =="Enemy")
		{
			collisionObject = other.gameObject;
			enemyMovement script = collisionObject.GetComponent<enemyMovement>();
			health -= script.attack;
		}
		 
	}


	//GUI on the SCREEN

	void OnGUI(){ //function that instantiates what you wish to diskplay on the game screen.
		if(life!=0){ // if the health is not zero
			for (int i=0;i<life;i++){ //for loop used to print out 
				int posy = 60*i; //variable 
				GUI.DrawTexture(new Rect(0,posy,60,60),healthGui);
			}
		} 
		if(boosterTime > 0){
			GUI.TextField(new Rect(Screen.width/2,0,80,60), "Booster " + boosterTime);
			GUI.DrawTexture(new Rect(Screen.width/2 + 6,20,70,30),firerateGui);
		}
		GUI.TextField(new Rect(Screen.width/2 - 160,Screen.height - 80,160,80), "Health: " + health.ToString());
		
		GUI.TextField(new Rect(Screen.width - 160,0,160,80),	bullet[bulletChoise].name + ": \n" +
		              										bulletsLeft[bulletChoise] + "x ");
		GUI.DrawTexture(new Rect(Screen.width - 150,36,140,26),ammoGui[bulletChoise]);

		GUI.TextField(new Rect(Screen.width - 160,80,160,110),	grenade[grenadeChoise].name + ": \n" +
		              										grenadesLeft[grenadeChoise] + "x ");
		GUI.DrawTexture(new Rect(Screen.width - 130,95,90,90),grenadeGui[grenadeChoise]);
		
	}

}
	
