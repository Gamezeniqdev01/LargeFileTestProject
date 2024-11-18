using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SetPrefs : MonoBehaviour 
{		
	public static SetPrefs myScript;

	public bool Is_Test;
	public bool Is_NeedInMobile;

	public int SetCash;

	public int UnlockLevels;
	public int UnlockFlights;

	void Awake () 
	{
		myScript=this;
	}
	
	void Start () 
	{
		if(Is_Test && Is_NeedInMobile)
		{
			if(Application.platform==RuntimePlatform.Android)
			{
				if(!PlayerPrefs.HasKey (MyGamePrefs.Unlocked_Levels))
				{
					SetPrefsUnlocks();
				}
			}
		}
		else
		{
			if(Is_Test)
			{
				if(Application.platform!=RuntimePlatform.Android)
				{
					SetPrefsUnlocks();
				}
			}
		}
	}
	
	void Update () 
	{
	
	}

	public void SetPrefsUnlocks()
	{
		//PlayerPrefs.SetInt (MyGamePrefs.Unlocked_Levels, UnlockLevels);
		PlayerPrefs.SetInt(MyGamePrefs.Unlocked_Levels_inCountry[StartCountryManger.StoredIndex],UnlockLevels);
		PlayerPrefs.SetInt (MyGamePrefs.Total_Coins, SetCash);

		for(int i=0;i<UnlockFlights;i++)
		{
			PlayerPrefs.SetString (MyGamePrefs.Unlocked_Flights[i], "true");
		}
	}

}
