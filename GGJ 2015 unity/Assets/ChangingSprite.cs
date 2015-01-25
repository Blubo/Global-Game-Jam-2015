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

		if(transform.parent.GetComponent<RigidMovement>()._changesprite == true){
			_ActualFace = _Faces[Random.Range(0,_Faces.Count)];
			transform.parent.GetComponent<RigidMovement>()._changesprite = false;
		}
	}
}
