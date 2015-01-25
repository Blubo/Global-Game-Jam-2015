using UnityEngine;
using System.Collections;

public class BackgroundMovement : MonoBehaviour {

	public float _SpeedScroll;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float offset = Time.time * _SpeedScroll;
		renderer.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
	}
}
