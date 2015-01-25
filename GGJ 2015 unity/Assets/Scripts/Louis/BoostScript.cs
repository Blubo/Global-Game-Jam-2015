using UnityEngine;
using System.Collections;

public class BoostScript : MonoBehaviour {
	

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider){
		if(collider.gameObject.tag.Equals("Player")){
			Vector3 velocity = collider.gameObject.rigidbody.velocity;
			velocity.Normalize();

			collider.gameObject.rigidbody.AddForce(velocity*1000f);
			Debug.Log("ceci est le shadow");
		}
	}

//	void OnTriggerExit(Collider collider){
//		if(collider.gameObject.tag.Equals("Player")){
//			Vector3 velocity = collider.gameObject.rigidbody.velocity;
//			velocity.Normalize();
//			
//			collider.gameObject.rigidbody.AddForce(velocity*1.5f);
//			Debug.Log("ceci est le shadow");
//		}
//	}
}
