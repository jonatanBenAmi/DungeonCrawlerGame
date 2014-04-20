using UnityEngine;
using System.Collections;

public class enemyMovement : MonoBehaviour {
	public Transform Target;
	public Transform myTransform;
	public int MoveSpeed = 4;
	public int MinDist = 2;
	public float Distance;

	// Use this for initialization
	void Start () {
		myTransform = transform;
	}
	
	// Update is called once per frame
	void Update () {
		Distance = Vector3.Distance (myTransform.position,Target.position);
		if(Distance<30){
			transform.LookAt (Target);
			if(Vector3.Distance (transform.position,Target.position) >=MinDist){
				transform.position += transform.forward*MoveSpeed*Time.deltaTime;
				}
			}
		}
}
