using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour 
{
	

	public GameObject[] enemy;
		
	public float spawnTimer;
	public float howFast;
	public int maxEnemies;


	void Start () 
	{
		spawnTimer = 0.0f;
		howFast = 10.0f;
		maxEnemies = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(maxEnemies > 5){
			howFast = 20.0f;
		}else if(maxEnemies > 10){
			howFast = 40.0f;
		}else if(maxEnemies > 25){
			howFast = 60.0f;
		}


		if (Time.time > spawnTimer) 
		{
			int randomSelection = Random.Range (1,100);
			//Debug.Log(randomSelection.ToString());
			if(randomSelection < 30)
			{
				spawnTimer = Time.time + howFast;
				Instantiate(enemy[0], new Vector3 (transform.position.x,5,transform.position.z),transform.rotation);
				maxEnemies ++;//as GameObject;
			}
			else if (randomSelection >=30 && randomSelection < 40)
			{
				spawnTimer = Time.time + howFast;
				Instantiate(enemy[2], new Vector3 (transform.position.x,5,transform.position.z),transform.rotation);
				maxEnemies ++;//as GameObject;
			}
			else{
				spawnTimer = Time.time + howFast;
				Instantiate(enemy[1], new Vector3 (transform.position.x,5,transform.position.z),transform.rotation);
				maxEnemies ++;//as GameObject;
			}
		}
	}

}
