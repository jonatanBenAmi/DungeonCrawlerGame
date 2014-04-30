using UnityEngine;
using System.Collections;

// imports a characterController
[RequireComponent(typeof(CharacterController))] 

public class Player_Charactor : Charactor_Class 
{
	// used to calc gravity
	protected float verticalVelocity;
	// how many times the player can die
	protected int lives;

	// how high can the player jump
	protected float jumpSpeed;
	// how long time it takes between grenade throws
	protected float throwRate;

	// used for saving player progress
	protected Vector3 checkPoint;
	// used by spawnpoints
	protected int checkPointCount;

	// stores the weapon holds 
	public GameObject weapon;
	// stores the grenade prefabs
	public GameObject[] grenade;
	// determins how many grenades the player have
	public int[] grenadeStock;
	// texture for gui
	public Texture[] grenadeGui;
	public Texture[] textureGui;
	// what grenade to throw
	private int grenadeChoise;
	// timer for grenade throws
	private Event_Timer grenadeTimer;
	// for the gui so the player can see how many enemys have been killd
	private int enemyKills;

	// the point where grenades are thrown
	public Transform grenadeSpawn;

	// stores the values from grenadetimer
	private bool grenadeTick;

	// needed for something
	CharacterController cc;

	// if the player pauses the game
	bool paused;

	public override void Start () 
	{
		// giving variables values fitting for there purpose
		lives = 3;
		movementSpeed = 10.0f;
		defence = 100.0f;
		armorStrength = 0.0f;
		stuned = false;
		affectTimer = 0.0f;
		charactorTimer = new Event_Timer(affectTimer,false);

		jumpSpeed = 6.0f;
		throwRate = 100.0f;
		checkPoint = transform.position;

		grenadeStock = new int[6]{10,10,10,10,10,10};
		grenadeChoise = 1;
		grenadeTimer = new Event_Timer(throwRate, true);

		paused = false;
		checkPointCount = 0;

		cc = GetComponent<CharacterController>();
	}

	public override void Update () 
	{

		// to quit the game
		if(Input.GetKey(KeyCode.Escape))
		{
			Application.Quit();
		}
		// to pause the game
		if(Input.GetKey(KeyCode.P))
		{
			if(paused){
				paused = false;
			}else{
				paused = true;
			}
		}
		// if paused stop time / else run at normal speed
		if(paused)
		{
			Time.timeScale = 0;
		}else
		{
			Time.timeScale = 1;
		}
		// can the player throw a grenade
		if(grenadeTimer.eventTimer())
		{
			grenadeTick = true;
		}
		// if the player is affected by some affect set it to false
		if(charactorTimer.eventTimer())
		{
			stuned = false;
		}
		// makes sure that armor strength in no less then zero
		// only cosmetic 
		if(armorStrength < 0)
		{
			armorStrength = 0;
		}
		// reload level if player have lost all lives
		if(lives < 1)
		{   // if my health is 0, then restart the game
			Application.LoadLevel(0);

		}

		// resets the player values and plases the player
		// at the last defeated checkpoint
		isAlive();

		// if player is stuned stand still 
		if(stuned)
		{
			transform.position = transform.position;
		}
		// else 
		else
		{
			// input from number keys for grenade selection
			if(Input.GetKeyDown(KeyCode.Alpha1))
			{
				grenadeChoise = 1;

			}
			else if(Input.GetKeyDown(KeyCode.Alpha2))
			{
				grenadeChoise = 2;
			}
			else if(Input.GetKeyDown(KeyCode.Alpha3))
			{
				grenadeChoise = 3;
			}
			else if(Input.GetKeyDown(KeyCode.Alpha4))
			{
				grenadeChoise = 4;
			}
			else if(Input.GetKeyDown(KeyCode.Alpha5))
			{
				grenadeChoise = 5;
			}
			else if(Input.GetKeyDown(KeyCode.Alpha6))
			{
				grenadeChoise = 6;
			}
			// if right mousebutton is pressed
			else if (Input.GetButton ("Fire2")) 
			{
				// can the player throw a new grenade
				if(grenadeTick)
				{
					// throw the grenade
					throwGrenade();
					// reset timer
					grenadeTick = false;
					grenadeTimer.TimeToNextTick = throwRate;
					grenadeTimer.TimeTicking = 0f;
				}
			}
			// making sure the player will return to gamePlane(terrain)
			verticalVelocity += Physics.gravity.y * Time.deltaTime;
			// if the player is on the ground (terrain)
			if(cc.isGrounded && Input.GetButtonDown("Jump"))
			{
				// 
				verticalVelocity = jumpSpeed;
			}
			// get key input from w, s
			float forwardSpeed = Input.GetAxis ("Vertical") * movementSpeed; 
			// get key input from a, d
			float sideSpeed = Input.GetAxis("Horizontal") * movementSpeed;
			// moves the player 
			movePlayer (sideSpeed, verticalVelocity,-forwardSpeed);
		}
	}

