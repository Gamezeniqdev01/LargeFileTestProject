using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour 
{
	public static GameManager myScript;
	public Text TextA_Speed,Text_Speed,Text_Altitude,Text_Collectable;

	public GameObject mg_LifeObj;
	public GameObject mg_HealthObj;

	public enum GameControls
	{
		Tilt,
		Rudder,
		RuddernNFlaps
	};
	public GameControls MyGameControls;
	public int Selected_Controls;

	public enum GameState 
	{
		AtInGame,AtPause,AtLevelC,AtLevelF
	}
	public GameState MyGameState;

	void Awake()
	{
		myScript=this;
	}


	void Start () 
	{
		Selected_Controls = PlayerPrefs.GetInt (MyGamePrefs.Selected_Controls);
		Selected_Controls = 1;
		CheckControls ();

//		if(AdsManager.myScript!=null)
//		{
//			AdsManager.myScript.IngameAd (PlayerPrefs.GetInt(MyGamePrefs.Selected_Level));
//		}

		if(SoundsManager.myScript!=null)
		{
			SoundsManager.myScript.Sound_Menu.GetComponent<AudioSource>().Stop();
			SoundsManager.myScript.Sound_Idle.GetComponent<AudioSource>().Play();
		}

		if (Application.isPlaying) {
			Clouds.SetActive (true);
		}
	}

	public void CheckControls()
	{
		switch(Selected_Controls)
		{
		case 1:
			MyGameControls=GameControls.Tilt;
			break;

		case 2:
			MyGameControls=GameControls.Rudder;
			break;

		case 3:
			MyGameControls=GameControls.RuddernNFlaps;
			break;

		default :
			MyGameControls=GameControls.Tilt;
			break;
		}
	}
#region Life         
	public void Call_AddLife()  // Harish
	{
		LevelManager.Lfailed = true;
		//GameConfigs2018.mee.showRotationAds (PlayerPrefs.GetInt (MyGamePrefs.Selected_Level),AdsPageType.prelf);
		//arjj
		//AdManager.instance.RunActions (AdManager.PageType.PreLF,PlayerPrefs.GetInt (MyGamePrefs.Selected_Level));

		TimerScript.myScript.Is_Stop = true;
		mg_LifeObj.SetActive (true);
		LevelManager.MyPlayer.GetComponent<Rigidbody> ().isKinematic = true;


		//Time.timeScale = 0;
	}


	public void Call_CrashLife()  // Harish
	{

		LevelManager.Lfailed = true;
		Debug.Log ("Crash");
		//AdManager.instance.RunActions (AdManager.PageType.PreLF,PlayerPrefs.GetInt (MyGamePrefs.Selected_Level));

	//	GameConfigs2018.mee.showRotationAds (PlayerPrefs.GetInt (MyGamePrefs.Selected_Level),AdsPageType.prelf);
		//arjj
		TimerScript.myScript.Is_Stop = true;
		mg_HealthObj.SetActive (true);
		LevelManager.MyPlayer.GetComponent<Rigidbody> ().isKinematic = true;
		//Time.timeScale = 0;
		Invoke("Cancel_CrashVideoAd",5);
		iTween.ValueTo (this.gameObject, iTween.Hash ("from",1 , "to", 0, "time",5, "delay", 0, "easetype", iTween.EaseType.linear, "onupdate", "rundFun", "oncompletetarget", this.gameObject));

	}
	public Image myFUnImage;
	public void rundFun (float value)
	{
		myFUnImage.fillAmount = value;
	}


	public void On_BtnClick(string _str)
	{
		switch (_str) 
		{
		case "Close":
			Cancel_VideoAd();
			break;
		case "Closecarshlife":
			Cancel_CrashVideoAd();
			break;
		case "Continue":
			After_VideoSuccess();  // Comment this
			break;

		case "ContinueCrash":
			After_CrashVideoSuccess();  // Comment this
			break;
		}
	}

	public void WatchToContinue(){
		//CancelInvoke("Cancel_CrashVideoAd");
		//#if UNITY_EDITOR
		//After_CrashVideoSuccess();  // Comment this


	//	#elif
		//AdManager.instance.ShowRewardVideo (0,AdManager.RewardType.Resume);

        ///#endif

        //if (AdManager.instance)
        //{
        //    AdManager.instance.ShowRewardVideoWithCallback((result) => {
        //        if (result)
        //        {
        //            //GameManager.myScript.Cancel_CrashVideoAd();
        //            GameManager.myScript.After_CrashVideoSuccess();
        //        }
        //    });
        //}
        //else
        {
            //iTween.Stop(gameObject);
            //CancelInvoke("OpenGameOverPage");            
            //GameManager._instance.Invoke("Call_GamePlay", 0.2f);
            GameManager.myScript.Cancel_CrashVideoAd();
        }
    }


	public void WatchToContinueTime(){
		//After_VideoSuccess ();
		//AdManager.instance.ShowRewardVideo (0,AdManager.RewardType.ResumeTime);

        //if (AdManager.instance)
        //{
        //    AdManager.instance.ShowRewardVideoWithCallback((result) => {
        //        if (result)
        //        {
        //            GameManager.myScript.After_VideoSuccess();

        //        }
        //    });
        //}
        //else
        {
            //iTween.Stop(gameObject);
            //CancelInvoke("OpenGameOverPage");            
            //GameManager._instance.Invoke("Call_GamePlay", 0.2f);
            GameManager.myScript.Cancel_CrashVideoAd();
        }

    }
	public void Cancel_VideoAd()
	{
		Time.timeScale = 1;
		mg_LifeObj.SetActive(false);
		GameManager.myScript.MyGameState = GameManager.GameState.AtLevelF;
		PlayArea_Tween.myScript.PlayArea_Out();
		GroundCheck.myScript.OrbitCamY();
	}

	public void Cancel_CrashVideoAd()
	{
		Time.timeScale = 1;

       // CancelInvoke("Cancel_CrashVideoAd");
		mg_HealthObj.SetActive(false);
		GameManager.myScript.MyGameState = GameManager.GameState.AtLevelF;
		PlayArea_Tween.myScript.PlayArea_Out();
		GroundCheck.myScript.OrbitCamY();

		GroundCheck.myScript.Invoke("SetOrbitCam",1);
	}


	public void After_VideoSuccess()
	{
		Debug.Log ("Suucess");
        CancelInvoke("Cancel_CrashVideoAd");
        LevelManager.Lfailed = false;

		LevelManager.MyPlayer.GetComponent<Rigidbody> ().isKinematic = false;

		Time.timeScale = 1;
		mg_LifeObj.SetActive(false);
		TimerScript.myScript.TimerTimeInSec = 30f;
		TimerScript.myScript.Is_Stop = false;
	}


	public void After_CrashVideoSuccess()
	{
        CancelInvoke("Cancel_CrashVideoAd");
        LevelManager.Lfailed = false;
		LevelManager.MyPlayer.GetComponent<Rigidbody> ().isKinematic = false;

		Time.timeScale = 1;
		mg_HealthObj.SetActive(false);
		TimerScript.myScript.Is_Stop = false;
		GroundCheck.myScript.ContinuePlay ();

	}
	public GameObject Clouds;


	public void UpdateCollectText(){

		Debug.Log ("colectting "+LevelManager.myScript.CollectedRings);
		Text_Collectable.text=LevelManager.myScript.CollectedRings+"/"+LevelManager.TotalRings;

	}


	public Text[] AllCoinsTxet;
	public void UpDateCoinsText(){

		for(int i=0;i<4;i++){

			AllCoinsTxet [i].text = "" + PlayerPrefs.GetInt (MyGamePrefs.Total_Coins);

		}
	}
#endregion
	private int myspeed;
	public GameObject AirEffect;


	public GameObject StarEffect;
	public GameObject Refpoint;
	void LateUpdate () 
	{
		if(LevelManager.myScript.Is_LevelStarted)
		{
//			GetThrottleValue ();
			myspeed=(int)UnityStandardAssets.Vehicles.Aeroplane.AeroplaneController.myScript.ForwardSpeed;
			Text_Speed.text=""+myspeed;//"knot"
			Text_Altitude.text=""+(int)UnityStandardAssets.Vehicles.Aeroplane.AeroplaneController.myScript.Altitude+" ft";

			if (myspeed >= 250) {
				AirEffect.SetActive (true);
			} else {
				AirEffect.SetActive (false);

			}
			//TextA_Speed.text=" :: ";
			//if(HelpManager.myScript!=null)
			//{
			if ((int)UnityStandardAssets.Vehicles.Aeroplane.AeroplaneController.myScript.Altitude > 200) {
				HelpManager.myScript.OFF_Tilt ();
				QualitySettings.shadows = ShadowQuality.Disable;
				LevelManager.myScript.MainCamm.farClipPlane = 1000000;
			} else {
				QualitySettings.shadows = ShadowQuality.HardOnly;
				LevelManager.myScript.MainCamm.farClipPlane = 10000;
			}
			//}



		}



	}


	public void ShareNow(){
		//AdManager.instance.FacebookShare (0);
	}

	public void Call_Home()
	{
		if(SoundsManager.myScript!=null)
		{
			SoundsManager.myScript.Sound_Button.GetComponent<AudioSource>().Play();
		}
		MenuManager.ComingForUpgrade = true;

		LoadingManager.SceneName="Menu";
		Application.LoadLevel("Loading");

	}

	public void Call_HomeFromLC()
	{
		if(SoundsManager.myScript!=null)
		{
			SoundsManager.myScript.Sound_Button.GetComponent<AudioSource>().Play();
		}
		//MenuManager.Is_CameFromLC=true;
		MenuManager.ComingForUpgrade = true;


		LoadingManager.SceneName="Menu";
		Application.LoadLevel("Loading");
	}

	public void Call_Next()
	{
		if(SoundsManager.myScript!=null)
		{
			SoundsManager.myScript.Sound_Button.GetComponent<AudioSource>().Play();
		}
		MenuManager.ComingForUpgrade = true;

		LoadingManager.SceneName="Menu";
		Application.LoadLevel("Loading");
	}
	public void Call_Retry()
	{
		if(SoundsManager.myScript!=null)
		{
			SoundsManager.myScript.Sound_Button.GetComponent<AudioSource>().Play();
		}
		MenuManager.ComingForUpgrade = true;

		//LoadingManager.SceneName=Application.loadedLevelName;
		LoadingManager.SceneName="Menu";
		Application.LoadLevel("Loading");
	}
}
