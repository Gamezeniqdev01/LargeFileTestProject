using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectCountryManager : MonoBehaviour {


	public Button[] SelectButtons;
	public static SelectCountryManager mee;
	public static string LevelsIncountry="";
	public static int CountryIndex=0;
    public GameObject UnlockAllBtn,UnlockAllLevelsBtn;

	// Use this for initialization
	void Start () {

		mee = this;
        bool IsAllUnlocked = true;
		for (int i = 0; i < SelectButtons.Length; i++) {
			Debug.Log (PlayerPrefs.GetInt (MyGamePrefs.CountryData [i])+  " :country: "+ MyGamePrefs.CountryData [i]);
			if (PlayerPrefs.GetInt (MyGamePrefs.CountryData [i]) == 1) {

				SelectButtons[i].transform.GetChild(0).GetComponent<Text>().text="Select";
				SelectButtons [i].transform.GetChild (1).GetComponent<Image> ().enabled = false;
			} else {
                SelectButtons[i].transform.GetChild(0).GetComponent<Text>().text="$50,000";
				SelectButtons [i].transform.GetChild (1).GetComponent<Image> ().enabled = true;
			}

		}

        for (int i = 0; i < 5; i++)
        {
            Debug.Log(PlayerPrefs.GetInt(MyGamePrefs.CountryData[i]) + " :newcountry: " + MyGamePrefs.CountryData[i]);
            if (PlayerPrefs.GetInt(MyGamePrefs.CountryData[i]) == 0)
            {

                IsAllUnlocked = false;

            }
            

        }
        //Debug.Log("IsUnlockedAll Countries="+IsAllUnlocked);
        if (IsAllUnlocked)
            UnlockAllBtn.SetActive(false);

        CheckButtons ();
        bool IsUnlockedAllLvlsBtn = true;
        for (int j = 0; j < MyGamePrefs.ActiveWorlds; j++)
        {
            //Debug.LogError("is unlocked="+j+"="+ PlayerPrefs.GetInt(MyGamePrefs.Unlocked_Levels_inCountry[j], 1));
            if (PlayerPrefs.GetInt(MyGamePrefs.Unlocked_Levels_inCountry[j], 1) != 9)
            {
                IsUnlockedAllLvlsBtn = false;
                break;
            }
        }
        if (IsUnlockedAllLvlsBtn)
            UnlockAllLevelsBtn.SetActive(false);
    }



	public void OnClickButton(Button _obj){

		StartCountryManger.StoredIndex = int.Parse(_obj.name);
		Debug.Log (StartCountryManger.StoredIndex);
		if (PlayerPrefs.GetInt (MyGamePrefs.CountryData [StartCountryManger.StoredIndex]) == 1) {
		//if (_obj.transform.GetChild (0).GetComponent<Text> ().text == "Select") {
			PlayerPrefs.SetInt ("Training", 5);

		//	iTween.MoveTo (Phase_Tween.myScript.CountrySelection[1].gameObject,iTween.Hash("x",Phase_Tween.myScript.CountrySelection[1].gameObject.transform.position.x-1500,"time",0.5,"islocal",true,"easetype",iTween.EaseType.easeInBack));
		//	iTween.MoveTo (Phase_Tween.myScript.CountrySelection[2].gameObject,iTween.Hash("x",Phase_Tween.myScript.CountrySelection[2].gameObject.transform.position.x+1500,"time",0.5,"islocal",true,"easetype",iTween.EaseType.easeInBack));

			LevelsIncountry = _obj.transform.parent.GetChild (0).GetComponent<Text> ().text;
			CountryIndex = int.Parse(_obj.name);
			Phase_Tween.myScript.Invoke("OpenLevels",0.8f);
		} else {
			//AdManager.instance.BuyItem (2, true);

		}

	}

	public void CheckButtons(){

		for (int j = 0; j < MyGamePrefs.ActiveWorlds; j++) {

			if (PlayerPrefs.GetInt (MyGamePrefs.CountryData [j]) == 1) {
				Debug.Log ("m "+j);
				SelectButtons [j].transform.parent.GetChild (2).GetComponent<Image> ().enabled = false;

			}
		}

	}


	public void OnOpenClickButton(){
	//	iTween.MoveTo (Phase_Tween.myScript.CountrySelection[1].gameObject,iTween.Hash("x",-240,"time",0.5,"islocal",true,"easetype",iTween.EaseType.easeInBack));
	//	iTween.MoveTo (Phase_Tween.myScript.CountrySelection[2].gameObject,iTween.Hash("x",240,"time",0.5,"islocal",true,"easetype",iTween.EaseType.easeInBack));

	}
	// Update is called once per frame
	void Update () {
		
	}
}
