using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MidStationHandler : MonoBehaviour {

	public static string NextStation = "";

	public Text NextStation_txt;

	public static MidStationHandler mee;
	public GameObject Mobj;
	// Use this for initialization
	void Start () {
		mee = this;
	}



	public void OpenMidComplete(){
		Mobj.SetActive (true);

		NextStation_txt.text = "Next Destination is "+NextStation;
		BreakLogic.myScript.Is_Breaks = true;

		//AdManager.instance.RunActions (AdManager.PageType.PreLF,PlayerPrefs.GetInt (MyGamePrefs.Selected_Level));

		//arjj
		//GameConfigs2018.mee.showRotationAds (PlayerPrefs.GetInt (MyGamePrefs.Selected_Level),AdsPageType.lcpre);

		//ThrotleStickGo.gameObject.GetComponent<Scrollbar> ().value = 0;
	}


	public void ContinueJourney(){
		LevelManager.ISDestinTemp = true;
		Mobj.SetActive (false);
		LevelManager.myScript.StartNextBusScene ();

	}
	// Update is called once per frame
	void Update () {
		
	}
}
