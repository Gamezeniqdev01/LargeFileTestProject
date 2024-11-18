using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Upgrade_Tween : MonoBehaviour 
{
	public static Upgrade_Tween myScript;

	public GameObject Btn_Back;
	public GameObject Btn_BackA,Btn_NextA,Btn_VidReward;
	public GameObject[] Planes,PlaneDetails;


	public GameObject UpgradePage;

	public static int UpgradePageCount;
	
	void Awake()
	{
		myScript=this;
	}

	void Start () 
	{
	
	}
	
	void Update () 
	{
	//	Menu_Tween.myScript.UpgradeCam.transform.LookAt (Planes[PlaneCount].transform);
	}

	public GameObject UnlockPop;
	public static int UpCount=0;


	private string myinappID = "";
	private string myinapp2ID = "";
	void OpenPop(){

//		myinappID = GameConfigs2018.mee.inappIds_All[1];
//		myinapp2ID = GameConfigs2018.mee.inappIds_All[3];
//
//		Debug.Log(PlayerPrefs.HasKey (myinappID + "onetime")+" :: "+PlayerPrefs.HasKey(myinappID + "given"));
//
//
//		if (PlayerPrefs.HasKey (myinappID + "onetime") && PlayerPrefs.HasKey (myinappID + "given")) {
//
//
//		} 
//		else if (PlayerPrefs.HasKey (myinapp2ID + "onetime") && PlayerPrefs.HasKey (myinapp2ID + "given")) {
//
//
//		} 
//		else {
//			Debug.Log(" :: ");
//
//			if(LevelManager.mCount==5 || LevelManager.mCount==2){
//				LevelManager.mCount = 1;
//				Btm_IABManager.mee.BUY(1);
//
//			}
//			else if (UpCount % 3 == 0 && UpCount > 1) {
//				UnlockPop.SetActive (true);
//			}
//
//
//		
//		}




	}

	public int PlaneCount=1;
	public void Upgrade_In()
	{


		Debug.Log (PlayerPrefs.GetInt ("Training"));


		if (PlayerPrefs.GetInt ("Training") <= 2) {
			LoadingManager.SceneName = "GameplayEurope";
			Application.LoadLevel ("Loading");


		}  else {


			Debug.Log ("---ank");

					if (PlayerPrefs.GetInt ("Training") == 3) {
						Phase_Tween.myScript.TrainingPop [0].SetActive (true);
						Phase_Tween.myScript.TrainingPop [1].SetActive (true);
					}


			//Menu_Tween.myScript.Envi3D.SetActive (false);
			//	Menu_Tween.myScript.Mcam.enabled = true;
			Menu_Tween.myScript.cam3D.enabled = false;
			Menu_Tween.myScript.UpgradeCam.enabled = true;
			UpCount++;
			UpgradePage.SetActive (true);
			UpgradePageCount++;
			OpenPop ();
			if(UpgradePageCount==5)
			{
				//	NativePopUp.myScript.UnLockAllFlights();
			}
			if(SoundsManager.myScript!=null)
			{
				SoundsManager.myScript.Sound_Button.GetComponent<AudioSource>().Play();
			}
			MenuManager.myScript.GameState = MenuManager.MenuState.Flights;
			//PlaneCount = 1;



			if(PlaneCount==1){
				Btn_BackA.GetComponent<Image> ().color = new Color (1, 1, 1, 0.2f);
				Btn_NextA.GetComponent<Image> ().color = new Color (1, 1, 1, 1f);
			}


		}


		//AdManager.instance.RunActions (AdManager.PageType.Upgrade,PlayerPrefs.GetInt (MyGamePrefs.Selected_Level));


		//		else if (PlayerPrefs.GetInt ("Training") == 3) {
		//			Phase_Tween.myScript.TrainingPop [0].SetActive (true);
		//			Phase_Tween.myScript.TrainingPop [1].SetActive (true);
		//		}



	}

	public void Upgrade_Out()
	{

		Menu_Tween.myScript.Envi3D.SetActive (true);
		Menu_Tween.myScript.Mcam.enabled = false;
		Menu_Tween.myScript.cam3D.enabled = true;
		Menu_Tween.myScript.UpgradeCam.enabled = false;


		UpgradePage.SetActive (false);

		//PlaneCount = 1;
		/*
		iTween.MoveTo (Btn_VidReward.gameObject, iTween.Hash ("x", 1500, "time", 0.5, "islocal", true, "delay", 0, "easetype", iTween.EaseType.easeOutSine));
		iTween.MoveTo (Btn_Back.gameObject, iTween.Hash ("x", -1500, "time", 0.5, "islocal", true, "delay", 0, "easetype", iTween.EaseType.easeOutSine));			
		iTween.MoveTo (Btn_BackA.gameObject, iTween.Hash ("x", -1500, "time", 0.5, "islocal", true, "delay", 0, "easetype", iTween.EaseType.easeOutSine));	
		iTween.MoveTo (Btn_NextA.gameObject, iTween.Hash ("x", 1500, "time", 0.5, "islocal", true, "delay", 0, "easetype", iTween.EaseType.easeOutSine));	
		
		iTween.MoveTo (Planes[0].gameObject, iTween.Hash ("x", 100, "time", 0.5, "islocal", true, "delay", 0, "easetype", iTween.EaseType.easeOutSine));	
		iTween.MoveTo (PlaneDetails[0].gameObject, iTween.Hash ("x", 1500, "time", 0.5, "islocal", true, "delay", 0, "easetype", iTween.EaseType.easeOutSine));

		for(int i=0;i<5;i++)
		{
			iTween.MoveTo (Planes[i].gameObject, iTween.Hash ("x", 1500, "time", 0.2, "islocal", true, "delay", 0, "easetype", iTween.EaseType.easeOutSine));	
			iTween.MoveTo (PlaneDetails[i].gameObject, iTween.Hash ("x", 1500, "time", 0.2, "islocal", true, "delay", 0, "easetype", iTween.EaseType.easeOutSine));
		}
		*/
	//	Btn_BackA.GetComponent<Image> ().color = new Color (1, 1, 1, 0.2f);
	//	Btn_NextA.GetComponent<Image> ().color = new Color (1, 1, 1, 1f);
	}

	public void MoveNext()
	{
		if (PlaneCount < 15) 
		{
			PlaneCount++;
			for(int i=0;i<15;i++)
			{
				if(PlaneCount-1==i)
				{
					Debug.Log (Planes[i]+" :: "+Planes[i].transform.GetChild(0).gameObject);

					iTween.MoveTo (UpgradeControl.myScript.CameraUpgrade.gameObject, iTween.Hash ("position", Planes[i].transform.GetChild(0).gameObject.transform.position, "time", 0.5, "islocal", false, "delay", 0, "easetype", iTween.EaseType.easeOutSine));
					Menu_Tween.myScript.UpgradeCam.transform.rotation = Planes [i].transform.GetChild (0).gameObject.transform.rotation;

					//iTween.ScaleTo (Planes[i].gameObject, iTween.Hash ("x", 1,"y",1,"z",1, "time", 0.5, "islocal", true, "delay", 0, "easetype", iTween.EaseType.easeOutSine));	
					iTween.MoveTo (PlaneDetails[i].gameObject, iTween.Hash ("x", -467, "time", 0.5, "islocal", true, "delay", 0, "easetype", iTween.EaseType.easeOutSine));
					if(SoundsManager.myScript!=null)
					{
						SoundsManager.myScript.Sound_Button.GetComponent<AudioSource>().Play();
					}
				}
				else
				{
//					iTween.MoveTo (Planes[i].gameObject, iTween.Hash ("x", -1500, "time", 0.5, "islocal", true, "delay", 0, "easetype", iTween.EaseType.easeOutSine));	
//					iTween.MoveTo (PlaneDetails[i].gameObject, iTween.Hash ("x", -1500, "time", 0.5, "islocal", true, "delay", 0, "easetype", iTween.EaseType.easeOutSine));
				}
			}

		//iTween.ScaleTo (Planes[PlaneCount-2].gameObject, iTween.Hash ("x", 0,"y",0,"z",0, "time", 0.5, "islocal", true, "delay", 0, "easetype", iTween.EaseType.easeOutSine));	

 		iTween.MoveTo (PlaneDetails[PlaneCount-2].gameObject, iTween.Hash ("x", -1700, "time", 0.5, "islocal", true, "delay", 0, "easetype", iTween.EaseType.easeOutSine));

			if(PlaneCount==2)
			{
				Debug.Log("---- Add Video");
//				Btn_
			}


			if(PlaneCount==15)
			{Btn_NextA.GetComponent<Image>().color=new Color(1,1,1,0.2f);}
			else
			{Btn_NextA.GetComponent<Image>().color=new Color(1,1,1,1f);}
			if(PlaneCount==1)
			{Btn_BackA.GetComponent<Image>().color=new Color(1,1,1,0.2f);}
			else
			{Btn_BackA.GetComponent<Image>().color=new Color(1,1,1,1f);}
		}
	}
	
	
	public void MoveBack()
	{
		if (PlaneCount > 1) 
		{
			PlaneCount--;
			for(int i=0;i<15;i++)
			{
				if(PlaneCount-1==i)
				{
					//iTween.MoveTo (Planes[i].gameObject, iTween.Hash ("x", 0, "time", 0.5, "islocal", true, "delay", 0, "easetype", iTween.EaseType.easeOutSine));	
					iTween.MoveTo (PlaneDetails[i].gameObject, iTween.Hash ("x", -467, "time", 0.5, "islocal", true, "delay", 0, "easetype", iTween.EaseType.easeOutSine));

					iTween.MoveTo (UpgradeControl.myScript.CameraUpgrade.gameObject, iTween.Hash ("position", Planes[i].transform.GetChild(0).gameObject.transform.position, "time", 0.5, "islocal", false, "delay", 0, "easetype", iTween.EaseType.easeOutSine));
					Menu_Tween.myScript.UpgradeCam.transform.rotation = Planes [i].transform.GetChild (0).gameObject.transform.rotation;

				}
				else
				{
//					iTween.MoveTo (Planes[i].gameObject, iTween.Hash ("x", 1500, "time", 0.5, "islocal", true, "delay", 0, "easetype", iTween.EaseType.easeOutSine));	
//					iTween.MoveTo (PlaneDetails[i].gameObject, iTween.Hash ("x", 1500, "time", 0.5, "islocal", true, "delay", 0, "easetype", iTween.EaseType.easeOutSine));
				}
			}

			//iTween.MoveTo (Planes[PlaneCount].gameObject, iTween.Hash ("x", 1500, "time", 0.5, "islocal", true, "delay", 0, "easetype", iTween.EaseType.easeOutSine));	
			iTween.MoveTo (PlaneDetails[PlaneCount].gameObject, iTween.Hash ("x", 1700, "time", 0.5, "islocal", true, "delay", 0, "easetype", iTween.EaseType.easeOutSine));

			if(PlaneCount==1)
			{Btn_BackA.GetComponent<Image>().color=new Color(1,1,1,0.2f);}
			else
			{Btn_BackA.GetComponent<Image>().color=new Color(1,1,1,1f);}
			if(PlaneCount==15)
			{Btn_NextA.GetComponent<Image>().color=new Color(1,1,1,0.2f);}
			else
			{Btn_NextA.GetComponent<Image>().color=new Color(1,1,1,1f);}
		}
	}

}
