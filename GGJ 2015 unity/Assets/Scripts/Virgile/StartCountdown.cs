using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StartCountdown : MonoBehaviour {
	
	public GameObject gui3, gui2, gui1, goHam1;
	public List<GameObject> _Players;
	public List<TextMesh> _Texts;
	public Transform _FinalPlacement;
	public GameObject v_destinationCamera;

	private bool _CameraGo = false;

	// Use this for initialization
	void Start () {
		Camera.main.orthographicSize = 12.58f;
		StartCoroutine ("Introduction");

		gui3.gameObject.guiText.enabled=false;
		gui2.gameObject.guiText.enabled=false;
		gui1.gameObject.guiText.enabled=false;
		goHam1.gameObject.guiText.enabled=false;
		
		gui3.guiText.fontSize = 50;
		gui3.guiText.alignment = TextAlignment.Center;
		gui3.guiText.anchor = TextAnchor.MiddleCenter;
		gui3.transform.position = new Vector3(0.5f,0.5f,0f);
		gui3.guiText.text = "3";
		
		gui2.guiText.fontSize = 50;
		gui2.guiText.alignment = TextAlignment.Center;
		gui2.guiText.anchor = TextAnchor.MiddleCenter;
		gui2.transform.position = new Vector3(0.5f,0.5f,0f);
		gui2.guiText.text = "2";
		
		gui1.guiText.fontSize = 50;
		gui1.guiText.alignment = TextAlignment.Center;
		gui1.guiText.anchor = TextAnchor.MiddleCenter;
		gui1.transform.position = new Vector3(0.5f,0.5f,0f);
		gui1.guiText.text = "1";
		
		goHam1.guiText.fontSize = 60;
		goHam1.guiText.alignment = TextAlignment.Center;
		goHam1.guiText.anchor = TextAnchor.MiddleCenter;
		goHam1.transform.position = new Vector3(0.5f,0.5f,0f);
		goHam1.guiText.text = "GO!";
	}

	void Update(){
		//Replacement de la camera 
		if(_CameraGo ){
			if(Camera.main.orthographicSize <31.52f){
				Camera.main.orthographicSize += 0.4f;
				Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position, v_destinationCamera.transform.position,1);
			}

			if(Camera.main.orthographicSize >31.52f){
				Camera.main.orthographicSize = 31.52f;
			}

		}
	}

	IEnumerator Introduction(){
		for(int i =0; i <_Players.Count; i++){
			_Texts[i].transform.position = _Players[i].transform.position;
			_Texts[i].transform.position = new Vector3(_Texts[i].transform.position.x+2f, _Texts[i].transform.position.y, _Texts[i].transform.position.z+0.75f);
		}
		yield return new WaitForSeconds (0.7f);
		_CameraGo = true;
		yield return new WaitForSeconds (3f);

		StartCoroutine(GoHamCounter());
	}

	IEnumerator GoHamCounter(){
		//Counter
		for (float timer = 1f; timer >= 0; timer -= Time.deltaTime){
			gui3.gameObject.guiText.enabled=true;
			gui3.gameObject.guiText.fontSize+=2;
			yield return 0;
		}
		gui3.gameObject.guiText.enabled=false;
		
		for (float timer = 1f; timer >= 0; timer -= Time.deltaTime){
			gui2.gameObject.guiText.enabled=true;
			gui2.gameObject.guiText.fontSize+=2;
			yield return 0;
		}
		gui2.gameObject.guiText.enabled=false;
		
		for (float timer = 1f; timer >= 0; timer -= Time.deltaTime){
			gui1.gameObject.guiText.enabled=true;
			gui1.gameObject.guiText.fontSize+=2;
			yield return 0;
		}
		gui1.gameObject.guiText.enabled=false;
		
		for (float timer = 1f; timer >= 0; timer -= Time.deltaTime){
			goHam1.gameObject.guiText.enabled=true;
			goHam1.gameObject.guiText.fontSize+=2;
			yield return 0;
		}
		goHam1.gameObject.guiText.enabled=false;

		//Passage au gameplay
//		Application.LoadLevel("GameScene");
		Application.LoadLevel("ThirdPlaytest");

	}
}
