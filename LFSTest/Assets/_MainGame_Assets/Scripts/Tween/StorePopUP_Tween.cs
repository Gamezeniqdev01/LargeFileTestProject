using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StorePopUP_Tween : MonoBehaviour 
{
	public static StorePopUP_Tween myScript;
	public GameObject[] Objs;
	
	void Awake()
	{
		myScript=this;
	}

	void Start () 
	{
	}
	
	void Update () 
	{
	
	}

	public void PopUp_In()
	{
		iTween.ScaleTo (Objs[0].gameObject, iTween.Hash ("x", 0.7f,"y", 0.7f, "time", 0.5, "islocal", true, "delay", 0, "easetype", iTween.EaseType.easeOutSine));
		for(int i=1;i<Objs.Length;i++)
		{
			iTween.ScaleTo (Objs[i].gameObject, iTween.Hash ("x", 1,"y", 1, "time", 0.5, "islocal", true, "delay", 0, "easetype", iTween.EaseType.easeOutSine));
		}
		MenuManager.myScript.GameState = MenuManager.MenuState.StorePopUp;
		//UpgradeControl.myScript.CameraUpgrade.gameObject.SetActive(false);
	}
	
	public void PopUp_Out(bool State)
	{
		for(int i=0;i<Objs.Length;i++)
		{
			iTween.ScaleTo (Objs[i].gameObject, iTween.Hash ("x", 0,"y", 0, "time", 0.25, "islocal", true, "delay", 0, "easetype", iTween.EaseType.easeOutSine));
		}

		if (State == true) 
		{
//			MenuManager.myScript.GameState = MenuManager.MenuState.Packs;
			Upgrade_Tween.myScript.Upgrade_Out();
		}
		else
		{
			MenuManager.myScript.GameState = MenuManager.MenuState.Flights;
		}

		UpgradeControl.myScript.CameraUpgrade.gameObject.SetActive(true);
	}
}
