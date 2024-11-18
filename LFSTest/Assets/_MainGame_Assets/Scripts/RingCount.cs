using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RingCount : MonoBehaviour 
{
	public static RingCount myScript;

	public bool Is_OnlyOnce;

	public bool Is_timer = false;


	void Awake()
	{
		myScript=this;
	}
	
	void Start () 
	{
		Is_OnlyOnce = true;
	}
	
	void Update () 
	{
		
	}
	
	void OnTriggerEnter(Collider Obj)
	{

		if(Obj.transform.tag=="Body" && Is_OnlyOnce && Is_timer)
		{
			Is_OnlyOnce=false;
			this.transform.parent.gameObject.SetActive (false);

			TimerScript.myScript.TimerTimeInSec += 30f;



		}

		else if(Obj.transform.tag=="Body" && Is_OnlyOnce)
		{
			Is_OnlyOnce=false;
			LevelManager.myScript.CollectedRings+=1;

			GameManager.myScript.UpdateCollectText ();
		//	this.gameObject.transform.GetComponent<MapMarker>().enabled=false;
		//	this.gameObject.transform.parent.GetComponent<Renderer>().enabled=false;
			this.transform.parent.gameObject.SetActive (false);
			print("Ring : "+LevelManager.myScript.CollectedRings);

			StarAnim.mee.callstar ();

//

//			GameObject starObjj=GameManager.myScript.StarEffect.gameObject;
//			starObjj.SetActive (true);
//			starObjj.transform.localScale = Vector3.one * 14;
//			starObjj.transform.position = this.transform.position;
//		//	starObjj.transform.eulerAngles = this.transform.eulerAngles;
//
//			iTween.MoveTo (starObjj.transform.GetChild(0).gameObject,iTween.Hash("x",Obj.transform.position.x-100,"time",0.5,"delay",0,"eastype",iTween.EaseType.linear));
//
//
//		//	iTween.MoveTo (starObjj.gameObject,iTween.Hash("position",GameManager.myScript.Refpoint.transform.position,"time",1,"delay",0.5,"eastype",iTween.EaseType.linear));
//			iTween.ScaleTo (starObjj.transform.GetChild(1).gameObject,iTween.Hash("x",0,"y",0,"time",0.5,"delay",0.1,"eastype",iTween.EaseType.linear));
		}
	}
}
