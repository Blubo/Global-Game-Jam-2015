using UnityEngine;
using System.Collections;

public class GUI_Score1 : MonoBehaviour {
	
	private int _score;
	public GameObject v_player;

	void Start () {
		_score =0;
		gameObject.AddComponent<GUIText>();
	}
	
	void Update () {
	}
	
	void OnGUI() {
		gameObject.guiText.anchor = TextAnchor.UpperLeft;
		gameObject.guiText.alignment = TextAlignment.Left;
		gameObject.guiText.fontSize = 40;
		gameObject.guiText.font.material.color=Color.red;
		gameObject.guiText.text = v_player.gameObject.name + " : " + v_player.gameObject.GetComponent<PlayerState>()._Score;
		gameObject.guiText.transform.position=new Vector3(0, 1, 0);
	}
}
