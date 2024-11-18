using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllLevelButtons : MonoBehaviour {

	public LevelDetails[] Lbutton;
	public static  AllLevelButtons mee;
	// Use this for initialization
	void Start () {
		mee = this;
	}

	public void CheckAllButtons(){
		foreach( LevelDetails aa in Lbutton){
			aa.CheckLockTheme1 ();
		}
	}
	// Update is called once per frame
	void Update () {
		
	}
}
