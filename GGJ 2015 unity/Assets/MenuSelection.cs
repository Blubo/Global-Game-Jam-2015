using UnityEngine;
using System.Collections;
using XInputDotNetPure;
using System.Collections.Generic;

public class MenuSelection : MonoBehaviour {
	//Xinput
	bool playerIndexSet = false;
	public PlayerIndex playerIndex;
	GamePadState state;
	GamePadState prevState;

	public List<GUIText> _LVL;
	private int _selection =0;

	// Use this for initialization
	void Start () {
		_LVL [0].transform.position = new Vector3 (0.1f, 0.5f, 0.0f);
		_LVL [1].transform.position = new Vector3 (0.8f, 0.5f, 0.0f);

		_LVL [0].text = "LVL1";
		_LVL [1].text = "LVL2";
	}
	
	// Update is called once per frame
	void Update () {
		//Xinput
		prevState = state;
		state = GamePad.GetState(playerIndex);

		if(state.ThumbSticks.Left.X == 1 && prevState.ThumbSticks.Left.X != 1){
			_selection += 1;
		}
		if (state.ThumbSticks.Left.X == -1 && prevState.ThumbSticks.Left.X != -1){
			_selection -= 1;
		}

		_selection = Mathf.Clamp (_selection, 0, 1);

		_LVL[0].fontSize = 20;
		_LVL[1].fontSize = 20;

		switch (_selection) {
		case(0):
			if (state.Buttons.A == ButtonState.Pressed) {
				Application.LoadLevel ("NewCountdownScreen");
			}
			_LVL[0].fontSize = 50;
			break;
			
		case(1):
			if (state.Buttons.A == ButtonState.Pressed) {
				Application.LoadLevel ("TestLD");
			}
			_LVL[1].fontSize = 50;
			break;
		}
	}
}
