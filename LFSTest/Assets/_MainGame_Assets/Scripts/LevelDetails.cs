using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelDetails : MonoBehaviour 
{
	public static LevelDetails myScript;

	public int No_Theme;
	public int No_Level;
	public GameObject Text_LName;
	public GameObject Lock;
	public GameObject[] Stars;

	public Text Distination_txt;
	
	void Awake()
	{
		myScript=this;

//		PlayerPrefs.SetInt(MyGamePrefs.Unlocked_Levels,1);
	}

	void OnEnable(){
		//Debug.Log ("Onenable");
		CheckLockTheme1 ();
	}
	void Start () 
	{
//		if (No_Theme==1) 
//		{
//			CheckLockTheme1 ();
//		}

	}
	
	void Update () 
	{
	
	}
	
	public void CheckLockTheme1()
	{


		//print(StartCountryManger.StoredIndex+" : "+No_Level+" --No : "+PlayerPrefs.GetInt(MyGamePrefs.Unlocked_Levels_inCountry[StartCountryManger.StoredIndex]));

		//if(PlayerPrefs.GetInt(MyGamePrefs.Unlocked_Levels)>=No_Level)

		//if(PlayerPrefs.GetInt(SelectCountryManager.LevelsIncountry+"A",1)>=No_Level)

		//for(int i=0;i<9;i++){
			
		if (No_Level <= PlayerPrefs.GetInt (MyGamePrefs.Unlocked_Levels_inCountry [StartCountryManger.StoredIndex])) {
				Lock.gameObject.SetActive (false);
			Text_LName.gameObject.GetComponent<Text>().text="Level "+No_Level;
			Text_LName.gameObject.transform.parent.GetComponent<Button>().enabled=true;

		//	Debug.Log (No_Level+" Hash key"+PlayerPrefs.HasKey("ad1r" + (No_Level + 1)));

			Phase_Tween.myScript.firlstLevelUnlockerWithVideo.gameObject.SetActive(false);

			/*
			if (PlayerPrefs.HasKey("ad1r" + (No_Level)))
			{
				//already watched video and opened once..
				Phase_Tween.myScript.firlstLevelUnlockerWithVideo.gameObject.SetActive(false);
			}
			else
			{
				//as of now this is for first level only....but if we active from playfab it will work for all levels.
				if (No_Level == 0 || GameConfigs2018.allVideo == true)
				{
					Phase_Tween.myScript.firlstLevelUnlockerWithVideo.gameObject.SetActive(true);
					Phase_Tween.myScript.firlstLevelUnlockerWithVideo.gameObject.transform.SetParent(this.transform, false);
				}
			}
			*/


			} else {

				Lock.gameObject.SetActive(true);
				Text_LName.gameObject.GetComponent<Text>().text="Locked";
				Text_LName.gameObject.GetComponent<Text>().color=Color.white;
			//	Text_LName.gameObject.transform.parent.GetComponent<Button>().enabled=false;
			}

		Distination_txt.text=""+Phase_Tween.myScript.DNames[StartCountryManger.StoredIndex].m_DistinationPlaces[No_Level-1];

		//}





	}



	private int counterForAdCheck = 0;
	public void Selectnow(LevelDetails mobj)
	{
		int Levelnumber=mobj.No_Level;
		if (mobj.Text_LName.gameObject.GetComponent<Text> ().text == "Locked") {

			Debug.Log ("Inlock");
		//	AdManager.instance.BuyItem (2, true);
			//arjj Btm_IABManager.mee.BUY (2);
		} else {
			Debug.Log("Video Not require..!");
			//Upgradeopen();
			Phase_Tween.myScript.Phase_Out();
			MenuManager.myScript.Load_Theme1Lvl(Levelnumber);

		}

		/*
		 else if ((!PlayerPrefs.HasKey("ad1r" + Levelnumber) && GameConfigs2018.allVideo == true) || (Levelnumber == 1 && !PlayerPrefs.HasKey("ad1r" + 1)))
		{
			if (GameConfigs2018.mee)
			{
				GameConfigs2018.mee.showURewardedVideoHere((result) =>
					{
						if (result == true)
						{
							Debug.Log("watched Video reward give first Level");
							//gameObject.SetActive(false);

							PlayerPrefs.SetInt("ad1r" + Levelnumber, 1);
							Phase_Tween.myScript.firlstLevelUnlockerWithVideo.gameObject.SetActive(false);

							Phase_Tween.myScript.Phase_Out();
							MenuManager.myScript.Load_Theme1Lvl(Levelnumber);
							//Upgradeopen();

						}
						else
						{
							//gameObject.SetActive(true);
						//	Btm_Utils2018.jarToast("Not rewarded...!");
							//new GoogleMobileAds.Api.Reward();
						}

					});
			}
			counterForAdCheck++;

			if (counterForAdCheck > 1)
			{
				PlayerPrefs.SetInt("ad1r" + Levelnumber, 1);
				Phase_Tween.myScript.firlstLevelUnlockerWithVideo.gameObject.SetActive(false);
			}
		}
		else
		{
			Debug.Log("Video Not require..!");
			//Upgradeopen();
			Phase_Tween.myScript.Phase_Out();
			MenuManager.myScript.Load_Theme1Lvl(Levelnumber);
		}

		*/
		Debug.Log("Level select is : " + Levelnumber);
	}



	void CheckStars()
	{

	}
}
