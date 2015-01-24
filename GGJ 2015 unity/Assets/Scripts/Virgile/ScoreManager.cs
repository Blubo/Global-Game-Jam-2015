using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	private GameObject _LastGoalHit;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(GetComponent<PlayerState>()._Score == 10){
			StartCoroutine("EndOfTheGame");
		}
	}

	void OnTriggerEnter(Collider _collider){
		if(_collider.tag == "Goal" && _LastGoalHit != _collider.gameObject){
			_LastGoalHit = _collider.gameObject;
			GetComponent<PlayerState>()._Score += 1;
		}
	}

	IEnumerator EndOfTheGame(){
		//On retient le nom du gagnant
		PlayerPrefs.SetString ("Winner", gameObject.name);
		//On rend visible l'annonce de fin de partie par un texte

		yield return new WaitForSeconds(1.0f);

		//Passage à la scène de score
		Application.LoadLevel ("ScoreScreen");
	}
}
