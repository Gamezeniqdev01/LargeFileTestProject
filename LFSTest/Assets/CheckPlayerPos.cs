using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayerPos : MonoBehaviour {

	public GameObject MCheckpoint;
	public TextMesh Mtext;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(LevelManager.MyPlayer!=null){
			float aa = (Vector3.Distance (Mtext.gameObject.transform.position, LevelManager.MyPlayer.transform.position)*0.2f)-100;
			if (aa <= 1500 && aa >= 0.1f) {
				Mtext.text = "" + aa;
			} else {
				Mtext.text = "";
			}
		}
	}
}
