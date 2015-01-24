using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using XInputDotNetPure;

public class TitleScreen : MonoBehaviour {
	//Xinput
	bool playerIndexSet = false;
	public PlayerIndex playerIndex;
	GamePadState state;
	GamePadState prevState;

	public int _Selection;
	//0 = PLay
	//1 = credits 
	//2 = quit

	public List<GUIText> _Texts;

	// Use this for initialization
	void Start () {
		_Selection = 0;

		// Placement du texte 
		_Texts [0].text = "Play";
		_Texts [1].text = "Credits";
		_Texts [2].text = "Quit";

		_Texts [0].fontSize = 20;
		_Texts [1].fontSize = 20;
		_Texts [2].fontSize = 20;

		_Texts [0].transform.position = new Vector3 (0.5f, 0.7f, 0.0f);
		_Texts [1].transform.position = new Vector3 (0.5f, 0.5f, 0.0f);
		_Texts [2].transform.position = new Vector3 (0.5f, 0.3f, 0.0f);
	}
	
	// Update is called once per frame
	void Update () {
		//Xinput
		prevState = state;
		state = GamePad.GetState(playerIndex);

		_Selection = Mathf.Clamp (_Selection, 0, 2);

		_Texts [0].fontSize = 20;
		_Texts [1].fontSize = 20;
		_Texts [2].fontSize = 20;

		if(state.ThumbSticks.Left.Y == 1 && prevState.ThumbSticks.Left.Y != 1){
			_Selection -= 1;
		}
		if (state.ThumbSticks.Left.Y == -1 && prevState.ThumbSticks.Left.Y != -1){
			_Selection += 1;
		}

			switch(_Selection){
				case(0):
					_Texts [0].fontSize = 50;
					if(state.Buttons.A == ButtonState.Pressed){
						//Play GameScene
						Application.LoadLevel("CountdownScreen");
					}
				break;
					
				case(1):
					_Texts [1].fontSize = 50;
					if(state.Buttons.A == ButtonState.Pressed){
						//Play Credits Scene
						Application.LoadLevel("CreditsScreen");
					}
				break;

				case(2):
					_Texts [2].fontSize = 50;
					if(state.Buttons.A == ButtonState.Pressed){
						//End of the game
						Application.Quit();
					}
				break;
			}
	}
}
