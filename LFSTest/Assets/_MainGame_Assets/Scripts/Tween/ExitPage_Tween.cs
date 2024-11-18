using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ExitPage_Tween : MonoBehaviour 
{
	public static ExitPage_Tween myScript;
	public GameObject[] Objs;
	
	void Awake()
	{
		myScript=this;
	}

	void Start () 
	{
//		Exit_In ();
	}
	
	void Update () 
	{
	
	}

	public void Exit_In()
	{
		for(int i=0;i<Objs.Length;i++)
		{
			iTween.ScaleTo (Objs[i].gameObject, iTween.Hash ("x", 1,"y", 1, "time", 0.5, "islocal", true, "delay", 0, "easetype", iTween.EaseType.easeOutSine));
		}

		MenuManager.myScript.GameState = MenuManager.MenuState.Exit;
	}

	public void Exit_Out()
	{
		for(int i=0;i<Objs.Length;i++)
		{
			iTween.ScaleTo (Objs[i].gameObject, iTween.Hash ("x", 0,"y", 0, "time", 0.25, "islocal", true, "delay", 0, "easetype", iTween.EaseType.easeOutSine));
		}
//		MenuManager.myScript.GameState = MenuManager.MenuState.Menu;
	}
}
