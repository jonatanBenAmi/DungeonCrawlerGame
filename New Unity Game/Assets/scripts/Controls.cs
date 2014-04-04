using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	
		
	if(Input.GetKeyDown(KeyCode.A)){ //if you press A
			transform.position -= new Vector3(1.0f,0,0); //move to the left ( subtract in the x direction)
		}
		if(Input.GetKeyDown(KeyCode.D)){ //if you press d
			transform.position += new Vector3(1.0f,0,0); //move to the right ( add to the x  direction)
		}
		if(Input.GetButtonDown("Jump")&& transform.position.y<1){ //if you press space
			rigidbody.AddForce(new Vector3(0,400.0f,0)); // add force to the y direction
		}
		if(Input.GetKeyDown (KeyCode.S)){ // if you press S
			transform.position -= new Vector3(0,0,1.0f); 
		}
	  if (Input.GetKeyDown (KeyCode.W)){  //if you press w
			transform.position += new Vector3(0,0,1.0f); // set the ball scale to normal
		}
	
	}
}
