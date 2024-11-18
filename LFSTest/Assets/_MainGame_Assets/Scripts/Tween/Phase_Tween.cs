using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Phase_Tween : MonoBehaviour 
{

	[System.Serializable]
	public class  DistinationPlaces{
		public string[] m_DistinationPlaces;
	}

	public GameObject RefObj;

	public static Phase_Tween myScript;

	public GameObject Btn_Back,Ttl_Phase,Btn_Mg;
	public GameObject Btn_BackA,Btn_NextA;
	public GameObject[] Phases,Stages;
	public GameObject[] Text_Unlck;



	public GameObject UnlockPop;
	public GameObject LevelSelection;
	public GameObject[] TrainingPop;
	public GameObject[] CountrySelection;


	public static int LsCount=0;
	public DistinationPlaces[] DNames;


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

	int PhaseCount;

	public static bool ComingFromPlayArea = false;

	public void OnDoneCountrySelection(bool SetIndex=true){
		
//		if(PlayerPrefs.GetInt ("Training")== 3){
//
//			TrainingPop [3].SetActive (true);
//			TrainingPop [3].transform.GetChild (1).GetComponent<Text> ().text = "You Have Selected " + StartCountryManger.DefaultCountry;
//		}

		//PlayerPrefs.SetInt ("Training", 4);
		TrainingPop [0].SetActive (false);

		Debug.Log (StartCountryManger.StoredIndex+" stored index");
		if(SetIndex){
		PlayerPrefs.SetInt (MyGamePrefs.CountryData[StartCountryManger.StoredIndex],1);
		}

		if (ComingFromPlayArea) {
			OpenLevels ();
		} else {
			CountrySelection [0].SetActive (true);
		//	SelectCountryManager.mee.OnOpenClickButton ();
		}


	}


	public void openCountrySelection(){
		ComingFromPlayArea = false;
		LevelSelection.SetActive (false);

		CountrySelection[0].SetActive (true);

		SelectCountryManager.mee.OnOpenClickButton ();
	}
	public void ContinueTrain(int Num){
		if (Num == 1) {
			iTween.MoveTo (TrainingPop [1].gameObject, iTween.Hash ("x", TrainingPop [1].gameObject.transform.position.x - 3000, "time", 0.5, "islocal", true, "easetype", iTween.EaseType.easeInBack));

			//TrainingPop[1].SetActive (false);
			//TrainingPop [2].SetActive (true);
			//iTween.MoveFrom (TrainingPop [2].gameObject, iTween.Hash ("x", TrainingPop [2].gameObject.transform.position.x + 1000, "delay", 0.6f, "time", 0.5, "islocal", true, "easetype", iTween.EaseType.easeOutBack));

			StartCountryManger.StoredIndex = 0;
			PlayerPrefs.SetInt (MyGamePrefs.CountryData[StartCountryManger.StoredIndex],1);
			OnDoneCountrySelection (false);

			//iTween.PunchScale (TrainingPop[2].gameObject,iTween.Hash("x",0.8,"y",0.8,"islocal",true));
		} else if (Num == 3){
			iTween.MoveTo (TrainingPop [3].gameObject, iTween.Hash ("x", TrainingPop [3].gameObject.transform.position.x - 3000, "time", 0.5, "islocal", true, "easetype", iTween.EaseType.easeInBack));
			TrainingPop [3].SetActive (false);

		}

		PlayerPrefs.SetInt ("Training", 5);

	}

	private string myinappID = "";
	private string myinapp2ID = "";

	void OpenPop(){





	}
	public GameObject myObj;

	public void showCountries()
	{
		RefObj.SetActive (true);
		Debug.Log (" A Training  "+PlayerPrefs.GetInt ("Training"));
		if (PlayerPrefs.GetInt ("Training") <= 2) {
			LoadingManager.SceneName = "GameplayEurope";
			MenuManager.myScript.LoadGame ();
			//MenuManager.myScript.Load_Theme1Lvl (PlayerPrefs.GetInt ("Training"));

		} else if (PlayerPrefs.GetInt ("Training") == 3) {
			TrainingPop [0].SetActive (true);
			TrainingPop [1].SetActive (true);
		} else {


			OnDoneCountrySelection (false);



		}

		//AdManager.instance.RunActions (AdManager.PageType.LvlSelection,PlayerPrefs.GetInt (MyGamePrefs.Selected_Level));

	}
	public void Phase_In(int value=0)
	{
		RefObj.SetActive (true);
		
		Debug.Log (value+" A Training  "+PlayerPrefs.GetInt ("Training"));

		//Menu_Tween.myScript.Envi3D.SetActive (false);
		//Menu_Tween.myScript.Mcam.enabled = true;
		if (value == -1) {
			LsCount++;

			LevelSelection.SetActive (true);
			OpenPop ();
		} else {




		if (PlayerPrefs.GetInt ("Training") <= 2) {
			LoadingManager.SceneName = "GameplayEurope";
			MenuManager.myScript.LoadGame ();
			//MenuManager.myScript.Load_Theme1Lvl (PlayerPrefs.GetInt ("Training"));

		} else if (PlayerPrefs.GetInt ("Training") == 3) {
			TrainingPop [0].SetActive (true);
			TrainingPop [1].SetActive (true);
		} else {
			

			OnDoneCountrySelection (false);

		

		}
	}
	}


	public void OpenLevels(){
	//	#if !UNITY_EDITOR

	//	#endif
		RefObj.SetActive (true);
		CountrySelection [0].SetActive (false);
		//Debug.Log (" Training AA "+PlayerPrefs.GetInt ("Training"));


		MenuManager.myScript.GameState = MenuManager.MenuState.Phase1;
		if (SoundsManager.myScript != null) {
			SoundsManager.myScript.Sound_Button.GetComponent<AudioSource> ().Play ();
		}
		PhaseCount = 1;
		Ttl_Phase.GetComponent<AlphaScript> ().Delay = 0;
		Ttl_Phase.GetComponent<AlphaScript> ().TimeInSec = 0.5f;
		Ttl_Phase.GetComponent<AlphaScript> ().AlphaValue = 1;
		Ttl_Phase.GetComponent<AlphaScript> ().AlphFade ();
	
		LsCount++;
		LevelSelection.SetActive (true);

		OpenPop ();



//arjj
	}


	////////////////
	/// 
	/// 
	public Text firlstLevelUnlockerWithVideo;



	//ON Click on Level Number..





	public void watchEarnn(){
		//AdManager.instance.ShowRewardVideo (1000,AdManager.RewardType.Coins);
	}

	public void CheckVideoAndContinue(){

	}

	public void OffGplus()
	{
		
	}

	public void Phase_Out()
	{


		ComingFromPlayArea = false;
		CountrySelection[0].SetActive (false);

		Ttl_Phase.GetComponent<AlphaScript> ().Delay = 0;
		Ttl_Phase.GetComponent<AlphaScript> ().TimeInSec = 0.2f;
		Ttl_Phase.GetComponent<AlphaScript> ().AlphaValue = 0;
		Ttl_Phase.GetComponent<AlphaScript> ().AlphFade ();
		
		iTween.MoveTo (Btn_Back.gameObject, iTween.Hash ("x", -1500, "time", 0.5, "islocal", true, "delay", 0, "easetype", iTween.EaseType.easeOutSine));			
		iTween.MoveTo (Btn_Mg.gameObject, iTween.Hash ("x", 1500, "time", 0.5, "islocal", true, "delay", 0, "easetype", iTween.EaseType.easeOutSine));	
		
		iTween.MoveTo (Btn_BackA.gameObject, iTween.Hash ("x", -1500, "time", 0.5, "islocal", true, "delay", 0, "easetype", iTween.EaseType.easeOutSine));	
		iTween.MoveTo (Btn_NextA.gameObject, iTween.Hash ("x", 1500, "time", 0.5, "islocal", true, "delay", 0, "easetype", iTween.EaseType.easeOutSine));	

		for(int i=0;i<3;i++)
		{
			iTween.MoveTo (Phases[i].gameObject, iTween.Hash ("x", -1500, "time", 0.5, "islocal", true, "delay", 0, "easetype", iTween.EaseType.easeOutSine));	
			iTween.MoveTo (Stages[i].gameObject, iTween.Hash ("x", 1500, "time", 0.5, "islocal", true, "delay", 0, "easetype", iTween.EaseType.easeOutSine));
		}

		iTween.MoveTo (Text_Unlck[1].gameObject, iTween.Hash ("x",0, "time", 0.5, "islocal", true, "delay", 0, "easetype", iTween.EaseType.easeOutSine));
		iTween.MoveTo (Text_Unlck[0].gameObject, iTween.Hash ("x",0, "time", 0.5, "islocal", true, "delay", 0, "easetype", iTween.EaseType.easeOutSine));


		LevelSelection.SetActive (false);


		RefObj.SetActive (false);
	}

	
	public void MoveNext()
	{
		
	}


	public void MoveBack()
	{
		
	}


}
