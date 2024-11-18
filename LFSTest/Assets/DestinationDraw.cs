using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationDraw : MonoBehaviour {

	public GameObject[] DestinationPoints;
	public LineRenderer LineObj;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		


		for(int i=0;i<DestinationPoints.Length;i++){
		LineObj.SetPosition(i, DestinationPoints[i].transform.position);
		}
	}
}
