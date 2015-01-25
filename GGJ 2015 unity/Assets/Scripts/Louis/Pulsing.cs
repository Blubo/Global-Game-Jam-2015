using UnityEngine;
using System.Collections;

public class Pulsing : MonoBehaviour {

	private float timer;
	private int coeff;

	// Use this for initialization
	void Start () {
		timer=0f;
		coeff = 1;
	}
	
	// Update is called once per frame
	void Update () {
		timer+=Time.deltaTime;
		gameObject.transform.localScale+=coeff*new Vector3(0.01f, 0.01f, 0.01f);
		if(timer>0.5f){
			coeff*=-1;
			timer=0f;
		}
	}
}
