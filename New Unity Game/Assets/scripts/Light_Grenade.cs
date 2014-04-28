using UnityEngine;
using System.Collections;

public class Light_Grenade : Grenade_Class {


	public override void Update () 
	{
		transform.Rotate(Vector3.forward * 600 * Time.deltaTime);

		if(explode)
		{
			Instantiate(explosionGraphics, transform.position, transform.rotation);
			AudioSource.PlayClipAtPoint(explosionSound, transform.position);
			Destroy(gameObject);
		}
		if(grenadeTimer.eventTimer())
		{
			explode = true;
		}
	}

	public override void OnTriggerStay(Collider other)
	{
		GameObject collisionObject;

		if(other.tag == "Enemy" )
		{
			collisionObject = other.gameObject;
			Enemy_Charactor script = collisionObject.GetComponent<Enemy_Charactor>();
			script.Target = transform;
		}
		if(explode)
		{
			if(other.tag == "Enemy" )
			{
				GameObject player = GameObject.Find("Avatar");
				collisionObject = other.gameObject;
				Enemy_Charactor script = collisionObject.GetComponent<Enemy_Charactor>();
				script.Target = player.transform;
			}
		}
	}
}
