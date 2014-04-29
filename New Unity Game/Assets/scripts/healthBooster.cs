using UnityEngine;
using System.Collections;

public class healthBooster : MonoBehaviour {

	private float defenceIncrease;//Variable to store the increase in defence
	private int liveIncrease;//Variable to store the increase in lives

	void Start()
	{
		defenceIncrease = 100.0f;//Setting the defenceIncrease variable to 100
		liveIncrease = 1;//Setting the liveIncrease variable to 1
		transform.position = new Vector3 (transform.position.x, 6f,transform.position.z);//Setting the booster to 6 on the Y axis so it does not spawn in the terrai
	}
	void OnTriggerEnter(Collider other)//Collider function
	{  
		GameObject collisionObject;//Creating a GameObject called collisionObject
		if(other.gameObject.name == "Avatar") //If statement checks if avatar collides with this gameObject
		{
			collisionObject = other.gameObject;//collisionObject is set to be avatar
			
			Player_Charactor script = collisionObject.GetComponent<Player_Charactor>();//Getting the character script to edit defence and lives
			script.defence = defenceIncrease;//Setting the amount in defence to be the amount in defenceIncrease
			script.Lives += liveIncrease;//Setting the amount in lives to be the amount in liveIncrease
			Destroy(gameObject);//Destroy the booster on collision
		}
	}
}
