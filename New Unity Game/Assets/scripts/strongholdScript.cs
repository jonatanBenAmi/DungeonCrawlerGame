using UnityEngine;
using System.Collections;

public class strongholdScript : MonoBehaviour {

	public float defence;
	private GameObject spawn;
	private GameObject player;
	public GameObject exp;

	void Start () 
	{
		player = GameObject.Find("Avatar");
		spawn = transform.FindChild("Spawn").gameObject;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(defence < 1){
			Instantiate(exp, transform.position, transform.rotation);
			Player_Charactor script = player.GetComponent<Player_Charactor>();
			script.CheckPoint = player.transform.position;
			script.CheckPointCount++;
			Destroy(gameObject);
			Destroy(spawn);
		}

	}

}
