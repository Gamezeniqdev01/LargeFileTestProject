using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarAnim : MonoBehaviour {

	public GameObject myObj;
	public Transform Target;
	public TrailRenderer lrender;

	public static StarAnim mee;
	// Use this for initialization
	void Start () {
		mee = this;

	//	Invoke ("callstar",1);

	}
	
	// Update is called once per frame
	public void callstar () {

		//Invoke ("callstar",5);
		Invoke ("online",0.1f);

		myObj.transform.localPosition = Vector3.zero;
		myObj.transform.localScale = Vector3.zero;

		iTween.ScaleTo (myObj,iTween.Hash("x",1,"y",1,"z",1,"time",0.2,"easetype",iTween.EaseType.linear));
		iTween.MoveTo (myObj,iTween.Hash("position",Target.transform.localPosition,"time",0.5,"delay",1,"islocal",true,"easetype",iTween.EaseType.easeInBack));

		iTween.ScaleTo (myObj,iTween.Hash("x",0,"y",0,"z",0,"time",0.5,"delay",1.7,"easetype",iTween.EaseType.easeInElastic));
		Invoke ("Offline",1.8f);

	}

	void Offline(){
		lrender.enabled = false;
	}

	void Online(){
		lrender.enabled = false;
	}
}
