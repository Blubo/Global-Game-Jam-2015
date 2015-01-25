using UnityEngine;
using System.Collections;

public class GUI_Scores : MonoBehaviour {

	public GameObject v_player1, v_player2, v_player3, v_player4;
	public GameObject v_GUIp1, v_GUIp2, v_GUIp3, v_GUIp4;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//v_AfficheChainMultiplicator.guiText.fontStyle = FontStyle.Bold;

	}

	void OnGUI(){
		//rouge
		v_GUIp1.guiText.alignment = TextAlignment.Left;
		v_GUIp1.guiText.anchor = TextAnchor.UpperLeft;
		v_GUIp1.guiText.fontSize = 70;
		v_GUIp1.transform.position = new Vector3(0.01f,0.98f,0f);
		v_GUIp1.guiText.text = v_player1.GetComponent<PlayerState>()._Score.ToString();

		//bleu
		v_GUIp2.guiText.alignment = TextAlignment.Left;
		v_GUIp2.guiText.anchor = TextAnchor.UpperRight;
		v_GUIp2.guiText.fontSize = 70;
		v_GUIp2.transform.position = new Vector3(0.98f,0.98f,0f);
		v_GUIp2.guiText.text = v_player2.GetComponent<PlayerState>()._Score.ToString();

		//vert
		v_GUIp3.guiText.alignment = TextAlignment.Left;
		v_GUIp3.guiText.anchor = TextAnchor.LowerLeft;
		v_GUIp3.guiText.fontSize = 70;
		v_GUIp3.transform.position = new Vector3(0.01f,0.01f,0f);
		v_GUIp3.guiText.text = v_player3.GetComponent<PlayerState>()._Score.ToString();;

		//orange
		v_GUIp4.guiText.alignment = TextAlignment.Left;
		v_GUIp4.guiText.anchor = TextAnchor.LowerRight;
		v_GUIp4.guiText.fontSize = 70;
		v_GUIp4.transform.position = new Vector3(0.988f,0.01f,0f);
		v_GUIp4.guiText.text = v_player4.GetComponent<PlayerState>()._Score.ToString();

	}
}
