using UnityEngine;
using System.Collections;

public class bulletScript : MonoBehaviour {

	public int damage;
	public float penatration;
	public int typeOfBullet;
	public float speed = 40;
	public GameObject exp;
	private bool expanded;



	// Use this for initialization
	void Start () 
	{
		expanded = false;
		rigidbody.velocity = transform.forward * speed;
	}
	void Update(){
		if(transform.position.y > 10.0f){
			Destroy(gameObject);
		}
	}

	public void OnTriggerEnter(Collider other) 
	{
		GameObject collisionObject;

		if(other.tag == "Enemy")
		{
			penatration--;
			if(typeOfBullet == 3)
			{
				SphereCollider thisCollider = transform.GetComponent<SphereCollider>();
				thisCollider.radius = 5f;
				Instantiate(exp, transform.position, transform.rotation);
				collisionObject = other.gameObject;
				enemyMovement script = collisionObject.GetComponent<enemyMovement>();
				script.defence -= damage;
				Destroy(gameObject);
			}
			else
			{
				collisionObject = other.gameObject;
				enemyMovement script = collisionObject.GetComponent<enemyMovement>();
				script.defence -= damage;
				if(penatration < 1){
					Destroy(gameObject);
				}
			}
		}
	}
	public void OnCollisionEnter(Collision col)
	{
		GameObject collisionObject;
		if(col.gameObject.tag == "Terrain"){
			if(typeOfBullet == 3 && expanded == false)
			{
				SphereCollider thisCollider = transform.GetComponent<SphereCollider>();
				thisCollider.radius = 5f;
				Instantiate(exp, transform.position, transform.rotation);
				expanded = true;
			}else{
				Destroy(gameObject);
			}
		}else if(col.gameObject.tag == "SpawnPoint"){
			penatration--;
			if(typeOfBullet == 3 && expanded == false)
			{
				SphereCollider thisCollider = transform.GetComponent<SphereCollider>();
				thisCollider.radius = 5f;
				expanded = true;
			}
			else if(typeOfBullet == 3 && expanded == true){
				Instantiate(exp, transform.position, transform.rotation);
				collisionObject = col.gameObject;
				strongholdScript script = collisionObject.GetComponent<strongholdScript>();
				script.defence -= damage;
				Destroy(gameObject);
			}
			else
			{
				collisionObject = col.gameObject;
				strongholdScript script = collisionObject.GetComponent<strongholdScript>();
				script.defence -= damage;
				Destroy(gameObject);
			}
		}
	}

}