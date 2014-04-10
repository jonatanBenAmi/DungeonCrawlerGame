using UnityEngine;
using System.Collections;

public class randomRotation : MonoBehaviour {

	public float tumble;

	void star(){
		rigidbody.angularVelocity =  Random.insideUnitSphere * tumble;//angularVelocity:how fast a object is rotating
		Debug.Log (rigidbody.angularVelocity);
	}
}
