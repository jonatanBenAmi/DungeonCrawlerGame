using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour 
{
	

	public GameObject Skull;
		
	public float spawnTimer;
	public float howFast;
	public int maxEnemies;


	void Start () 
	{
		spawnTimer = 0.0f;
		howFast = 20.0f;
		maxEnemies = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Time.time > spawnTimer && maxEnemies < 25) 
		{
			spawnTimer = Time.time + howFast;
			Instantiate(Skull, transform.position,transform.rotation);
			maxEnemies ++;//as GameObject;
		}
	}

}
