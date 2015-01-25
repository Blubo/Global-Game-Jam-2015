using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChangingSprite : MonoBehaviour {

	public List<Sprite> _Faces;
	private Sprite _ActualFace;

	// Use this for initialization
	void Start () {
		_ActualFace = _Faces [0];
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<SpriteRenderer> ().sprite = _ActualFace;

		if(transform.parent.GetComponent<RigidMovement>().v_readyToDash == true){
			//0 est face normale
			//1 est face venere
			//2 est face kawaii
			_ActualFace = _Faces[0];
//			transform.parent.GetComponent<RigidMovement>()._changesprite = false;
		}else{
			_ActualFace = _Faces[1];

		}
	}
}
