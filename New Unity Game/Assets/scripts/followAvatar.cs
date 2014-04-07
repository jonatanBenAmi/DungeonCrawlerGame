using UnityEngine;
using System.Collections;
[RequireComponent(typeof(CharacterController))]

public class followAvatar : MonoBehaviour {
	GameObject Avatar;
	CharacterController cc;
	
	void Start () {
		cc = GetComponent<CharacterController>();
	
	}
	
	// Update is called once per frame
	void Update () {
		
	//cc.Move ();
		
}
}