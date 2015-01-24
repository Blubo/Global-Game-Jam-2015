using UnityEngine;
using System.Collections;
using XInputDotNetPure;
using System.Collections.Generic;

public class ScoreScreen : MonoBehaviour {
	//Xinput
	bool playerIndexSet = false;
	public PlayerIndex playerIndex;
	GamePadState state;
	GamePadState prevState;

	public int _Selection;
	//0 = replay
	//1 = TitleScreen
	public List<GUIText> _Texts;

	// Use this for initialization
	void Start () {
		_Texts [0].text = "the winner is  " + PlayerPrefs.GetString ("Winner");
	}
	
	// Update is called once per frame
	void Update () {
		//Xinput
		prevState = state;
		state = GamePad.GetState(playerIndex);

		//PlayerPrefs.getString("Winner");


		if(state.ThumbSticks.Left.Y == 1 && prevState.ThumbSticks.Left.Y != 1){
			_Selection -= 1;
		}
		if (state.ThumbSticks.Left.Y == -1 && prevState.ThumbSticks.Left.Y != -1){
			_Selection += 1;
		}

		switch (_Selection) {
				case(0):

						if (state.Buttons.A == ButtonState.Pressed) {
								Application.LoadLevel ("CountdownScreen");
						}
						break;
			
				case(1):
						if (state.Buttons.A == ButtonState.Pressed) {
								Application.LoadLevel ("TitleScreen");
						}
						break;
				}
	}
}
