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
	public List<GUIText> _Scores;

	// Use this for initialization
	void Start () {
		_Scores [0].transform.position = new Vector3 (0.18f,0.9f,0.0f);
		_Scores [1].transform.position = new Vector3 (0.42f,0.9f,0.9f);
		_Scores [2].transform.position = new Vector3 (0.67f,0.9f,0.9f);
		_Scores [3].transform.position = new Vector3 (0.9f,0.9f,0.9f);

		_Scores [0].text =""+ PlayerPrefs.GetInt ("ScoreJ1");
		_Scores [1].text =""+ PlayerPrefs.GetInt ("ScoreJ2");
		_Scores [2].text =""+ PlayerPrefs.GetInt ("ScoreJ3");
		_Scores [3].text =""+ PlayerPrefs.GetInt ("ScoreJ4");
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
								Application.LoadLevel ("NewCountdownScreen");
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
