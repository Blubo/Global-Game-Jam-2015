using UnityEngine;
using System.Collections;

public class RotationTrigger: MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.Rotate(new Vector3(0,0,15*Time.deltaTime));
	}
}
