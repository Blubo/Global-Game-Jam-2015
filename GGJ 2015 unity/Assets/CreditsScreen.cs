using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class CreditsScreen : MonoBehaviour {
	//Xinput
	bool playerIndexSet = false;
	public PlayerIndex playerIndex;
	GamePadState state;
	GamePadState prevState;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Xinput
		prevState = state;
		state = GamePad.GetState(playerIndex);

		if(state.Buttons.B == ButtonState.Pressed){
			//Retourner à l'écran titre
			Application.LoadLevel("TitleScreen");
		}
	}
}
