using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Packs_Tween : MonoBehaviour 
{
	public static Packs_Tween myScript;

	public GameObject Btn_Back,Ttl_Packs,Btn_Mg;
	
	public GameObject[] Panels;

	public int OutCount;

	void Awake()
	{
		myScript=this;
	}

	void Start () 
	{
	
	}
	
	void Update () 
	{
//		print ("OutCount : " + OutCount);
	}

	public void Packs_In()
	{
		CheckPage();
		MenuManager.myScript.GameState = MenuManager.MenuState.Packs;
		if(SoundsManager.myScript!=null)
		{
			SoundsManager.myScript.Sound_Button.GetComponent<AudioSource>().Play();
		}
		Ttl_Packs.GetComponent<AlphaScript> ().Delay = 0;
		Ttl_Packs.GetComponent<AlphaScript> ().TimeInSec = 0.5f;
		Ttl_Packs.GetComponent<AlphaScript> ().AlphaValue = 1;
		Ttl_Packs.GetComponent<AlphaScript> ().AlphFade ();

		iTween.MoveTo (Btn_Back.gameObject, iTween.Hash ("x", -393.9, "time", 0.5, "islocal", true, "delay", 0, "easetype", iTween.EaseType.easeOutSine));	
		
		iTween.MoveTo (Panels[1].gameObject, iTween.Hash ("x", 200, "time", 0.5, "islocal", true, "delay", 0.1, "easetype", iTween.EaseType.easeOutSine));	
		iTween.MoveTo (Panels[2].gameObject, iTween.Hash ("x", 0, "time", 0.5, "islocal", true, "delay", 0.1, "easetype", iTween.EaseType.easeOutSine));	
		iTween.MoveTo (Panels[0].gameObject, iTween.Hash ("x",-200, "time", 0.5, "islocal", true, "delay", 0.2, "easetype", iTween.EaseType.easeOutSine));	
		iTween.MoveTo (Panels[3].gameObject, iTween.Hash ("x", 400, "time", 0.5, "islocal", true, "delay", 0.2, "easetype", iTween.EaseType.easeOutSine));	
		iTween.MoveTo (Panels[4].gameObject, iTween.Hash ("x", -400, "time", 0.5, "islocal", true, "delay", 0.2, "easetype", iTween.EaseType.easeOutSine));

		iTween.MoveTo (Btn_Mg.gameObject, iTween.Hash ("x", 359, "time", 0.5, "islocal", true, "delay", 0, "easetype", iTween.EaseType.easeOutSine));	

	}
	
	public void Packs_Out()
	{
		Ttl_Packs.GetComponent<AlphaScript> ().Delay = 0;
		Ttl_Packs.GetComponent<AlphaScript> ().TimeInSec = 0.2f;
		Ttl_Packs.GetComponent<AlphaScript> ().AlphaValue =0;
		Ttl_Packs.GetComponent<AlphaScript> ().AlphFade ();
		
		iTween.MoveTo (Btn_Back.gameObject, iTween.Hash ("x", -1500, "time", 0.5, "islocal", true, "delay", 0, "easetype", iTween.EaseType.easeOutSine));	
		
		iTween.MoveTo (Panels[1].gameObject, iTween.Hash ("x", -1500, "time", 0.5, "islocal", true, "delay", 0.1, "easetype", iTween.EaseType.easeOutSine));	
		iTween.MoveTo (Panels[2].gameObject, iTween.Hash ("x", 1500, "time", 0.5, "islocal", true, "delay", 0.1, "easetype", iTween.EaseType.easeOutSine));	
		iTween.MoveTo (Panels[0].gameObject, iTween.Hash ("x",-1500, "time", 0.5, "islocal", true, "delay", 0.2, "easetype", iTween.EaseType.easeOutSine));	
		iTween.MoveTo (Panels[3].gameObject, iTween.Hash ("x",1500, "time", 0.5, "islocal", true, "delay", 0.2, "easetype", iTween.EaseType.easeOutSine));	
		iTween.MoveTo (Panels[4].gameObject, iTween.Hash ("x", -1500, "time", 0.5, "islocal", true, "delay", 0.2, "easetype", iTween.EaseType.easeOutSine));

		iTween.MoveTo (Btn_Mg.gameObject, iTween.Hash ("x", 1500, "time", 0.5, "islocal", true, "delay", 0, "easetype", iTween.EaseType.easeOutSine));	

		if(OutCount==0)
		{
			Menu_Tween.myScript.Menu_In();
			print("this is");
		}
		else
		if(OutCount==1)
		{
			Menu_Tween.myScript.Menu_In();
			print("this is");
		}
		else
			if(OutCount==2)
		{
			Store_Tween.myScript.Store_In();
			print("this is");
		}
		else
			if(OutCount==3)
		{
			Opt_Tween.myScript.Opt_In();
			print("this is");
		}
		else
			if(OutCount==4)
		{
			Phase_Tween.myScript.Phase_In(1);
			print("this is");
		}
		else
			if(OutCount==5)
		{
			Phase_Tween.myScript.Phase_In(2);
			print("this is");
		}
		else
			if(OutCount==6)
		{
			Phase_Tween.myScript.Phase_In(3);
			print("this is");
		}
		else
			if(OutCount==7)
		{
			Upgrade_Tween.myScript.Upgrade_In();
			print("this is");
		}
	}

	public void CheckPage()
	{
		if(MenuManager.myScript.GameState==MenuManager.MenuState.Menu)
		{
			OutCount=1;
			Menu_Tween.myScript.Menu_Out();
		}
		else
		if(MenuManager.myScript.GameState==MenuManager.MenuState.Store)
		{
			OutCount=2;
			Store_Tween.myScript.Store_Out();
		}
		else
			if(MenuManager.myScript.GameState==MenuManager.MenuState.Options)
		{
			OutCount=3;
			Opt_Tween.myScript.Opt_Out();
		}
		else
			if(MenuManager.myScript.GameState==MenuManager.MenuState.Phase1)
		{
			OutCount=4;
			Phase_Tween.myScript.Phase_Out();
		}
		else
			if(MenuManager.myScript.GameState==MenuManager.MenuState.Phase2)
		{
			OutCount=5;
			Phase_Tween.myScript.Phase_Out();
		}
		else
			if(MenuManager.myScript.GameState==MenuManager.MenuState.Phase3)
		{
			OutCount=6;
			Phase_Tween.myScript.Phase_Out();
		}
		else
			if(MenuManager.myScript.GameState==MenuManager.MenuState.Flights ||
			   MenuManager.myScript.GameState==MenuManager.MenuState.StorePopUp)
		{
			OutCount=7;
			Upgrade_Tween.myScript.Upgrade_Out();
		}
	}

	public void Puchase_Check(int Count)
	{
	//	GoogleIAB.purchaseProduct (InAppPurchaseManager.allSkus [Count]);
	}

}
