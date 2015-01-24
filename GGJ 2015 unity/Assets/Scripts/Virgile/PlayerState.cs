using UnityEngine;
using System.Collections;

public class PlayerState : MonoBehaviour {
	
	[HideInInspector]
	public bool _canMove;
	
	[HideInInspector]
	public int _Score;
	
	// Use this for initialization
	void Start () {
		_canMove=false;
		_Score = 0;
	}
	
	// Update is called once per frame
	void Update () {

	}
}
