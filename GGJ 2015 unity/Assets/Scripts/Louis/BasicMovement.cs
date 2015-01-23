using UnityEngine;
using System.Collections;

public class BasicMovement : MonoBehaviour {


	public float v_speed;
	[Range(0,1)]
	public float v_rotationSpeedOnRebound;

	// Use this for initialization
	void Start () {
		gameObject.rigidbody.AddForce(gameObject.transform.forward*v_speed);

	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.forward = Vector3.Lerp(gameObject.transform.forward, gameObject.rigidbody.velocity, v_rotationSpeedOnRebound);
		Debug.Log(gameObject.rigidbody.velocity.magnitude);
//		gameObject.transform.forward = gameObject.rigidbody.velocity;
	}

	void FixedUpdate(){

	}


}
