using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Menu_Tween : MonoBehaviour 
{
	public static Menu_Tween myScript;

	public GameObject Ttl_Flight;
	public Camera Mcam,cam3D,UpgradeCam;

	public GameObject Bg,Envi3D;

	public GameObject Btn_Lb,Btn_Ach,Btn_SignIn,Btn_Plus;

	public GameObject Btn_Share,Btn_Bonus;

	public GameObject Btn_Fly,Btn_Opt,Btn_Store,Btn_Mg,Btn_Free;

	public GameObject Coins;


	
	void Awake()
	{
		myScript=this;
		UpgradeCam.enabled = false;
	}

	void Start () 
	{
//		Menu_In ();
	}
	
	void Update () 
	{
	
	}

	public static bool ComingFromStart=true;
	public void Menu_In()
	{
		Debug.Log ("In");
		if(PlayerPrefs.HasKey("Training")==false){
			PlayerPrefs.SetInt ("Training", 1);

			for (int i = 0; i < 3; i++) {

				PlayerPrefs.SetInt (MyGamePrefs.CountryData [i], 0);
			}

		}

		PlayerPrefs.SetInt (MyGamePrefs.CountryData[0],1);

	//	PlayerPrefs.SetInt ("Training", 3);
		//PlayerPrefs.SetInt (MyGamePrefs.Unlocked_Levels, 3);

		MenuManager.myScript.GameState = MenuManager.MenuState.Menu;


	
		if(SoundsManager.myScript!=null)
		{
			SoundsManager.myScript.Sound_Button.GetComponent<AudioSource>().Play();
		}




		//iTween.MoveFrom (Ttl_Flight.gameObject, iTween.Hash ("x", -100, "time", 0.5, "islocal", true, "delay", 0, "easetype", iTween.EaseType.easeOutSine));
		if (ComingFromStart) {
			ComingFromStart = false;
			Invoke ("AfterDelay", 4.8f);
		} else {
			AfterDelay ();
		}


	//	AdManager.instance.RunActions (AdManager.PageType.Menu);
	}

	void AfterDelay(){
		Bg.SetActive (true);
		iTween.MoveTo (Ttl_Flight.gameObject, iTween.Hash ("x", 29, "time", 0.5, "islocal", true, "delay", 0, "easetype", iTween.EaseType.easeOutSine));

		iTween.MoveTo (Btn_Lb.gameObject, iTween.Hash ("x", -468, "time", 0.5, "islocal", true, "delay", 1.25, "easetype", iTween.EaseType.easeOutSine));
		iTween.MoveTo (Btn_Ach.gameObject, iTween.Hash ("x", -378, "time", 0.5, "islocal", true, "delay", 1.25, "easetype", iTween.EaseType.easeOutSine));

		iTween.MoveTo (Btn_Share.gameObject, iTween.Hash ("x",-250, "time", 0.5, "islocal", true, "delay", 1.5, "easetype", iTween.EaseType.easeOutSine));


		iTween.MoveTo (Btn_Fly.gameObject, iTween.Hash ("x",32, "time", 0.5, "islocal", true, "delay", 1.25, "easetype", iTween.EaseType.easeOutSine));
		iTween.MoveTo (Btn_Opt.gameObject, iTween.Hash ("x",468, "time", 0.5, "islocal", true, "delay", 1.3, "easetype", iTween.EaseType.easeOutSine));
		//iTween.MoveTo (Btn_Free.gameObject, iTween.Hash ("x",468, "time", 0.5, "islocal", true, "delay", 1.3, "easetype", iTween.EaseType.easeOutSine));
		iTween.MoveTo (Btn_Store.gameObject, iTween.Hash ("x",378, "time", 0.5, "islocal", true, "delay", 1.35, "easetype", iTween.EaseType.easeOutSine));
		iTween.MoveTo (Btn_Mg.gameObject, iTween.Hash ("x",-359, "time", 0.5, "islocal", true, "delay", 1.4, "easetype", iTween.EaseType.easeOutSine));
	}
	public void Menu_Out()
	{


		Bg.SetActive (false);


	//	MenuManager.myScript.MenuPage.SetActive (false);


		iTween.MoveTo (Ttl_Flight.gameObject, iTween.Hash ("x", -1500, "time", 0.5, "islocal", true, "delay", 0, "easetype", iTween.EaseType.easeOutSine));
	
	

		iTween.MoveTo (Btn_Lb.gameObject, iTween.Hash ("x", -1500, "time", 0.5, "islocal", true, "delay",0, "easetype", iTween.EaseType.easeOutSine));
		iTween.MoveTo (Btn_Ach.gameObject, iTween.Hash ("x",-1500, "time", 0.5, "islocal", true, "delay", 0, "easetype", iTween.EaseType.easeOutSine));
		iTween.MoveTo (Btn_SignIn.gameObject, iTween.Hash ("x", -1500, "time", 0.5, "islocal", true, "delay", 0, "easetype", iTween.EaseType.easeOutSine));
		iTween.MoveTo (Btn_Share.gameObject, iTween.Hash ("x",-1500, "time", 0.5, "islocal", true, "delay", 0, "easetype", iTween.EaseType.easeOutSine));
		iTween.MoveTo (Btn_Bonus.gameObject, iTween.Hash ("x",-1500, "time", 0.5, "islocal", true, "delay", 0, "easetype", iTween.EaseType.easeOutSine));
		
		iTween.MoveTo (Btn_Fly.gameObject, iTween.Hash ("x",1500, "time", 0.5, "islocal", true, "delay", 0, "easetype", iTween.EaseType.easeOutSine));
		iTween.MoveTo (Btn_Opt.gameObject, iTween.Hash ("x",1500, "time", 0.5, "islocal", true, "delay", 0, "easetype", iTween.EaseType.easeOutSine));
	//	iTween.MoveTo (Btn_Free.gameObject, iTween.Hash ("x",1500, "time", 0.5, "islocal", true, "delay", 0, "easetype", iTween.EaseType.easeOutSine));
		iTween.MoveTo (Btn_Store.gameObject, iTween.Hash ("x",1500, "time", 0.5, "islocal", true, "delay", 0, "easetype", iTween.EaseType.easeOutSine));
		iTween.MoveTo (Btn_Mg.gameObject, iTween.Hash ("x",1500, "time", 0.5, "islocal", true, "delay", 0, "easetype", iTween.EaseType.easeOutSine));
	}

	public void Show_ach(){
		//AdManager.instance.ShowAchievements ();
	}

	public void Show_Lead(){
		//AdManager.instance.ShowLeaderBoards ();

	}

	public void watch_Earn(){
		//AdManager.instance.ShowRewardVideo (1000,AdManager.RewardType.Coins);

	}
}
