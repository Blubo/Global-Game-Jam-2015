using UnityEngine;
using System.Collections;

public class LinkedBLock : MonoBehaviour {

	public GameObject v_firstTarget, v_secondTarget;
	public float v_moveSpeed;
	[HideInInspector]
	public int _currentTarget=1;
	[HideInInspector]
	public bool moving, movingTowards1, movingTowards2;

	// Use this for initialization
	void Start () {
		moving = false;
		movingTowards1=true;
		movingTowards2=false;
	}
	
	// Update is called once per frame
	void Update () {
		if(movingTowards1 == true){
			MoveTowardsNext(v_firstTarget);
			if(gameObject.transform.position == v_firstTarget.transform.position){
				movingTowards1 = false;
				moving = false;
			}
		}

		if(movingTowards2 == true){
			MoveTowardsNext(v_secondTarget);
			if(gameObject.transform.position == v_secondTarget.transform.position){
				movingTowards2 = false;
				moving = false;
			}
		}
	
	}

	public void MoveTowardsNext(GameObject target){
		gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, target.transform.position, v_moveSpeed);
		moving=true;
	}
}
