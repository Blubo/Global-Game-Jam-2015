using UnityEngine;
using System.Collections;

public class InterruptorBlocs : MonoBehaviour {

	public GameObject v_linkedBlock;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collision){
		if(collision.gameObject.tag.Equals("Player")){
			if(v_linkedBlock.GetComponent<LinkedBLock>().moving == false){

				if(v_linkedBlock.GetComponent<LinkedBLock>().movingTowards1 ==false && v_linkedBlock.GetComponent<LinkedBLock>().movingTowards2 ==false){
					v_linkedBlock.GetComponent<LinkedBLock>().movingTowards1 = true;
				}

				if(v_linkedBlock.GetComponent<LinkedBLock>().movingTowards1 == true){
					v_linkedBlock.GetComponent<LinkedBLock>().movingTowards2 = true;
				}
				if(v_linkedBlock.GetComponent<LinkedBLock>().movingTowards2 == true){
					v_linkedBlock.GetComponent<LinkedBLock>().movingTowards1 = true;
				}
			}
		}
	}
}
