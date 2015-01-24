using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class RigidMovement : MonoBehaviour {

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
		gameObject.transform.Find("Pointe").renderer.enabled=false;

		v_initSpeed=v_speed;
		reoriented=false;
		gameObject.rigidbody.AddForce(gameObject.transform.forward*v_speed);
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
			MovementEveryFrame();

	}
	

	void MovementEveryFrame(){
	}

	void Movement(){
		gameObject.rigidbody.velocity=Vector3.zero;
		gameObject.rigidbody.AddForce(gameObject.transform.forward*v_speed);


	}

	void OnTriggerStay(Collider collision){
		isInTrigger=true;
//		v_speed-=v_speedLoss*Time.deltaTime;
		gameObject.transform.Find("Pointe").renderer.enabled=true;

		gameObject.rigidbody.velocity *= 0.995f;

		if(collision.gameObject.tag.Equals("TriggerZone")){
			if(state.ThumbSticks.Left.X!=0 || state.ThumbSticks.Left.Y!=0){
				float angle = Mathf.Atan2 (state.ThumbSticks.Left.Y, state.ThumbSticks.Left.X) * Mathf.Rad2Deg;
				this.transform.rotation = Quaternion.Euler (new Vector3(0, -angle+90, 0));

				//input for reorientation
				if(state.Buttons.RightShoulder == ButtonState.Pressed){
					if(reoriented==false){
						reoriented=true;
						Movement();
					}
				}
			}
		}
	}

	void OnTriggerExit(Collider collision){
		gameObject.transform.Find("Pointe").renderer.enabled=false;

		v_speed=v_initSpeed;
		isInTrigger=false;
		if(collision.gameObject.tag.Equals("TriggerZone")){
			if(reoriented==false){
				Movement();
			}
			reoriented=false;
		}
	}
}
