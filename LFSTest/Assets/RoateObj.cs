using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoateObj : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.right * -5);
	}
}
