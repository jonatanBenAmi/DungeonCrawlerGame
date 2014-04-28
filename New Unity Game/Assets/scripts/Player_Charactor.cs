using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))] 

public class Player_Charactor : Charactor_Class 
{

	protected float verticalVelocity;
	protected int lives;

	protected float jumpSpeed;
	protected float throwRate;

	protected Vector3 checkPoint;
	protected int checkPointCount;

	public GameObject weapon;
	public GameObject[] grenade;
	public int[] grenadeStock;
	public Texture[] grenadeGui;
	public Texture[] textureGui;
	private int grenadeChoise;
	private Event_Timer grenadeTimer;
	private int enemyKills;

	public Transform grenadeSpawn;

	private bool grenadeTick;

	CharacterController cc;

	public override void Start () 
	{
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

		checkPointCount = 0;

		cc = GetComponent<CharacterController>();
	}

	public override void Update () 
	{
		if(grenadeTimer.eventTimer())
		{
			grenadeTick = true;
		}
		if(charactorTimer.eventTimer())
		{
			stuned = false;
		}
		if(lives < 1)
		{   // if my health is 0, then restart the game
			Application.LoadLevel(0);
		}
		isAlive();

		if(stuned)
		{
			transform.position = transform.position;
		}else
		{
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
			else if (Input.GetButton ("Fire2")) 
			{
				if(grenadeTick)
				{
					throwGrenade();
					grenadeTick = false;
					grenadeTimer.TimeToNextTick = throwRate;
					grenadeTimer.TimeTicking = 0f;
				}
			}

			verticalVelocity += Physics.gravity.y * Time.deltaTime;
			
			if(cc.isGrounded && Input.GetButtonDown("Jump"))
			{
				verticalVelocity = jumpSpeed;
			}

			float forwardSpeed = Input.GetAxis ("Vertical") * movementSpeed; 
			float sideSpeed = Input.GetAxis("Horizontal") * movementSpeed;

			movePlayer (sideSpeed, verticalVelocity,-forwardSpeed);
		}
	}
	public void isAlive()
	{
		if (defence < 1){
			transform.position = checkPoint;
			lives--;
			defence = 100.0f;
		}
	}
	public void throwGrenade()
	{
		if( grenadeStock[grenadeChoise - 1] > 0)
		{
			grenadeStock[grenadeChoise - 1]--;
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
		if(other.gameObject.tag =="Enemy")
		{
			collisionObject = other.gameObject;
			Enemy_Charactor script = collisionObject.GetComponent<Enemy_Charactor>();
			defence -= script.ContactAttack * Time.deltaTime;
		}
	}
	void OnGUI()
	{
		GUI.TextField(new Rect(Screen.width/2 - 40,Screen.height - 40,80,40), "Health: " + defence.ToString() + "\nArmor: " + armorStrength.ToString());

		GUI.TextField(new Rect(Screen.width - 160,80,160,110),	grenade[grenadeChoise - 1].name + ": \n" +
		              grenadeStock[grenadeChoise - 1] + "x ");
		GUI.DrawTexture(new Rect(Screen.width - 130,95,90,90),grenadeGui[grenadeChoise - 1]);

		if(charactorTimer.TimeTicking > 0){
			GUI.TextField(new Rect(Screen.width/2,0,80,60), "Booster " + charactorTimer.TimeTicking);
			GUI.DrawTexture(new Rect(Screen.width/2 + 6,20,70,30),textureGui[0]);
		}
		if(lives != 0){ // if the health is not zero
			for (int i = 0; i < lives ; i++){ //for loop used to print out 
				int posy = 60*i; //variable 
				GUI.DrawTexture(new Rect(0,posy,60,60),textureGui[1]);
			}
		} 
	}
	public int Lives
	{
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
}
