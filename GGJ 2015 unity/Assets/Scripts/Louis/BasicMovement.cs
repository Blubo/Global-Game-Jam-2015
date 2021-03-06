﻿using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class BasicMovement : MonoBehaviour {

	bool playerIndexSet = false;
	public PlayerIndex playerIndex;
	GamePadState state;
	GamePadState prevState;

	public float v_initSpeed, v_speed, v_speedLoss;
	[Range(0,1)]
	public float v_rotationSpeedOnRebound;

	private Vector3 _movement;

	private bool reoriented, isInTrigger;

	// Use this for initialization
	void Start () {
		v_initSpeed=v_speed;
		reoriented=false;
		isInTrigger=false;
//		gameObject.rigidbody.AddForce(gameObject.transform.forward*v_speed);
	}
	
	// Update is called once per frame
	void Update () {
		prevState = state;
		state = GamePad.GetState(playerIndex);
//		gameObject.transform.forward = Vector3.Lerp(gameObject.transform.forward, gameObject.rigidbody.velocity, v_rotationSpeedOnRebound);
//		Debug.Log("magnitude de velocity is " + gameObject.rigidbody.velocity.magnitude);
		Debug.Log("orientruc is " + reoriented);
		Debug.Log("speed " + v_speed);

		v_speed = Mathf.Clamp(v_speed, 0, v_initSpeed);

		if(isInTrigger==false){
			gameObject.transform.forward = gameObject.rigidbody.velocity;
		}
	}

	void FixedUpdate(){
//		if(isInTrigger==false){
			MovementEveryFrame();
//		}else{
//			if(prevState.Buttons.RightShoulder==ButtonState.Released && state.Buttons.RightShoulder == ButtonState.Pressed){
//				MovementEveryFrame();
//			}
//		}
	}
	

	void MovementEveryFrame(){
		//ca mais fait pour du frame par frame
		Vector3 direction = new Vector3(0,0,0);
		direction=gameObject.transform.forward;
		direction.Normalize();
		
		_movement = direction*v_speed;
		rigidbody.AddForce(_movement);
//		gameObject.rigidbody.AddForce(gameObject.transform.forward*v_speed, ForceMode.Force);

	}

	void Movement(){
//		gameObject.rigidbody.velocity=Vector3.zero;
////		gameObject.rigidbody.AddForce(gameObject.transform.forward*v_speed);
//
//
	}

	void OnTriggerStay(Collider collision){
		isInTrigger=true;
		v_speed-=v_speedLoss*Time.deltaTime;
		if(collision.gameObject.tag.Equals("TriggerZone")){
			if(state.ThumbSticks.Right.X!=0 || state.ThumbSticks.Right.Y!=0){
				float angle = Mathf.Atan2 (state.ThumbSticks.Right.Y, state.ThumbSticks.Right.X) * Mathf.Rad2Deg;
				this.transform.rotation = Quaternion.Euler (new Vector3(0, -angle+90, 0));
				if(prevState.Buttons.RightShoulder==ButtonState.Released && state.Buttons.RightShoulder == ButtonState.Pressed){
//					isInTrigger=false;
				}
//					if(reoriented==false){
//						reoriented=true;
//						Movement();
//					}
//				}
			}
		}
	}

	void OnTriggerExit(Collider collision){
		isInTrigger=false;
		v_speed=v_initSpeed;
		if(collision.gameObject.tag.Equals("TriggerZone")){
			reoriented=false;
		}
	}
}