	// 
	public void isAlive()
	{
		// resets the player values and plases the player
		// at the last defeated checkpoint
		if (defence < 1){
			transform.position = checkPoint;
			lives--;
			defence = 100.0f;
		}
	}

	public void throwGrenade()
	{
		// does the player have any grenade left of the grenade type
		if( grenadeStock[grenadeChoise - 1] > 0)
		{
			// subtract one from grenade stock
			grenadeStock[grenadeChoise - 1]--;
			// throw the grenade
			Instantiate(grenade[grenadeChoise - 1], grenadeSpawn.position, grenadeSpawn.rotation); //as GameObject;
		}
	}

	public void movePlayer (float xAxis,float yAxis, float zAxis) 
	{
		Vector3 speed = new Vector3(xAxis,yAxis,zAxis);
		speed = transform.rotation * speed;
		cc.Move (speed * Time.deltaTime);
	}

	public void OnTriggerStay(Collider other)
	{ 
		GameObject collisionObject;
		// if the player hit an enemy
		if(other.gameObject.tag =="Enemy")
		{
			// find the script of the enemy and subtract the ContactAttack found there from the 
			// players defence
			collisionObject = other.gameObject;
			Enemy_Charactor script = collisionObject.GetComponent<Enemy_Charactor>();
			defence -= script.ContactAttack * Time.deltaTime;
		}
	}
	void OnGUI()
	{
		// gui numbers looks better as ints
		int tmpDef = (int)defence;
		int tmpArm = (int)armorStrength;

		// the stats gui with defence , armor and enemykills
		GUI.TextField(new Rect(Screen.width/2 - 60,Screen.height - 50,120,50), "Health: " + tmpDef.ToString() + "\nArmor: " + tmpArm.ToString() + "\nEnemy Kills: " + enemyKills.ToString());
		// grenade gui name of grenade and how many left
		GUI.TextField(new Rect(Screen.width - 160,80,160,110),	grenade[grenadeChoise - 1].name + ": \n" +
		              grenadeStock[grenadeChoise - 1] + "x ");
		// draw the chosen grenade type from array
		GUI.DrawTexture(new Rect(Screen.width - 130,95,90,90),grenadeGui[grenadeChoise - 1]);

		// find the gun so we can access the booster if it is active
		GameObject gun = GameObject.Find("AK_47_Model");
		Ak47_Weapon script = gun.GetComponent<Ak47_Weapon>();

		if(script.boosterTimer.TimeTicking > 0){
			// show firerate gui if on
			GUI.TextField(new Rect(Screen.width/2,0,80,60), "Booster " + (script.boosterTimer.TimeToNextTick - script.boosterTimer.TimeTicking));
			// draw firerate texture
			GUI.DrawTexture(new Rect(Screen.width/2 + 6,20,70,30),textureGui[0]);
		}
		if(lives != 0){ 
			// if the health is not zero
			// for loop used to print out 
			for (int i = 0; i < lives ; i++){ 
				int posy = 60*i; 
				// draw the hearts 
				GUI.DrawTexture(new Rect(0,posy,60,60),textureGui[1]);
			}
		} 
	}
	// get/set for important variables
	public int Lives
	{
		get {return lives;}
		set {lives = value; }
	}
	public int CheckPointCount
	{
		get {return checkPointCount;}
		set {checkPointCount = value; }
	}
	public Vector3 CheckPoint
	{
		get {return checkPoint;}
		set {checkPoint = value; }
	}
	public int EnemyKills
	{
		get {return enemyKills;}
		set {enemyKills = value;}
	}
}
