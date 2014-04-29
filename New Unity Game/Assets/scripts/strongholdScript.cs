using UnityEngine;
using System.Collections;

public class strongholdScript : MonoBehaviour {

	public float defence;//Variable to store defence
	private GameObject spawn;//GameObject called spawn
	private GameObject player;//GameObject called player
	public GameObject exp;//GameObject called exp

	void Start () 
	{
		player = GameObject.Find("Avatar");//Setting player to be avatar
		spawn = transform.FindChild("Spawn").gameObject;//setting spawn to be the spawn
	}

	void Update () 
	{
		if(defence < 1){//If statement checks if stronghold defence is smaller than 1
			Instantiate(exp, transform.position, transform.rotation);//Sets of the explosion asset
			Player_Charactor script = player.GetComponent<Player_Charactor>();//Getting the character script to edit spawn point
			script.CheckPoint = player.transform.position;//Setting the check point to be the players position at the moment stronghold explodes
			script.CheckPointCount++;//Adding 1 to the CheckPointCount
			Destroy(gameObject);//Destroy stronghold
			Destroy(spawn);//Destroy old spawn
		}

	}

}
