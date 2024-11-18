using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class MenuManager : MonoBehaviour 
{
	public static MenuManager myScript;
	public Text Text_Coins,Text_GPlus;





	public GameObject MenuPage;
	public GameObject LevelsPage;



	public Text[] AllCoinsTxet;

	public enum MenuState
	{
		Menu,Options,Store,
		Phase1,Phase2,Phase3,
		Flights,Exit,DailyBonus,Packs,
		StorePopUp
	};

	public static bool Is_CameFromLC;

	public MenuState GameState;

	void Awake()
	{
		myScript=this;
	}

	void Start () 
	{


		//print ( SystemInfo.systemMemorySize+"------- SystemInfo.graphicsMemorySize ::" + SystemInfo.graphicsMemorySize);
		//Btm_Utils2018.jarToast((SystemInfo.systemMemorySize+" : size : "+SystemInfo.graphicsMemorySize), true);

		if (SystemInfo.systemMemorySize > 2500) {
			QualitySettings.SetQualityLevel (2, true);
		}
		else if (SystemInfo.systemMemorySize > 1900) {
			QualitySettings.SetQualityLevel (1, true);
		} else {
			QualitySettings.SetQualityLevel (0, true);

		}



		Screen.sleepTimeout = SleepTimeout.NeverSleep;

		if(PlayerPrefs.HasKey(MyGamePrefs.Unlocked_Levels)==false)
		{
			PlayerPrefs.SetInt(MyGamePrefs.Unlocked_Levels,1);

			PlayerPrefs.SetInt(MyGamePrefs.Unlocked_Levels_inCountry[0],1);
			PlayerPrefs.SetInt(MyGamePrefs.Unlocked_Levels_inCountry[1],1);
			PlayerPrefs.SetInt(MyGamePrefs.Unlocked_Levels_inCountry[2],1);
			PlayerPrefs.SetInt(MyGamePrefs.Unlocked_Levels_inCountry[3],1);
			PlayerPrefs.SetInt(MyGamePrefs.Unlocked_Levels_inCountry[4],1);
			PlayerPrefs.SetInt(MyGamePrefs.Unlocked_Levels_inCountry[5],1);



		}


		#if UNITY_EDITOR

//		PlayerPrefs.SetInt (MyGamePrefs.CountryData[0],1);
//		PlayerPrefs.SetInt (MyGamePrefs.CountryData[1],1);
//		PlayerPrefs.SetInt (MyGamePrefs.CountryData[2],1);
//
//		PlayerPrefs.SetInt(MyGamePrefs.Unlocked_Levels_inCountry[0],9);
//		PlayerPrefs.SetInt(MyGamePrefs.Unlocked_Levels_inCountry[1],9);
//		PlayerPrefs.SetInt(MyGamePrefs.Unlocked_Levels_inCountry[2],9);


		//PlayerPrefs.SetInt (MyGamePrefs.CountryData[0],1);
		//PlayerPrefs.SetInt(MyGamePrefs.Unlocked_Levels_inCountry[0],9);
		//PlayerPrefs.SetInt (MyGamePrefs.Selected_Level,9);
		//arj
		//SelectCountryManager.CountryIndex=0;
		//PlayerPrefs.SetInt (MyGamePrefs.Selected_Level,2);
	//	PlayerPrefs.SetInt ("Training", 5);
		#endif




//		for(int j=0;j<MyGamePrefs.ActiveWorlds;j++){
//
//			PlayerPrefs.SetInt (MyGamePrefs.CountryData[j],1);
//			PlayerPrefs.SetInt(MyGamePrefs.Unlocked_Levels_inCountry[j],9);
//
//		}






		Set_PrefsHash ();

		if(PlayerPrefs.HasKey("Sounds") == false)
		{
			PlayerPrefs.SetString("Sounds","true");
		}


//		if(Is_CameFromLC)
//		{
//			Debug.Log (Phase_Tween.ComingFromPlayArea+ "This is "+PlayerPrefs.GetInt (MyGamePrefs.Unlocked_Levels_inCountry [StartCountryManger.StoredIndex]));
//			if (PlayerPrefs.GetInt (MyGamePrefs.Unlocked_Levels_inCountry [StartCountryManger.StoredIndex]) <= 9) {//PlayerPrefs.GetInt(MyGamePrefs.Unlocked_Levels)<=10)
//				Phase_Tween.myScript.Phase_In (1);
//				Debug.Log ("This is");
//			} else {
//				//open country selection
//				Debug.Log ("This is country ");
//
//				Phase_Tween.ComingFromPlayArea=false;
//				Is_CameFromLC=false;
//				Menu_Tween.myScript.Menu_In();
//			}
//
//			Is_CameFromLC=false;
//
//			if(SoundsManager.myScript!=null)
//			{
//				SoundsManager.myScript.Sound_Menu.GetComponent<AudioSource>().Play();
//				SoundsManager.myScript.Sound_Menu.GetComponent<AudioSource>().loop=true;
//			}
//		}


		if(ComingForUpgrade){
			OpenUpgrade ();
		}
		else
		{
			Menu_Tween.myScript.Menu_In();
			Is_CameFromLC=false;
			if(SoundsManager.myScript!=null)
			{
				SoundsManager.myScript.Sound_Menu.GetComponent<AudioSource>().Play();
				SoundsManager.myScript.Sound_Menu.GetComponent<AudioSource>().loop=true;
			}

		//arjj	GameConfigs2018.mee.showRotationAds (PlayerPrefs.GetInt (MyGamePrefs.Selected_Level),AdsPageType.menu);
		}

		//if(AdsManager.myScript!=null)
		//{
			//AdsManager.myScript.MenuAd(PlayerPrefs.GetInt(MyGamePrefs.Selected_Level));
			//AdsManager.ShowGPlusBtn ();
			//Invoke("FirstTimeAuthentication",3);
			//Invoke("CheckSignInDelay",5);
		//}

		SetCoinsToAllText ();
		Debug.Log ("ComingForUpgrade "+ComingForUpgrade);



	}

	public GameObject _PrevPage;

	public void OpenStore(GameObject PrevPage){

		_PrevPage = PrevPage;
		_PrevPage.SetActive (false);
		Store_Tween.myScript.Store_In ();
	}

	public void SetCoinsToAllText(){
		for(int i=0;i<4;i++){

			AllCoinsTxet [i].text = "" + PlayerPrefs.GetInt (MyGamePrefs.Total_Coins);

		}
	}

	void FirstTimeAuthentication()
	{
	//	AdsManager.myScript.GP_Authentication ();
	}
	
	void CheckSignInDelay()
	{
//		if(GameConfigs2015.CSignIn)
//		{
//			Text_GPlus.text="Sign Out";
//		}
//		else
//		{
//			Text_GPlus.text="Sign In";
//		}
//		Invoke("CheckSignInText",4);
	}
	
	public void CheckSignInText()
	{
//		if(PlayGameServices.isSignedIn ())
//		{
//			Debug.Log ("SIGNED IN");
//			Text_GPlus.text="Sign Out";
//		}
//		else
//		{
//			Debug.Log ("SIGNED OUT");
//			Text_GPlus.text="Sign In";
//		}
	}
	
	void Update () 
	{
		//arj Text_Coins.text = "" + PlayerPrefs.GetInt (MyGamePrefs.Total_Coins);

		if(Input.GetKeyDown(KeyCode.Escape))
		{
//			if(GameState==MenuState.Menu)
//			{
//				ExitPage_Tween.myScript.Exit_In();
//			}
//			else
//			if(GameState==MenuState.Exit)
//			{
//				ExitPage_Tween.myScript.Exit_Out();
//			}
//			else
//				if(GameState==MenuState.Phase1 ||
//				   GameState==MenuState.Phase2 ||
//				   GameState==MenuState.Phase3)
//			{
//				Menu_Tween.myScript.Menu_In();
//				Phase_Tween.myScript.Phase_Out();
//			}
//			else
//				if(GameState==MenuState.Options)
//			{
//				Menu_Tween.myScript.Menu_In();
//				Opt_Tween.myScript.Opt_Out();
//			}
//			else
//				if(GameState==MenuState.Packs)
//			{
//				Packs_Tween.myScript.Packs_Out();
//			}
//			else
//				if(GameState==MenuState.Store)
//			{
//				Menu_Tween.myScript.Menu_In();
//				Store_Tween.myScript.Store_Out();
//			}
//			else
//				if(GameState==MenuState.Flights)
//			{
//				Upgrade_Tween.myScript.Upgrade_Out();
//				Phase_Tween.myScript.Phase_In(0);
//			}
		}
	}

	void Set_PrefsHash()
	{
		if(PlayerPrefs.HasKey(MyGamePrefs.Selected_Controls)==false)
		{PlayerPrefs.SetInt(MyGamePrefs.Selected_Controls,1);}
		
		if(PlayerPrefs.HasKey(MyGamePrefs.Selected_Level)==false)
		{PlayerPrefs.SetInt(MyGamePrefs.Selected_Level,1);}

		if(PlayerPrefs.HasKey(MyGamePrefs.Selected_Theme)==false)
		{PlayerPrefs.SetInt(MyGamePrefs.Selected_Theme,1);}
		
		if(PlayerPrefs.HasKey(MyGamePrefs.Selected_Flight)==false)
		{PlayerPrefs.SetInt(MyGamePrefs.Selected_Flight,1);}

		if(PlayerPrefs.HasKey(MyGamePrefs.Total_Coins)==false)
		{PlayerPrefs.SetInt(MyGamePrefs.Total_Coins,0);}

		if(PlayerPrefs.HasKey(MyGamePrefs.Total_Starts)==false)
		{PlayerPrefs.SetInt(MyGamePrefs.Total_Starts,1);}

	}

	public void CheckPackPage()
	{
	
	}

	public static bool ComingForUpgrade = false;

	public void OpenUpgrade(){
		ComingForUpgrade = false;
		Menu_Tween.myScript.Menu_Out ();
		Upgrade_Tween.myScript.Upgrade_In ();
	}

	public void Load_Theme1Lvl(int LvlCount)
	{
		
		
		PlayerPrefs.SetInt (MyGamePrefs.Selected_Level, LvlCount);
		PlayerPrefs.SetInt (MyGamePrefs.Selected_Theme, 1);
		LoadingManager.SceneName = "GameplayEurope";
	//	Upgrade_Tween.myScript.Upgrade_In ();

			
			Application.LoadLevel ("Loading");


	}
	public void Load_Theme2Lvl(int LvlCount)
	{
		PlayerPrefs.SetInt (MyGamePrefs.Selected_Level,LvlCount);
		PlayerPrefs.SetInt (MyGamePrefs.Selected_Theme, 2);
		LoadingManager.SceneName = "GameplayEurope";
		Upgrade_Tween.myScript.Upgrade_In ();
		
	}
	public void Load_Theme3Lvl(int LvlCount)
	{
		PlayerPrefs.SetInt (MyGamePrefs.Selected_Level, LvlCount);
			PlayerPrefs.SetInt (MyGamePrefs.Selected_Theme, 3);
		LoadingManager.SceneName = "GameplayEurope";
		Upgrade_Tween.myScript.Upgrade_In ();
	}


	public void CheckClick(){
		Debug.Log ("LAonce");
		PlayerPrefs.SetInt (MyGamePrefs.Selected_Flight, Upgrade_Tween.myScript.PlaneCount);
		Upgrade_Tween.myScript.Upgrade_Out ();

		Phase_Tween.myScript.showCountries ();

		Debug.Log ("LAonce : "+PlayerPrefs.GetInt (MyGamePrefs.Selected_Flight));
		//LoadGame ();
	}
	public void LoadGame()
	{

		Debug.Log ("Lonce");
		PlayerPrefs.SetInt (MyGamePrefs.Selected_Flight, Upgrade_Tween.myScript.PlaneCount);

		Upgrade_Tween.myScript.Upgrade_Out ();


		Phase_Tween.myScript.OpenLevels ();

		//Phase_Tween.myScript.Phase_In (1);



		//	PlayerPrefs.SetInt (MyGamePrefs.Selected_Flight, Upgrade_Tween.myScript.PlaneCount);
		//	Application.LoadLevel ("Loading");

	}
}
