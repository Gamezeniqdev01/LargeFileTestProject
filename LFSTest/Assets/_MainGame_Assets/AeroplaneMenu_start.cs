using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AeroplaneMenu_start : MonoBehaviour {

	public hoMove AeroplaneTweenObj;
	public hoMove CamHomove;

	public PathManager Cam2Path;

	public Transform mObj;

	public GameObject parentObj;
	private bool LookNow=false;
	// Use this for initialization
	void Start () {
		Invoke ("StartPlane",6);
		Invoke ("StartEngine",1);
	}
	
	void StartEngine () {

		SoundsManager.myScript.Sound_TakeOff.GetComponent<AudioSource>().Play();

	}
	void StartPlane () {

		SoundsManager.myScript.Sound_InFlight.GetComponent<AudioSource>().Play();
		SoundsManager.myScript.Sound_InFlight.GetComponent<AudioSource>().loop=true;


		AeroplaneTweenObj.enabled = true;	
		parentObj.transform.parent = null;
		LookNow = true;

		parentObj.transform.parent = CamHomove.transform;
		CamHomove.gameObject.SetActive (true);

		//CamHomove.pathContainer = Cam2Path;

		//iTween.MoveTo (this.gameObject,iTween.Hash("position",mObj.transform.position,"delay",0.2f,"time",10,"easetype",iTween.EaseType.linear));
	}

	void Update(){
		if(LookNow)
			parentObj.transform.LookAt (AeroplaneTweenObj.transform);
	}
}
