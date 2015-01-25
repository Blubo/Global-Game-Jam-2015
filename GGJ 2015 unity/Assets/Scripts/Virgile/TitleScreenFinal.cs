using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using XInputDotNetPure;

public class TitleScreenFinal : MonoBehaviour {
	//Xinput
	bool playerIndexSet = false;
	public PlayerIndex playerIndex;
	GamePadState state;
	GamePadState prevState;

	public Material _Screen01, _Screen02;
	public Transform _placement;
	public AudioClip _TransitionSound;

	private bool _havetomove = false;

	// Use this for initialization
	void Start () {
		gameObject.renderer.material = _Screen01;
	}
	
	// Update is called once per frame
	void Update () {
		//Xinput
		prevState = state;
		state = GamePad.GetState(playerIndex);

		if(state.Buttons.X == ButtonState.Pressed){
			StartCoroutine(BeginThegame());
		}
		if(_havetomove){
			Camera.main.transform.position = Vector3.Lerp (Camera.main.transform.position, _placement.position, Time.deltaTime*1.5f);
		}
	}

	IEnumerator BeginThegame(){
		//Changement d'image
		gameObject.renderer.material = _Screen02;

		//Attente pour lire le texte 
		yield return new WaitForSeconds(2.0f);

		//On Zoom Sur le cerveau
		_havetomove = true;
		//On fait le son de transition
		audio.PlayOneShot (_TransitionSound);
		//Une fois le zoom effectué alors on peut lancer la scène de jeu
		yield return new WaitForSeconds(1.5f);

		Application.LoadLevel ("NewCountdownScreen");
	}
}
