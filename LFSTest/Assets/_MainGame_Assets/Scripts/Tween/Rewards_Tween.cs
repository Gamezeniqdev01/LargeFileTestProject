using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Rewards_Tween : MonoBehaviour 
{
	public static Rewards_Tween myScript;

	public GameObject Rewards_Page;

	public Text Text_Coins,Text_Stars;

	public int TotalLevelCoins;

	public GameObject[] Stars;
	
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

	public void Victory_In()
	{

		Debug.Log ("Che score ----- "+LevelManager.checkPointScore);
		Text_Coins.text = "" + LevelManager.myScript._LFULLDATA.LevelReward;// LevelManager.myScript.StarValues [LevelManager.myScript.Selected_Level - 1].x;

		Text_Stars.text=""+LevelManager.checkPointScore+"*100  "+(LevelManager.checkPointScore*100);



		int aa=	PlayerPrefs.GetInt (MyGamePrefs.Total_Coins);
		aa += (LevelManager.myScript._LFULLDATA.LevelReward+(LevelManager.checkPointScore*100));

		PlayerPrefs.SetInt (MyGamePrefs.Total_Coins,aa);


		GameManager.myScript.UpDateCoinsText ();

		LevelManager.checkPointScore = 0;
		//Text_Stars.text = "" + LevelManager.myScript.CollectedStars;

	//	TotalLevelCoins =(int)LevelManager.myScript.StarValues [LevelManager.myScript.Selected_Level - 1].x;


		Rewards_Page.gameObject.SetActive (true);
	//	Camera.main.GetComponent<CameraFilterPack_Blur_Bloom> ().enabled = true;

//		PlayerPrefs.SetInt(MyGamePrefs.Total_Coins,
//		                   PlayerPrefs.GetInt(MyGamePrefs.Total_Coins)+
//		                   ((int)LevelManager.myScript.StarValues [LevelManager.myScript.Selected_Level - 1].x+
//		                   (int)LevelManager.myScript.StarValues [LevelManager.myScript.Selected_Level - 1].y+
//		 					(int)LevelManager.myScript.StarValues [LevelManager.myScript.Selected_Level - 1].z));

	//	SetStars(1);
	//	CheckCoins ();

	//	showPreLCScoreDouble ();


		//AdManager.instance.RunActions (AdManager.PageType.LC,PlayerPrefs.GetInt (MyGamePrefs.Selected_Level),PlayerPrefs.GetInt (MyGamePrefs.Total_Coins));
	}




	void CheckCoins()
	{
		if(TimerScript.myScript.TimerTimeInSec>LevelManager.myScript.LevelTime[LevelManager.myScript.Selected_Level-1]/3)
		{
			print("This is star 2");
			TotalLevelCoins+=(int)LevelManager.myScript.StarValues [LevelManager.myScript.Selected_Level - 1].y;
			SetStars(2);
		}
		if(LevelManager.myScript.CollectedStars>=LevelManager.myScript.TotalStarsInLevel[LevelManager.myScript.Selected_Level-1])
		{
			print("This is star 3");
			TotalLevelCoins+=(int)LevelManager.myScript.StarValues [LevelManager.myScript.Selected_Level - 1].z;
			SetStars(3);
		}

		Text_Coins.text =""+TotalLevelCoins;
	}

	void SetStars(int Value)
	{
		if(Value==1)
		{
			Stars[Value-1].gameObject.SetActive(true);
			PlayerPrefs.SetInt(MyGamePrefs.LevelStars[LevelManager.myScript.Selected_Level - 1],1);
		}
		if(Value==2)
		{
			Stars[Value-1].gameObject.SetActive(true);
			PlayerPrefs.SetInt(MyGamePrefs.LevelStars[LevelManager.myScript.Selected_Level - 1],2);
		}
		if(Value==3)
		{
			Stars[Value-1].gameObject.SetActive(true);
			PlayerPrefs.SetInt(MyGamePrefs.LevelStars[LevelManager.myScript.Selected_Level - 1],3);
		}
	}



	//btmrevenue.. remove this comment.. LC
	public GameObject preLCScoreDoublePopup;
    public Text doubleCoinsTxt;

    private void showPreLCScoreDouble()
    {
        doubleCoinsTxt.text = " " + LevelManager.myScript._LFULLDATA.LevelReward;
        preLCScoreDoublePopup.SetActive(true);
    }

    //player clicked double my Coins..
    public void doubleMyScoreWithVideo()
    {
//        GameConfigs2018.mee.showURewardedVideoHere((result) =>
//        {
//            if (result == true)
//            {
//
//					int aa=	PlayerPrefs.GetInt (MyGamePrefs.Total_Coins);
//
//                //gameObject.SetActive(false);
//					Debug.Log("double watched fully..!"+aa+" :: "+LevelManager.myScript._LFULLDATA.LevelReward);
//                animatingScore = LevelManager.myScript._LFULLDATA.LevelReward;
//
//
//					aa += LevelManager.myScript._LFULLDATA.LevelReward;
//
//                LevelManager.myScript._LFULLDATA.LevelReward = LevelManager.myScript._LFULLDATA.LevelReward * 2;
//
//
//
//
//
//					PlayerPrefs.SetInt (MyGamePrefs.Total_Coins,aa);
//
//					Debug.Log("double watched fully..!"+aa);
//
//					GameManager.myScript.UpDateCoinsText ();
//
//
//                StartCoroutine(ScoreDoubleAnim());
//            }
//            else
//            {
//                //gameObject.SetActive(true);
//                Debug.Log("Not Watched Video No double.....");
//                //new GoogleMobileAds.Api.Reward();
//
//                Invoke("delayHide", 0.1f);
//               // Levelcompleteup();
//                isSkippedDouble = true;
//                Invoke("ShowUR_Admob", 0.6f);
//            }
//
//        });
    }

    WaitForEndOfFrame wtend = new WaitForEndOfFrame();
    private int animatingScore = 0;
	private bool Islevelcomplete = false;
    IEnumerator ScoreDoubleAnim()
    {
        while (true)
        {
            yield return wtend;
            animatingScore += 100;
            doubleCoinsTxt.text = animatingScore.ToString();
            if (animatingScore >= LevelManager.myScript._LFULLDATA.LevelReward && Islevelcomplete == false)
            {
                Debug.Log("Exists in this condition ...." + animatingScore + " _" + LevelManager.myScript._LFULLDATA.LevelReward);
                doubleCoinsTxt.text = "" + LevelManager.myScript._LFULLDATA.LevelReward;
                StopCoroutine(ScoreDoubleAnim());
                Invoke("delayHide", 0.1f);
				Islevelcomplete = true;
              //  Levelcompleteup();
                Invoke("ShowUR_Admob", 0.6f);
            }
        }
    }

    private void delayHide()
    {
        preLCScoreDoublePopup.SetActive(false);
    }

    private bool isSkippedDouble = false;

    //player clicked on Skip..
    public void doubleMyScore_Skip()
    {
        preLCScoreDoublePopup.SetActive(false);
      //  Levelcompleteup();
        isSkippedDouble = true;
        Invoke("ShowUR_Admob", 0.5f);
    }






	private void ShowUR_Admob()
	{
		
		//arjj lc
//		if (isSkippedDouble)
//		{
//			Debug.Log("btm ads Video skipped..!");
//			if (!Btm_UnityAdsManager.ShowUnityRewardedAd("video"))
//			{
//				//doesn't matter as this is Level Complete Ad..
//				if (GameConfigs2018.mee) GameConfigs2018.mee.showRotationAds(PlayerPrefs.GetInt (MyGamePrefs.Selected_Level), AdsPageType.lc);
//			}
//			else
//			{
//				Btm_FbManager.LogLCEvent(PlayerPrefs.GetInt (MyGamePrefs.Selected_Level), 1);
//				GameConfigs2018.mee.checkDynamicRating();
//			}
//		}
//		else
//		{
//			Debug.Log("btm ads Video not skipped..!");
//			if (GameConfigs2018.mee)
//				GameConfigs2018.mee.showRotationAds(PlayerPrefs.GetInt (MyGamePrefs.Selected_Level), AdsPageType.lc);
//		}
	}
}
