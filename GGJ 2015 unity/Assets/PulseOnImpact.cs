using UnityEngine;
using System.Collections;

public class PulseOnImpact : MonoBehaviour {

	private float timer, insideTimer;
	private int coeff;
	private bool collided;
	private Vector3 initSize;

	// Use this for initialization
	void Start () {
		timer=0f;
		coeff = 1;
		initSize = gameObject.transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		if(collided==true){
			timer+=Time.deltaTime;
			insideTimer+=Time.deltaTime;
			gameObject.transform.localScale+=coeff*new Vector3(0.01f, 0.01f, 0.01f);
			if(insideTimer>0.15f){
				coeff*=-1;
				insideTimer=0;
			}
		}

		if(timer>1f){
			collided=false;

			timer=0f;
			gameObject.transform.localScale=initSize;
		}
	}

	void OnCollisionEnter(Collision collision){
		if(collision.gameObject.tag.Equals("Player")){
			collided=true;
		}
	}
}
