using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using XInputDotNetPure;

public class RigidMovement : MonoBehaviour {

	bool playerIndexSet = false;
	public PlayerIndex playerIndex;
	GamePadState state;
	GamePadState prevState;

	public float v_initSpeed, v_speed, v_baseSpeed, v_speedLoss, v_dashCooldown, v_dashSpeed, v_dashBonusCooldown;
	[Range(0,1)]
	public float v_rotationSpeedOnRebound;
	private float _dashTimer, _dashBonusTimer;
	private Color _myInitColor;
	private Vector3 _movement, _velocity, _velocityBeforeDash, _DashMovement, _velocityBeforeStopping;

	private bool reoriented, isInTrigger, _benefitFromDash, _authorized;

	[HideInInspector]
	public bool v_readyToDash;

	[HideInInspector]
	public bool _changesprite;
	//SOUNDS
	public List<AudioClip> _OnCollision;
	public List<AudioClip> _OnTriggerexit;

	// Use this for initialization
	void Start () {
		gameObject.transform.Find("Pointe").renderer.enabled=false;

//		_myInitColor=gameObject.renderer.material.color;

		v_readyToDash=true;
		_benefitFromDash=false;
		_authorized = false;

		v_initSpeed=v_speed;
		reoriented=false;
		gameObject.rigidbody.AddForce(gameObject.transform.forward*(v_baseSpeed + v_speed*(gameObject.GetComponent<PlayerState>()._Score+1)));

//		Debug.Log("speed : "+v_speed*((gameObject.GetComponent<PlayerState>()._Score+1)/10));
	}
	
	// Update is called once per frame
	void Update () {
		prevState = state;
		state = GamePad.GetState(playerIndex);

		v_speed = Mathf.Clamp(v_speed, 0, v_initSpeed);
		_velocity = gameObject.rigidbody.velocity;

//		if(_authorized==false){
//			if(gameObject.rigidbody.velocity!=Vector3.zero){
//				_velocityBeforeStopping=gameObject.rigidbody.velocity;
//			}else{
//				gameObject.transform.forward = _velocityBeforeStopping.normalized;
//				gameObject.rigidbody.AddForce(gameObject.transform.forward*(v_baseSpeed + v_speed*(gameObject.GetComponent<PlayerState>()._Score+1)));
//			}
//		}

		if(isInTrigger==false){
			gameObject.transform.forward = gameObject.rigidbody.velocity;
		}

		if(_benefitFromDash==true){
			_dashBonusTimer+=Time.deltaTime;
		}else{
			_velocityBeforeDash = gameObject.rigidbody.velocity;
		}

		if(_dashBonusTimer>v_dashBonusCooldown){
			Vector3 actualVelocity = gameObject.rigidbody.velocity;
			actualVelocity.Normalize();
			if(gameObject.rigidbody.velocity.magnitude!=0){
				gameObject.rigidbody.velocity = actualVelocity*_velocityBeforeDash.magnitude;
			}else{
				Debug.Log("problem lies here");
			}

			_dashBonusTimer=0;
			_benefitFromDash=false;
		}

		if(v_readyToDash==true){
//			gameObject.renderer.material.color = _myInitColor;
			if(prevState.Buttons.LeftShoulder == ButtonState.Released && state.Buttons.LeftShoulder == ButtonState.Pressed){
				PseudoDash();
			}
		}else{
			//premier feedback sur impossibilité de dash ?
//			gameObject.renderer.material.color = Color.gray;
			_dashTimer+=Time.deltaTime;
		}

		if(_dashTimer>v_dashCooldown){
			_dashTimer=0f;
			v_readyToDash=true;
		}
	}
	
	void Movement(){
		gameObject.rigidbody.velocity=Vector3.zero;
		//((gameObject.GetComponent<PlayerState>()._Score+1)/10) = coefficient de vitesse en fonction du nombre de points
		gameObject.rigidbody.AddForce(gameObject.transform.forward*(v_baseSpeed + v_speed*(gameObject.GetComponent<PlayerState>()._Score+1)));
		_authorized=false;
	}

	void PseudoDash(){
		Vector3 direction = new Vector3(0,0,0);
		direction.x=(state.ThumbSticks.Left.X);
		direction.y=0;
		direction.z=(state.ThumbSticks.Left.Y);
//		direction.Normalize();
		
		_DashMovement = direction*v_dashSpeed;
		rigidbody.AddForce(_DashMovement, ForceMode.Force);

		_benefitFromDash=true;
		v_readyToDash=false;
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
						_authorized=true;
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
		if(gameObject.rigidbody.velocity.magnitude!=0){
			gameObject.rigidbody.velocity = actualVelocity*_velocity.magnitude;
		}else{
			Debug.Log(gameObject.name + " problem lies here");
		}

//		if(isInTrigger==true && collision.gameObject.tag.Equals("Player")){
//			//ici?
//			gameObject.transform.forward = gameObject.rigidbody.velocity;
//		}

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
				_authorized=true;
				Movement();
			}
			reoriented=false;
		}else{
			_authorized=true;
			Movement();
		}
	}
}
