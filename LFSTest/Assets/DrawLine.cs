using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour {


	public  GameObject MiddleBottom;
	public  GameObject TopBottom;
	public  GameObject cubeBottom;
	public  GameObject Top2Bottom;

	public  LineRenderer line;


	// Use this for initialization
	void Start () {
		
	}



	// Update is called once per frame
	void Update () {
		line.SetPosition(0, cubeBottom.transform.position);
		line.SetPosition(1, MiddleBottom.transform.position);
		line.SetPosition(2, TopBottom.transform.position);
		line.SetPosition(3, Top2Bottom.transform.position);
	}
}
