using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]

public class AvatarMouseLook : MonoBehaviour {
	
	void RotateToMouse() {
       Vector3 v3T = Input.mousePosition;  //vector that holds the mouse position in 3D space
       v3T.z = Mathf.Abs(Camera.main.transform.position.y - transform.position.y);
       v3T = Camera.main.ScreenToWorldPoint(v3T);
       v3T -= transform.position;
       v3T = v3T * 10000.0f + transform.position;
       transform.LookAt(v3T);
    }
	
	// Update is called once per frame
	void Update () {
	
         RotateToMouse ();
	}
}
