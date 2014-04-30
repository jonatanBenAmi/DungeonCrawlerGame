using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]

public class AvatarMouseLook : MonoBehaviour {

	void RotateToMouse() { //function that make the gun point at where the mouse is pointing
       Vector3 v3T = Input.mousePosition;  //vector that holds the mouse position in 3D space
       v3T.z = Mathf.Abs(Camera.main.transform.position.y - transform.position.y); // takes the z position of the vector and sets it to the absolute value of the mainCamares y-position - y-position. To ensure that the z-axis is unchanged on the controlled object 
       v3T = Camera.main.ScreenToWorldPoint(v3T); //take the vector and gives it the value from camera(screenspace) and transforms it into world space.
       v3T -= transform.position; //removes the original position/former position
       v3T = v3T * 10000.0f + transform.position; //takes the new position * 10000.0f readds the position
       transform.LookAt(v3T); //rotates the transform so the vector points at the mouse current position
    }
	
	// Update is called once per frame
	void Update () {
	
         RotateToMouse (); //calls the function and keeps updating.
	}
}
