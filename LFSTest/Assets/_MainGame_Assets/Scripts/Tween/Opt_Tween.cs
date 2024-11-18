using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Opt_Tween : MonoBehaviour 
{
	public static Opt_Tween myScript;

	public GameObject SettingPage;
	public GameObject HelpPage;



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

	public void Opt_In()
	{
		MenuManager.myScript.GameState = MenuManager.MenuState.Options;
	
		if(SoundsManager.myScript!=null)
		{
			SoundsManager.myScript.Sound_Button.GetComponent<AudioSource>().Play();
		}

	
		SettingPage.SetActive (true);


	
	}


	
	public void Opt_Out()
	{

		SettingPage.SetActive (false);

	

	
	}
}
