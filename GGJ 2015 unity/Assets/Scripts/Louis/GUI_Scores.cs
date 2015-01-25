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
		v_GUIp1.guiText.alignment = TextAlignment.Left;
		v_GUIp1.guiText.anchor = TextAnchor.UpperLeft;
		v_GUIp1.guiText.fontSize = 40;
		v_GUIp1.transform.position = new Vector3(0.04f,0.96f,0f);
//		v_GUIp1.guiText.color = Color.red;
//		v_GUIp1.guiText.text = v_player1.name + " : " + v_player1.GetComponent<PlayerState>()._Score;
		v_GUIp1.guiText.text = v_player1.GetComponent<PlayerState>()._Score.ToString();

		v_GUIp2.guiText.alignment = TextAlignment.Left;
		v_GUIp2.guiText.anchor = TextAnchor.UpperRight;
		v_GUIp2.guiText.fontSize = 40;
//		v_GUIp2.transform.position = new Vector3(1,1,0f);
		v_GUIp2.transform.position = new Vector3(0.96f,0.96f,0f);
//		v_GUIp2.guiText.color = Color.blue;
//		v_GUIp2.guiText.color = new Color32(33, 23, 101, 255);
//		v_GUIp2.guiText.text = v_player2.name + " : " + v_player2.GetComponent<PlayerState>()._Score;
		v_GUIp2.guiText.text = v_player2.GetComponent<PlayerState>()._Score.ToString();

		v_GUIp3.guiText.alignment = TextAlignment.Left;
		v_GUIp3.guiText.anchor = TextAnchor.LowerLeft;
		v_GUIp3.guiText.fontSize = 40;
//		v_GUIp3.transform.position = new Vector3(0,0,0f);
		v_GUIp3.transform.position = new Vector3(0.04f,0.04f,0f);
//		v_GUIp3.guiText.color = Color.green;
//		v_GUIp2.guiText.color = new Color32(0, 107, 18, 255);
//		v_GUIp3.guiText.text = v_player3.name + " : " + v_player3.GetComponent<PlayerState>()._Score;
		v_GUIp3.guiText.text = v_player3.GetComponent<PlayerState>()._Score.ToString();;

		v_GUIp4.guiText.alignment = TextAlignment.Left;
		v_GUIp4.guiText.anchor = TextAnchor.LowerRight;
		v_GUIp4.guiText.fontSize = 40;
//		v_GUIp4.transform.position = new Vector3(1,0,0f);
		v_GUIp4.transform.position = new Vector3(0.96f,0.04f,0f);
//		v_GUIp4.guiText.color = new Color32(255, 153, 0, 255);
//		v_GUIp4.guiText.color = new Color32(229, 92, 0, 255);

//		v_GUIp4.guiText.text = v_player4.name + " : " + v_player4.GetComponent<PlayerState>()._Score;
		v_GUIp4.guiText.text = v_player4.GetComponent<PlayerState>()._Score.ToString();

	}

}
