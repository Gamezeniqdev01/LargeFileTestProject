using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpgradeControl : MonoBehaviour 
{
	public static UpgradeControl myScript;
	public GameObject CameraUpgrade;
	public Vector2[] FlightPrice;
	public GameObject[] Btn_Buy;
	public GameObject[] Btn_Fly;
	public GameObject[] PricePanels;
    public GameObject UnlockAllBtn;
	void Awake()
	{
		myScript=this;
		for(int i=0;i<14;i++)
		{
			if(PlayerPrefs.HasKey(MyGamePrefs.Unlocked_Flights[i])==false)
			{PlayerPrefs.SetString(MyGamePrefs.Unlocked_Flights[i],"false");}
		}
	}

	void Start () 
	{
		for (int i = 0; i < 14; i++) {

			Btn_Buy [i].transform.GetChild (0).GetComponent<Text> ().text = FlightPrice [i].x + "";
		}
		CheckLocks ();
		CheckForVideoAvailablity();


	
	}
	
	void Update () 
	{
	
	}

	public void SubscribetoUnlock(){
		Invoke ("unlockNow",1);




	}

	void unlockNow(){


		PlayerPrefs.SetString(MyGamePrefs.Unlocked_Flights[0],"true");
		CheckLocks ();
	}
	public void CheckLocks()
	{
        bool IsUnlockAll = true;
		for(int i=0;i<14;i++)
		{
			Debug.Log (MyGamePrefs.Unlocked_Flights.Length+" : "+ i+" locked : "+PlayerPrefs.GetString(MyGamePrefs.Unlocked_Flights[i]));
			if(PlayerPrefs.GetString(MyGamePrefs.Unlocked_Flights[i])=="false")
			{
				Btn_Buy[i].gameObject.SetActive(true);
				Btn_Fly[i].gameObject.SetActive(false);
                IsUnlockAll = false;
            }
            else
			{
				Btn_Buy[i].gameObject.SetActive(false);
			//	PricePanels[i].gameObject.SetActive(false);
				Btn_Fly[i].gameObject.SetActive(true);

            }
           

		}
        Debug.LogError("IsUnlockAll=" + IsUnlockAll);
        if (IsUnlockAll)
        {
            UnlockAllBtn.SetActive(false);
        }


        if (MenuManager.myScript!=null){
			MenuManager.myScript.SetCoinsToAllText ();
		}
//		Btn_Buy [0].SetActive (false);  // Harish
	}

	public void CheckForPurchase(int value)
	{
		if(PlayerPrefs.GetString(MyGamePrefs.Unlocked_Flights[value-1])!="true")
		{
			if(PlayerPrefs.GetInt(MyGamePrefs.Total_Coins)>=(int)FlightPrice[value-1].x)
			{
			//	if(PlayerPrefs.GetInt(MyGamePrefs.TotalStars)>=(int)FlightPrice[value-1].y)
			//	{
					PlayerPrefs.SetInt(MyGamePrefs.Total_Coins,(PlayerPrefs.GetInt(MyGamePrefs.Total_Coins)-(int)FlightPrice[value-1].x));

				//	PlayerPrefs.SetInt(MyGamePrefs.Total_Starts,(PlayerPrefs.GetInt(MyGamePrefs.Total_Starts)-(int)FlightPrice[value-1].y));
					PlayerPrefs.SetString(MyGamePrefs.Unlocked_Flights[value-1],"true");
					CheckLocks ();
			//	}
			//	else
				//{
			//		print("Not enough Stars");
				//}
			}
			else
			{
				print("Not enough Coins");

				//AdManager.instance.BuyItem (1, true);

			}
		}
	}
	#region VideoAd
	public static string videosKey = "videosWatched";
	public Text Text_5Video;
	void CheckForVideoAvailablity()
	{
		if (!PlayerPrefs.HasKey (videosKey))
		{
			PlayerPrefs.SetInt (videosKey, 5);
		}
		SetVideoCount ();
	}
	void SetVideoCount()
	{
		if (PlayerPrefs.GetInt(videosKey)>0)
		{
			Text_5Video.text = "Watch " + PlayerPrefs.GetInt (videosKey, 5) + " Videos to\nUnlock the Fight";
		}
	}
	
	public static int selectedVideoType = 0;
	public void WatchVideo(int type)
	{
		//watchSuccess ();
		selectedVideoType = type;
		//GoogleMobileAdsDemoScript.myScript.ShowRewardBasedVideo();
	}
	
	public string watchSuccess()
	{
		Debug.Log ("watchSuccess::");
		int val = PlayerPrefs.GetInt (videosKey,5);
		val -= 1;
		PlayerPrefs.SetInt(videosKey,val);
		SetVideoCount ();
		Debug.Log ("Videos To watch:: " + PlayerPrefs.GetInt (videosKey, 5));
		if (PlayerPrefs.GetInt (videosKey,5) <= 0) 
		{
			PlayerPrefs.SetString(MyGamePrefs.Unlocked_Flights[0],"true");
			CheckLocks ();
		}
		return PlayerPrefs.GetInt (videosKey, 5)+"";
	}
	#endregion

}
