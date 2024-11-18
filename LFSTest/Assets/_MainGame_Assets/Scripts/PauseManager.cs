using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour 
{
	public static PauseManager myScript;

	public GameObject PausePage;
	public GameObject PlayAreaPage;
	public GameObject SLiderPage;

	
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

	public void Pause_In()
	{


		Invoke ("makeTimeScale",1.5f);

		PausePage.gameObject.SetActive (true);
		//PlayAreaPage.gameObject.SetActive (false);
	//	SLiderPage.gameObject.SetActive (false);

		AudioListener.volume=0;


	}

	void makeTimeScale(){
		Time.timeScale = 0;
	}
	public void Pause_Out()
	{
		
		CancelInvoke ("makeTimeScale");

		Time.timeScale = 1;
		PausePage.gameObject.SetActive (false);

		if(PlayerPrefs.GetString("Sounds")=="false")
		{
			AudioListener.volume=0;
		}
		else
		{
			AudioListener.volume=1;
		}
	}

	public void Call_Home()
	{
		CancelInvoke ("makeTimeScale");

		Time.timeScale = 1;
		MenuManager.ComingForUpgrade = true;

		LoadingManager.SceneName="Menu";
		Application.LoadLevel("Loading");

		if(PlayerPrefs.GetString("Sounds","false")=="false")
		{
			AudioListener.volume=0;
		}
		else
		{
			AudioListener.volume=1;
		}

	}
	public void Call_Retry()
	{
		CancelInvoke ("makeTimeScale");
		Time.timeScale = 1;

		PausePage.gameObject.SetActive (false);
		LevelManager.myScript.Defeat_In ("Try Again");

		//LoadingManager.SceneName=Application.loadedLevelName;
		//Application.LoadLevel("Loading");


		if(PlayerPrefs.GetString("Sounds")=="false")
		{
			AudioListener.volume=0;
		}
		else
		{
			AudioListener.volume=1;
		}
	}

    public void Call_MoreGames()
    {
       // AdManager.instance.ShowMoreGames(); 
    }
   }
