using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]

public class Controls : MonoBehaviour {
	public float moveMentSpeed = 10.0f; //used determine the move speed 10 instances per frame.
	public float verticalVelocity = 0;
	public float jumpspeed = 10.0f;
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
		
		//movement
		 CharacterController cc = GetComponent<CharacterController>(); //to declare our character
		
		float forwardSpeed=Input.GetAxis ("Vertical")*moveMentSpeed; //taking input from the keyboard(up and down) and multiplying with speed
		float sideSpeed= Input.GetAxis("Horizontal")*moveMentSpeed;
		
		verticalVelocity += Physics.gravity.y * Time.deltaTime;
		
	    if(cc.isGrounded && Input.GetButtonDown("Jump")){
			verticalVelocity = jumpspeed;
		}
		
		Vector3 speed = new Vector3(-sideSpeed, verticalVelocity,forwardSpeed);
		
		speed = transform.rotation * speed;
		
		

       
		
	
		
		
		
		cc.Move (speed * Time.deltaTime);   // uses the CharacterController script, moving it in the moveDirection
		 
	                                               //Time.deltaTime gives a smooth transission 
		
		
		

		
	
		
	
	
	
	}
}
	
