using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour 
{
	

	public GameObject[] enemy;
		
	public float spawnTimer;
	public float howFast;
	public int maxEnemies;
	public int spawnNumber;

	void Start () 
	{
		spawnTimer = 0.0f;
		howFast = 5.0f;
		maxEnemies = 0;

	}

	// Update is called once per frame
	void Update () 
	{
		GameObject player = GameObject.Find("Avatar");
		Player_Charactor script = player.GetComponent<Player_Charactor>();
		int playerPoint = script.CheckPointCount;

		if(maxEnemies > 5){
			howFast = 15.0f;
		}else if(maxEnemies > 10){
			howFast = 30.0f;
		}else if(maxEnemies > 25 && maxEnemies < 40){
			howFast = 60.0f;
		}

		if(spawnNumber - 5 < playerPoint)
		{
			if (Time.time > spawnTimer) 
			{
				Debug.Log(spawnNumber);
				int randomSelection = Random.Range (1,100);

				if(randomSelection < 10)
				{
					spawnTimer = Time.time + howFast;
					Instantiate(enemy[0], new Vector3 (transform.position.x,5,transform.position.z),transform.rotation);
					maxEnemies ++;//as GameObject;
				}
				else if (randomSelection >=10 && randomSelection < 30)
				{
					spawnTimer = Time.time + howFast;
					Instantiate(enemy[1], new Vector3 (transform.position.x,5,transform.position.z),transform.rotation);
					maxEnemies ++;//as GameObject;
				}
				else{
					spawnTimer = Time.time + howFast;
					Instantiate(enemy[2], new Vector3 (transform.position.x,5,transform.position.z),transform.rotation);
					maxEnemies ++;//as GameObject;
				}
			}
		}
	}

}
