using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DailyBonusTween : MonoBehaviour 
{
	public static DailyBonusTween myScript;

	public GameObject Ttl_DB,Btn_Back,Text_TodayR,Text_TodayCash;

	public GameObject[] Days; 

	public GameObject BG;

	
	void Awake()
	{
		myScript=this;
	}

	void Start () 
	{
		Invoke("DailyBonus_In",0.1f);
	}
	
	void Update () 
	{
	
	}

	public void DailyBonus_In()
	{
		MenuManager.myScript.GameState = MenuManager.MenuState.DailyBonus;

		iTween.MoveTo (Days[0].gameObject, iTween.Hash ("x", -410, "time", 0.5, "islocal", true, "delay", 0, "easetype", iTween.EaseType.easeOutSine));
		iTween.MoveTo (Days[1].gameObject, iTween.Hash ("x", -270, "time", 0.5, "islocal", true, "delay", 0.01, "easetype", iTween.EaseType.easeOutSine));
		iTween.MoveTo (Days[2].gameObject, iTween.Hash ("x", -135, "time", 0.5, "islocal", true, "delay", 0.02, "easetype", iTween.EaseType.easeOutSine));
		iTween.MoveTo (Days[3].gameObject, iTween.Hash ("x", 0, "time", 0.5, "islocal", true, "delay", 0.03, "easetype", iTween.EaseType.easeOutSine));
		iTween.MoveTo (Days[4].gameObject, iTween.Hash ("x", 135, "time", 0.5, "islocal", true, "delay", 0.04, "easetype", iTween.EaseType.easeOutSine));
		iTween.MoveTo (Days[5].gameObject, iTween.Hash ("x", 270, "time", 0.5, "islocal", true, "delay", 0.05, "easetype", iTween.EaseType.easeOutSine));
		iTween.MoveTo (Days[6].gameObject, iTween.Hash ("x", 410, "time", 0.5, "islocal", true, "delay", 0.06, "easetype", iTween.EaseType.easeOutSine));

		iTween.MoveTo (Btn_Back.gameObject, iTween.Hash ("x", -393.9, "time", 0.5, "islocal", true, "delay", 0, "easetype", iTween.EaseType.easeOutSine));
		iTween.MoveTo (Ttl_DB.gameObject, iTween.Hash ("x", 0,"y",200, "time", 0.5, "islocal", true, "delay", 0, "easetype", iTween.EaseType.easeOutSine));

		iTween.MoveTo (Text_TodayR.gameObject, iTween.Hash ("x", -142, "time", 0.5, "islocal", true, "delay", 0, "easetype", iTween.EaseType.easeOutSine));
		iTween.MoveTo (Text_TodayCash.gameObject, iTween.Hash ("x", 158, "time", 0.5, "islocal", true, "delay", 0, "easetype", iTween.EaseType.easeOutSine));
	}

	public void DailyBonus_Out()
	{
		for(int i=0;i<Days.Length;i++)
		{
			iTween.MoveTo (Days[i].gameObject, iTween.Hash ("x", 1500, "time", 0.5, "islocal", true, "delay", 0, "easetype", iTween.EaseType.easeOutSine));
		}
		iTween.MoveTo (Btn_Back.gameObject, iTween.Hash ("x", -1500, "time", 0.5, "islocal", true, "delay", 0, "easetype", iTween.EaseType.easeOutSine));
		iTween.MoveTo (Ttl_DB.gameObject, iTween.Hash ("x", -1500, "time", 0.5, "islocal", true, "delay", 0, "easetype", iTween.EaseType.easeOutSine));
		
		iTween.MoveTo (Text_TodayR.gameObject, iTween.Hash ("x", -1500, "time", 0.5, "islocal", true, "delay", 0, "easetype", iTween.EaseType.easeOutSine));
		iTween.MoveTo (Text_TodayCash.gameObject, iTween.Hash ("x", -1500, "time", 0.5, "islocal", true, "delay", 0, "easetype", iTween.EaseType.easeOutSine));


		BG.GetComponent<AlphaScript>().AlphaValue=0;
		BG.GetComponent<AlphaScript>().AlphFade();
		Invoke("OffCanvas",1);


	}

	void OffCanvas()
	{
		this.gameObject.SetActive(false);
	}
}
