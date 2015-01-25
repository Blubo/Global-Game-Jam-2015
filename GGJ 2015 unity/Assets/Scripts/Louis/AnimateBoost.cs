using UnityEngine;
using System.Collections;

public class AnimateBoost : MonoBehaviour {

	public Sprite v_image1, v_image2, v_image3;
	private Sprite _actualImage;
	private float timer;
	[Range(0,1)]
	public float v_animationSpeed;

	// Use this for initialization
	void Start () {
		_actualImage=v_image1;
	}
	
	// Update is called once per frame
	void Update () {
		timer+=Time.deltaTime;
		if(timer>v_animationSpeed){
			if(_actualImage==v_image1){
				_actualImage = v_image2;
				timer=0f;
			}else

			if(_actualImage==v_image2){
				_actualImage = v_image3;
				timer=0f;
			}else 

			if(_actualImage==v_image3){
				_actualImage = v_image1;
				timer=0f;
			}

			GetComponent<SpriteRenderer> ().sprite = _actualImage;


		}
	}
}
