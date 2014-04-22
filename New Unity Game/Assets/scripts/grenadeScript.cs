using UnityEngine;
using System.Collections;

public class grenadeScript : MonoBehaviour {

	public int damage;
	public float timeToDeto;
	public float throwSpeed;

	public AudioClip grenadeSound;
	public GameObject exp;

	void Start () 
	{
		timeToDeto = 3.0f + Time.time;
		rigidbody.velocity = transform.forward * throwSpeed;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Debug.Log(timeToDeto + " " +" "+ Time.time);
		if(timeToDeto == 0)
		{
			Instantiate(exp, transform.position, transform.rotation);
			Destroy(gameObject);
			AudioSource.PlayClipAtPoint(grenadeSound, transform.position);
		}
		else if(timeToDeto < Time.time)
		{
			timeToDeto = 0;
		}
	}

	public void OnTriggerStay(Collider other) 
	{
		if(other.tag == "Player"){
			if(timeToDeto == 0){
				GameObject collisionObject;
				collisionObject = other.gameObject;
				Controls script = collisionObject.GetComponent<Controls>();
				script.health -= damage;
			}
		}else if(other.tag == "Enemy" ){
			if(timeToDeto == 0){
				GameObject collisionObject;
				collisionObject = other.gameObject;
				enemyMovement script = collisionObject.GetComponent<enemyMovement>();
				script.defence -= damage;
			}
		}
		else if(other.tag == "SpawnPoint" ){
			if(timeToDeto == 0){
				GameObject collisionObject;
				collisionObject = other.gameObject;
				strongholdScript script = collisionObject.GetComponent<strongholdScript>();
				script.defence -= damage;
				Debug.Log(script.defence);
			}
		}
	}

}
