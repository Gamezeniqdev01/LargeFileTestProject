using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class DailyBonusManager : MonoBehaviour 
{
	public static DailyBonusManager myScript;

	public GameObject DailyBonusObj;
	public GameObject[] Btn_GreenC;

	[HideInInspector]
	public int PreviousBonus;
	
	DateTime oldDate;
	DateTime currentDate;
	TimeSpan Total_Diff_Time;
	
	int Diff_Days;
	long temp;
	
	[HideInInspector]
	public int BonusAt_PreviousDay;
	[HideInInspector]
	public int BonusAt_Day;
	
	public int[] Rewards1;

	public Text MoneyShow;

	
	void Awake()
	{
		myScript=this;
		
		if(!PlayerPrefs.HasKey(MyGamePrefs.BonusTaken))
		{
			PlayerPrefs.SetString(MyGamePrefs.BonusTaken,"false");
		}
		if(PlayerPrefs.HasKey(MyGamePrefs.EnergyTime)==false)
		{
			PlayerPrefs.SetString(MyGamePrefs.EnergyTime, System.DateTime.Now.ToBinary().ToString());
		}
	}

	void Start () 
	{
		currentDate = System.DateTime.Now;
		temp = Convert.ToInt64(PlayerPrefs.GetString(MyGamePrefs.EnergyTime));
		oldDate = DateTime.FromBinary(temp);
		Total_Diff_Time = 	currentDate.Subtract(oldDate);
		Diff_Days=Total_Diff_Time.Days;
		print("Total Diff Days : "+Diff_Days);
		
		if(!PlayerPrefs.HasKey(MyGamePrefs.PreviousBonus))
		{
			PlayerPrefs.SetInt(MyGamePrefs.PreviousBonus,0);
			BonusAt_Day=1;
			PlayerPrefs.SetInt(MyGamePrefs.PreviousBonus,BonusAt_Day);
			Invoke("ShowBonus",3f);
		}
		else
		{
			BonusAt_PreviousDay=PlayerPrefs.GetInt(MyGamePrefs.PreviousBonus);
			if(Diff_Days>=1)
			{
				Diff_Days=1;
				BonusAt_Day=BonusAt_PreviousDay+1;
				if(BonusAt_Day>7)
				{
					BonusAt_Day=7;
				}
				PlayerPrefs.SetInt(MyGamePrefs.PreviousBonus,BonusAt_Day);
				PlayerPrefs.SetString(MyGamePrefs.BonusTaken,"false");
				Invoke("ShowBonus",3f);
			}
			else
			{
				if(PlayerPrefs.GetString(MyGamePrefs.BonusTaken)=="false")
				{
					Diff_Days=1;
					BonusAt_Day=BonusAt_PreviousDay;
					PlayerPrefs.SetInt(MyGamePrefs.PreviousBonus,BonusAt_Day);
					PlayerPrefs.SetString(MyGamePrefs.BonusTaken,"false");
					Invoke("ShowBonus",3f);
				}
				else
				{
					print("Bonus Already Taken");
				}
			}
		}
		
		print("Bonus Day : "+BonusAt_Day);
	}
	
	void ShowBonus()
	{
		DailyBonusObj.gameObject.SetActive(true);
//		Btn_GreenC[BonusAt_Day-1].gameObject.GetComponent<Image>().sprite=GreenBar;
		Btn_GreenC[BonusAt_Day-1].gameObject.SetActive(true);

		MoneyShow.text=""+Rewards1[BonusAt_Day-1]+" Coins";
		
	}
	void OnApplicationQuit()
	{
		PlayerPrefs.SetString(MyGamePrefs.EnergyTime, System.DateTime.Now.ToBinary().ToString());
	}
	void Update () 
	{
		
	}
	
	public void CollecctBonus()
	{
		PlayerPrefs.SetString(MyGamePrefs.BonusTaken,"true");
		
		PlayerPrefs.SetInt(MyGamePrefs.Total_Coins,(PlayerPrefs.GetInt(MyGamePrefs.Total_Coins)+Rewards1[BonusAt_Day-1]));

		DailyBonusTween.myScript.DailyBonus_Out();
	}
}
