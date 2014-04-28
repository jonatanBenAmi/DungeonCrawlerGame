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
	public GameObject weapon;
	public GameObject[] grenade;
	private int[] grenadeStock;
	private int grenadeChoise;
	private Event_Timer grenadeTimer;

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
		charactorTimer = new Event_Timer(affectTimer,true);

		jumpSpeed = 6.0f;
		throwRate = 100.0f;
		checkPoint = transform.position;

		grenadeStock = new int[6]{10,10,10,10,10,10};
		grenadeChoise = 1;
		grenadeTimer = new Event_Timer(throwRate, true);

		cc = GetComponent<CharacterController>();
	}

	public override void Update () 
	{
		if(grenadeTimer.eventTimer())
		{
			grenadeTick = true;
		}
		if(lives < 1)
		{   // if my health is 0, then restart the game
			Application.LoadLevel(0);
		}
		isAlive();

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

		//Debug.Log("Hallo");
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
			Instantiate(grenade[grenadeChoise], grenadeSpawn.position, grenadeSpawn.rotation); //as GameObject;
		}
	}
	public void movePlayer (float xAxis,float yAxis, float zAxis) 
	{
		Vector3 speed = new Vector3(xAxis,yAxis,zAxis);
		speed = transform.rotation * speed;
		cc.Move (speed * Time.deltaTime);
	}

	public void OnTriggerEnter(Collider other)
	{ 
		GameObject collisionObject;
		if(other.gameObject.tag =="Enemy")
		{
			collisionObject = other.gameObject;
			//enemyMovement script = collisionObject.GetComponent<enemyMovement>();
			//defence -= script.attack;
		}
	}
	void OnGUI()
	{
		GUI.TextField(new Rect(Screen.width/2 - 160,Screen.height - 80,160,80), "Health: " + defence.ToString());
	}
}
