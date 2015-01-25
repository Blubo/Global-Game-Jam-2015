using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameOverManager : MonoBehaviour {

	public List<GameObject> _Players;

	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt ("ScoreJ1", _Players [0].GetComponent<PlayerState> ()._Score);
		PlayerPrefs.SetInt ("ScoreJ2", _Players [1].GetComponent<PlayerState> ()._Score);
		PlayerPrefs.SetInt ("ScoreJ3", _Players [2].GetComponent<PlayerState> ()._Score);
		PlayerPrefs.SetInt ("ScoreJ4", _Players [3].GetComponent<PlayerState> ()._Score);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
