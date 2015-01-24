using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	private GameObject _LastGoalHit;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider _collider){
		if(_collider.tag == "Goal" && _LastGoalHit != _collider.gameObject){
			_LastGoalHit = _collider.gameObject;
			GetComponent<PlayerState>()._Score += 1;
		}
	}
}
