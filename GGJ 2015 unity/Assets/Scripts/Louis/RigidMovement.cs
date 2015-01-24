using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using XInputDotNetPure;

public class RigidMovement : MonoBehaviour {

	bool playerIndexSet = false;
	public PlayerIndex playerIndex;
	GamePadState state;
	GamePadState prevState;

	public float v_initSpeed, v_speed, v_speedLoss;
	[Range(0,1)]
	public float v_rotationSpeedOnRebound;

	private Vector3 _movement, _velocity;

	private bool reoriented, isInTrigger;

	//SOUNDS
	public List<AudioClip> _OnCollision;
	public List<AudioClip> _OnTriggerexit;

	// Use this for initialization
	void Start () {
		gameObject.transform.Find("Pointe").renderer.enabled=false;

		v_initSpeed=v_speed;
		reoriented=false;
//		gameObject.rigidbody.AddForce(gameObject.transform.forward*v_speed);
		gameObject.rigidbody.AddForce(gameObject.transform.forward*v_speed*(gameObject.GetComponent<PlayerState>()._Score+1)/10);

//		Debug.Log("speed : "+v_speed*((gameObject.GetComponent<PlayerState>()._Score+1)/10));
	}
	
	// Update is called once per frame
	void Update () {
		prevState = state;
		state = GamePad.GetState(playerIndex);
//		Debug.Log("magnitude de velocity is " + gameObject.rigidbody.velocity.magnitude);
//		Debug.Log("orientruc is " + reoriented);
//		Debug.Log("speed " + v_speed);

		//ceci signifie que la vitesse ne peut jamais etre supérieure à la vitesse de départ, ni négative
		if(gameObject.rigidbody.velocity.magnitude<=0.1f){
			Debug.Log("vuertbiuaebviztubn");
		}

		v_speed = Mathf.Clamp(v_speed, 0, v_initSpeed);
		_velocity = gameObject.rigidbody.velocity;

		if(isInTrigger==false){
			//ici?
			gameObject.transform.forward = gameObject.rigidbody.velocity;
		}

//		if(gameObject.name.Equals("1Rouge")){
//			if(Input.GetKey(KeyCode.A)){
//				gameObject.rigidbody.velocity=Vector3.zero;
//			}
//		}

	}

	void Movement(){
		gameObject.rigidbody.velocity=Vector3.zero;
		//((gameObject.GetComponent<PlayerState>()._Score+1)/10) = coefficient de vitesse en fonction du nombre de points
		gameObject.rigidbody.AddForce(gameObject.transform.forward*v_speed*(gameObject.GetComponent<PlayerState>()._Score+1)/10);
	}

	void OnTriggerStay(Collider collision){
		if(collision.gameObject.tag.Equals("TriggerZone")){
			gameObject.rigidbody.velocity *= 0.992f;

			isInTrigger=true;
			gameObject.transform.Find("Pointe").renderer.enabled=true;

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

	void OnCollisionEnter(Collision collision){
		audio.volume = 0.1f;
		audio.PlayOneShot (_OnCollision [Random.Range (0, _OnCollision.Count)]);

		Vector3 actualVelocity = gameObject.rigidbody.velocity;
		actualVelocity.Normalize();
		gameObject.rigidbody.velocity = actualVelocity*_velocity.magnitude;

		if(isInTrigger==true){
			//ici?
			gameObject.transform.forward = gameObject.rigidbody.velocity;
		}
	}

	void OnTriggerExit(Collider collision){
		gameObject.transform.Find("Pointe").renderer.enabled=false;
		audio.volume = 1.0f;
		audio.PlayOneShot (_OnTriggerexit [Random.Range (0, _OnTriggerexit.Count)]);


		v_speed=v_initSpeed;
		isInTrigger=false;
		if(collision.gameObject.tag.Equals("TriggerZone")){
			if(reoriented==false){
				Movement();
			}
			reoriented=false;
		}else{
			Movement();
		}
	}
}
