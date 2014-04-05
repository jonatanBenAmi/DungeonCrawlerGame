using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]

public class Controls : MonoBehaviour {
	public float moveSpeed = 10; //used determine the move speed 10 instances per frame.
	public Vector3 forwardDirection; // movedirection  return 3d coordinates
	public Vector3 sideDirection2;
	public CharacterController cc; //to declare our character
	
	// Use this for initialization
	void Start () {
	cc = GetComponent<CharacterController>();
		forwardDirection = Vector3.zero;
		sideDirection2 = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
	
		forwardDirection = Vector3.forward * Input.GetAxis ("Vertical"); //vertical is a string that defines the buttons, to move from "up and and"
		forwardDirection = transform.TransformDirection(forwardDirection).normalized; //transform: keyword to tell we are using this gameobject, 
	                                                                       //normalized returns a value of 1 or -1, depending of up, down, left or right
		forwardDirection *= moveSpeed;
		
		sideDirection2 = Vector3.left * Input.GetAxis ("Horizontal");
		sideDirection2 = transform.TransformDirection(sideDirection2).normalized;
		sideDirection2 *=moveSpeed;
		
	
		
		
		cc.Move (forwardDirection * Time.deltaTime);   // uses the CharacterController script, moving it in the moveDirection
		 
	                                               //Time.deltaTime gives a smooth transission 
		
		cc.Move (sideDirection2* Time.deltaTime);
	
	
	}
}
