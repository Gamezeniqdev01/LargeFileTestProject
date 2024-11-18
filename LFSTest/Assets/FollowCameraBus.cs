using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCameraBus : MonoBehaviour {

	public Transform targetObj;
	public Transform LookObj;

	public Transform targetObj2;
	public Transform LookObj2;


	// Use this for initialization
	void Start () {
		
	}

	public void ChangeTarget()
	{
		targetObj2.transform.parent = targetObj.transform.parent;
		targetObj.transform.position = targetObj2.transform.position;
		LookObj.transform.position = LookObj2.transform.position;
	}
	// Update is called once per frame
	void Update () {

	//	this.transform.position = targetObj.transform.position;
		this.transform.LookAt (LookObj.transform);
	}
}
