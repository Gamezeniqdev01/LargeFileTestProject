using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;


public class LevelManager : MonoBehaviour 
{
	public static LevelManager myScript;

	public bool Is_Test;

	public int Selected_Level;
	public int Selected_Flight;
	public int Selected_Theme;

	public GameObject Btn_Start;
	public GameObject ThrottelObj;
	public bool Is_LevelStarted;
	public bool Is_LevelCompleted;

	public GameObject LightsObject;
	public float[] LevelTime;

	public GameObject[] Flights;
	public GameObject[] LevelPos;

	public GameObject HelpPos;
	public GameObject[] HelpLevels;
	public string[] HelpTask;


	public GameObject[] CountryLevelObj;

	//public GameObject[] LevelObjects;
	public string[] LevelTask;
	public Vector3[] StarValues;
	public int[] TotalStarsInLevel;
	public int[] TotalRingsInLevel;
	public GameObject Victory_Page,Defeat_Page;

	public Text DefeatMeassageTxt;

	[HideInInspector]
	public int CollectedStars=0;
	public int CollectedRings=0;



	public Rigidbody RefRigidBody;

	public static int TotalRings=0;

	public bool Is_EngineDamaged;

	public static int LevelFailCount;

	public static bool ISDestinTemp = false;

	public GameObject Skip_btn;
	public static bool IsSkipped = false;
	public Transform SavePointPos;
	void Awake()
	{
		myScript=this;
		IsSkipped = false;
		Skip_btn.SetActive (false);
	
		if(Application.platform!=RuntimePlatform.Android)
		{
			if(!Is_Test)
			{
				Selected_Theme=PlayerPrefs.GetInt(MyGamePrefs.Selected_Theme);
				Selected_Level = PlayerPrefs.GetInt (MyGamePrefs.Selected_Level);
				Selected_Flight = PlayerPrefs.GetInt (MyGamePrefs.Selected_Flight);
			}
		}
		else
		{
			Selected_Theme=PlayerPrefs.GetInt(MyGamePrefs.Selected_Theme);
			Selected_Level = PlayerPrefs.GetInt (MyGamePrefs.Selected_Level);
			Selected_Flight = PlayerPrefs.GetInt (MyGamePrefs.Selected_Flight);
		}

		Is_EngineDamaged = false;
	}

	void Start () 
	{

		//AdManager.instance.RunActions (AdManager.PageType.InGame,PlayerPrefs.GetInt (MyGamePrefs.Selected_Level));

	//arjj	GameConfigs2018.mee.showRotationAds (PlayerPrefs.GetInt (MyGamePrefs.Selected_Level),AdsPageType.ingame);

		//Btm_Utils2018.jarToast((SystemInfo.systemMemorySize+" : size : "+SystemInfo.graphicsMemorySize));

		#if UNITY_EDITOR
		//arj
		//SelectCountryManager.CountryIndex=1;
		//PlayerPrefs.SetInt (MyGamePrefs.Selected_Level,8);
		//Selected_Level = PlayerPrefs.GetInt (MyGamePrefs.Selected_Level);

		//PlayerPrefs.SetInt ("Training", 4);
		//Selected_Flight=3;
		#endif
		#if !UNITY_EDITOR
		SoundsManager.myScript.Sound_InFlight.GetComponent<AudioSource>().Stop();
		#endif

		Lfailed = false;

	//	MyPlayer = Flights [Selected_Flight - 1].gameObject;
		MyPlayer = GameObject.Instantiate (Flights [Selected_Flight - 1].gameObject) as GameObject;

		MyPlayer.GetComponent<Rigidbody> ().isKinematic = false;

		MyPlayer.GetComponent<UnityStandardAssets.Vehicles.Aeroplane.AeroplaneUserControl4Axis> ().enabled = false;
		MyPlayer.SetActive (true);


		LevelPos [SelectCountryManager.CountryIndex].transform.GetChild (Selected_Level - 1).gameObject.SetActive (true);
		Transform _lvlPos =	LevelPos [SelectCountryManager.CountryIndex].transform.GetChild (Selected_Level - 1).transform;

		if (PlayerPrefs.GetInt ("Training") <= 2) {

			MyPlayer.transform.localPosition = HelpPos.transform.localPosition;
			MyPlayer.transform.localRotation = HelpPos.transform.localRotation;

		} else {
			MyPlayer.transform.localPosition = _lvlPos.localPosition;
			MyPlayer.transform.localRotation = _lvlPos.localRotation;

		}

		TotalRings = TotalRingsInLevel [Selected_Level - 1];
		Debug.Log ("rings :"+TotalRings);


			
	



		//UnityStandardAssets.Vehicles.Aeroplane.AeroplaneUserControl4Axis


		checkPointScore = 0;
	}

	public void StopPlane(){
		UnityStandardAssets.Vehicles.Aeroplane.AeroplaneController.myScript.gameObject.GetComponent<Rigidbody> ().isKinematic = true;

	}



	public void StartNextBusScene(){
		RandomOpner.mee.FObj.gameObject.SetActive (true);
		RandomOpner.mee.MainCam.SetActive (false);
		RandomOpner.mee.StartBus ();

	}
	public void StartPlane(){

	
		BreakLogic.myScript.Is_Breaks = false;
		ApplyBrakes = false;
		UnityStandardAssets.Vehicles.Aeroplane.AeroplaneController.myScript.gameObject.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.None;
		UnityStandardAssets.Vehicles.Aeroplane.AeroplaneController.myScript.gameObject.GetComponent<Rigidbody> ().isKinematic = false;

	}
	void Update () 
	{


		if(ApplyBrakes){

		


			WheelBreakNew.myScript.Apply_Break ();
			WheelGroundCheck.myScript.Is_OnGround = true;


			//UnityStandardAssets.Vehicles.Aeroplane.AeroplaneController.myScript.gameObject.GetComponent<Rigidbody> ().velocity = Vector3.Lerp (UnityStandardAssets.Vehicles.Aeroplane.AeroplaneController.myScript.gameObject.GetComponent<Rigidbody> ().velocity,Vector3.zero,Time.deltaTime*0.5f);
			MyPlayer.GetComponent<Rigidbody> ().velocity = Vector3.Lerp (MyPlayer.gameObject.GetComponent<Rigidbody> ().velocity,Vector3.zero,Time.deltaTime*0.01f);


			MyPlayer.GetComponent<Rigidbody> ().constraints =	RefRigidBody.constraints;
		//	UnityStandardAssets.Vehicles.Aeroplane.AeroplaneController.myScript.gameObject.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezePositionZ;
		//	UnityStandardAssets.Vehicles.Aeroplane.AeroplaneController.myScript.gameObject.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezePositionY;
			//ThrottelObj.GetComponent<UnityStandardAssets.CrossPlatformInput.InputAxisScrollbar>().gameObject.GetComponent<Scrollbar> ().value = 0;

		}
		if(!Is_LevelCompleted && Is_LevelStarted)
		{
			if(Selected_Theme==1)
			{
				LevelCompleteCheck ();
			}
			else
				if(Selected_Theme==2)
			{
				LevelCompleteCheck2 ();
			}
			else
				if(Selected_Theme==3)
			{
				LevelCompleteCheck3 ();
			}
		}
	}

	public static GameObject MyPlayer;


	public void StartBusScene(){

	//	Debug.Log ("tRAining  "+PlayerPrefs.GetInt ("Training"));
		#if UNITY_EDITOR
	//	AssignLevelTask ();
	//	return;
		#endif

		if (PlayerPrefs.GetInt ("Training") <= 2) {
			AssignLevelTask ();
		} else {

			Skip_btn.SetActive (true);
			//Debug.Log (LevelPos [SelectCountryManager.CountryIndex].name+"-------changeAA1 "+Selected_Level+" :: "+LevelPos [SelectCountryManager.CountryIndex].transform.GetChild (Selected_Level - 1).name);
			LevelPos [SelectCountryManager.CountryIndex].transform.GetChild (Selected_Level - 1).gameObject.SetActive (true);
			Transform _lvlPos =	LevelPos [SelectCountryManager.CountryIndex].transform.GetChild (Selected_Level - 1).transform;

			LightsObject.transform.parent = _lvlPos;
			LightsObject.transform.localPosition = Vector3.zero;
			LightsObject.transform.localEulerAngles = Vector3.zero;

			Flights [Selected_Flight - 1].transform.localPosition = _lvlPos.position;
			Flights [Selected_Flight - 1].transform.localRotation = _lvlPos.localRotation;
			Flights [Selected_Flight - 1].gameObject.SetActive (true);

			RandomOpner.mee.StartBus ();
		}



	}

	public Camera MainCamm;
	public Camera world3dcamm;

	public void SkipIntro(){
		IsSkipped = true;
		RandomOpner.mee.StopIt ();
		AssignLevelTask ();
	}

	public LevelFullData _LFULLDATA;
	public static int checkPointScore = 0;
	public void AssignLevelTask()
	{

		Skip_btn.SetActive (false);
		UnityStandardAssets.Cameras.AutoCam.CanFollow = true;

		RandomOpner.mee.FObj.gameObject.SetActive (false);
		RandomOpner.mee.MainCam.SetActive (true);
		//RandomOpner.mee.MainCamPiovt.transform.parent = RandomOpner.mee.MainCam.transform;

		//MainCamm.farClipPlane = 1000000;
		//world3dcamm.farClipPlane = 10000;

		Btn_Start.gameObject.SetActive (false);
		TimerScript.myScript.Is_Stop=false;
		int index = Selected_Level - 1;
		//TimerScript.myScript.TimerTimeInSec = LevelTime [index];

//		MyPlayer = Flights [Selected_Flight - 1].gameObject;
//
//
//
//
//
//		MyPlayer.GetComponent<Rigidbody> ().isKinematic = false;
//		MyPlayer.SetActive (true);



		CountryLevelObj [SelectCountryManager.CountryIndex].SetActive (true);
		GameObject MyLvlObj = CountryLevelObj [SelectCountryManager.CountryIndex].gameObject;
		Debug.Log (MyLvlObj.name+ " Selected country "+SelectCountryManager.LevelsIncountry);


		if (PlayerPrefs.GetInt ("Training") <= 2) {

			MyPlayer.transform.localPosition = HelpPos.transform.localPosition;
			MyPlayer.transform.localRotation = HelpPos.transform.localRotation;

			HelpLevels [index].gameObject.SetActive (true);

			LevelPos [0].transform.GetChild (0).gameObject.SetActive (true);

			Debug.Log ("---------------- "+HelpLevels[index]);

			GameObject bb = HelpLevels[index].gameObject;
			_LFULLDATA = bb.GetComponent<LevelFullData> ();
//
//			GameObject bb = LevelPos [0].transform.GetChild (0).gameObject;
//			bb.SetActive (true);
//
//			_LFULLDATA = bb.GetComponent<LevelFullData> ();
//			TimerScript.myScript.TimerTimeInSec =_LFULLDATA.LeveL_Time;
//			Debug.Log (bb.name+ " aa" +bb.GetComponent<LevelFullData> ().LeveL_Time+" : "+TimerScript.myScript.TimerTimeInSec);


		} else {

			LevelPos [SelectCountryManager.CountryIndex].transform.GetChild (index).gameObject.SetActive (true);

			Transform _lvlPos =	LevelPos [SelectCountryManager.CountryIndex].transform.GetChild (index).transform;
			Debug.Log ("-------change1 "+SelectCountryManager.CountryIndex);
			MyPlayer.transform.localPosition = _lvlPos.localPosition;
			MyPlayer.transform.localRotation = _lvlPos.localRotation;

			GameObject aa = MyLvlObj.transform.GetChild (index).gameObject;
			aa.SetActive (true);

			_LFULLDATA = aa.GetComponent<LevelFullData> ();
			TimerScript.myScript.TimerTimeInSec =_LFULLDATA.LeveL_Time;
			Debug.Log (aa.name+ " aa" +aa.GetComponent<LevelFullData> ().LeveL_Time+" : "+TimerScript.myScript.TimerTimeInSec);


			//LevelObjects [index].gameObject.SetActive (true);
		}

	

		MapCanvasController.myScript.playerTransform = MyPlayer.transform;

		SavePointPos.position = MyPlayer.transform.position;

		PlayerPrefs.SetInt ("playingLevel",Selected_Level);

//		Aircraft.myScript.AirCraftEnable ();

		if(Selected_Theme==1)
		{
			//RandomOpner.mee.StartBus ();

			AssignFlightValues ();
			HelpManager.myScript.CheckHelp();
		}
		else
		if(Selected_Theme==2)
		{
			AssignFlightValues2 ();
		}
		else
		if(Selected_Theme==3)
		{
			
		}


		Is_LevelStarted = true;

		TotalRings = _LFULLDATA.Level_Rings;
		if (LevelManager.TotalRings <= 0) {
			GameManager.myScript.Text_Collectable.transform.parent.gameObject.SetActive (false);
		}



		if(_LFULLDATA.DelayAiPlanes.Length>=1){
			foreach (GameObject aa in _LFULLDATA.DelayAiPlanes ){
				aa.SetActive (true);
			}
		}

		GameManager.myScript.UpdateCollectText ();

	//	StartCoroutine (OnDelay(MyPlayer));
		MyPlayer.GetComponent<UnityStandardAssets.Vehicles.Aeroplane.AeroplaneUserControl4Axis> ().enabled = true;

	}
	IEnumerator OnDelay(GameObject MyPlayer ){
		
		yield return new WaitForSeconds (1);
	//	RandomOpner.mee.MainCam.SetActive (true);


	}
	public void AssignFlightValues()
	{
//		switch (Selected_Level) 
//		{
//		case 7:
//			UnityStandardAssets.CrossPlatformInput.CrossPlatformInputManager.SetAxis("Vertical", 2);
//			ThrottelObj.GetComponent<Scrollbar>().value=1;
//			break;
//		}
	}

	public void AssignFlightValues2()
	{
		switch (Selected_Level) 
		{
		case 7:
			UnityStandardAssets.CrossPlatformInput.CrossPlatformInputManager.SetAxis("Vertical", 0.1f);
			ThrottelObj.GetComponent<Scrollbar>().value=0.1f;
			Flights [Selected_Flight - 1].GetComponent<SmokeCtrl>().OnSmoke();
			ThrottelObj.GetComponent<UnityStandardAssets.CrossPlatformInput.InputAxisScrollbar>().IsEngineDamaged=true;
			break;
		case 10:
			UnityStandardAssets.CrossPlatformInput.CrossPlatformInputManager.SetAxis("Vertical", 2f);
			ThrottelObj.GetComponent<Scrollbar>().value=1f;
//			Flights [Selected_Flight - 1].GetComponent<SmokeCtrl>().OnSmoke();
//			ThrottelObj.GetComponent<UnityStandardAssets.CrossPlatformInput.InputAxisScrollbar>().IsEngineDamaged=true;
			break;
		}
	}

	public void LevelCompleteCheck()
	{

		//Debug.Log (WheelGroundCheck.myScript.Is_OnGround);
		if (WheelGroundCheck.myScript.Is_OnGround) {

			HelpManager.myScript.Btn_Brake.SetActive (true);

		} else {
			HelpManager.myScript.Btn_Brake.SetActive (false);

		}
//		switch(Selected_Level)
//		{
//
////		case 1:
////			if((int)UnityStandardAssets.Vehicles.Aeroplane.AeroplaneController.myScript.ForwardSpeed<=0 && WheelGroundCheck.myScript.Is_OnGround)
////			{
////				if(GameManager.myScript.MyGameState==GameManager.GameState.AtInGame)
////				{
////					LevelComplete_Call();
////				}
////			}
////			break;
//
////		case 2:
////			if((int)UnityStandardAssets.Vehicles.Aeroplane.AeroplaneController.myScript.Altitude>50)
////			{
////				if(GameManager.myScript.MyGameState==GameManager.GameState.AtInGame)
////				{
////					LevelComplete_Call();
////				}
////			}
////			break;
//		case 7:
//			if((int)UnityStandardAssets.Vehicles.Aeroplane.AeroplaneController.myScript.ForwardSpeed<=0 && WheelGroundCheck.myScript.Is_OnGround)
//			{
//				if(GameManager.myScript.MyGameState==GameManager.GameState.AtInGame)
//				{
//					LevelComplete_Call();
//				}
//			}
//			break;
//		case 8:
//			if((int)UnityStandardAssets.Vehicles.Aeroplane.AeroplaneController.myScript.ForwardSpeed<=0 && WheelGroundCheck.myScript.Is_OnGround)
//			{
//				if(GameManager.myScript.MyGameState==GameManager.GameState.AtInGame)
//				{
//					LevelComplete_Call();
//				}
//			}
//			break;
//		case 9:
//			if((int)UnityStandardAssets.Vehicles.Aeroplane.AeroplaneController.myScript.ForwardSpeed<=0 && WheelGroundCheck.myScript.Is_OnGround)
//			{
//				if(WheelGroundCheck.myScript.GroundName=="Runway1")
//				{
//					if(GameManager.myScript.MyGameState==GameManager.GameState.AtInGame)
//					{
//						LevelComplete_Call();
//					}
//				}
//			}
//			break;
//		case 10:
//		if((int)UnityStandardAssets.Vehicles.Aeroplane.AeroplaneController.myScript.ForwardSpeed<=0 && WheelGroundCheck.myScript.Is_OnGround)
//		{
//			if(WheelGroundCheck.myScript.GroundName=="Runway2")
//			{
//				if(GameManager.myScript.MyGameState==GameManager.GameState.AtInGame)
//				{
//					LevelComplete_Call();
//				}
//			}
//		}
//		break;
//		}
	}

	public void LevelCompleteCheck2()
	{
//		print("This Is LC CHeck : "+Selected_Level);
		switch (Selected_Level) 
		{
		case 2:
			if((int)UnityStandardAssets.Vehicles.Aeroplane.AeroplaneController.myScript.ForwardSpeed<=0 && WheelGroundCheck.myScript.Is_OnGround)
			{
				if(WheelGroundCheck.myScript.GroundName=="Ship2")
				{
					if(GameManager.myScript.MyGameState==GameManager.GameState.AtInGame)
					{
						LevelComplete_Call();
					}
				}
			}
			break;
		case 6:
			if((int)UnityStandardAssets.Vehicles.Aeroplane.AeroplaneController.myScript.ForwardSpeed<=0 && WheelGroundCheck.myScript.Is_OnGround)
			{
				if(WheelGroundCheck.myScript.GroundName=="Ship1")
				{
					if(GameManager.myScript.MyGameState==GameManager.GameState.AtInGame)
					{
						LevelComplete_Call();
					}
				}
			}
			break;
		case 7:
			if((int)UnityStandardAssets.Vehicles.Aeroplane.AeroplaneController.myScript.ForwardSpeed<=0 && WheelGroundCheck.myScript.Is_OnGround)
			{
				print("This Is LC 1st Done : "+Selected_Level);
				if(WheelGroundCheck.myScript.GroundName=="Ship2")
				{
					print("This Is LC 2ndst Done : "+Selected_Level);
					if(GameManager.myScript.MyGameState==GameManager.GameState.AtInGame)
					{
						print("This Is LC 3rdst Done : "+Selected_Level);
						LevelComplete_Call();
					}
				}
			}
			break;
		case 8:
			if((int)UnityStandardAssets.Vehicles.Aeroplane.AeroplaneController.myScript.ForwardSpeed<=0 && WheelGroundCheck.myScript.Is_OnGround)
			{
				if(WheelGroundCheck.myScript.GroundName=="Ship1")
				{
					if(GameManager.myScript.MyGameState==GameManager.GameState.AtInGame)
					{
						LevelComplete_Call();
					}
				}
			}
			break;
		case 10:
			if((int)UnityStandardAssets.Vehicles.Aeroplane.AeroplaneController.myScript.ForwardSpeed<=0 && WheelGroundCheck.myScript.Is_OnGround)
			{
				if(WheelGroundCheck.myScript.GroundName=="Ship2")
				{
					if(GameManager.myScript.MyGameState==GameManager.GameState.AtInGame)
					{
						LevelComplete_Call();
					}
				}
			}
			break;
		}
	}
	public void LevelCompleteCheck3()
	{
		switch (Selected_Level) 
		{
		case 2:
			if((int)UnityStandardAssets.Vehicles.Aeroplane.AeroplaneController.myScript.ForwardSpeed<=0 && WheelGroundCheck.myScript.Is_OnGround)
			{
				if(WheelGroundCheck.myScript.GroundName=="Runway2")
				{
					if(GameManager.myScript.MyGameState==GameManager.GameState.AtInGame)
					{
						LevelComplete_Call();
					}
				}
			}
			break;
		case 7:
			if((int)UnityStandardAssets.Vehicles.Aeroplane.AeroplaneController.myScript.ForwardSpeed<=0 && WheelGroundCheck.myScript.Is_OnGround)
			{
				if(WheelGroundCheck.myScript.GroundName=="Runway2")
				{
					if(GameManager.myScript.MyGameState==GameManager.GameState.AtInGame)
					{
						LevelComplete_Call();
					}
				}
			}
			break;

		case 9:
			if((int)UnityStandardAssets.Vehicles.Aeroplane.AeroplaneController.myScript.ForwardSpeed<=0 && WheelGroundCheck.myScript.Is_OnGround)
			{
				if(WheelGroundCheck.myScript.GroundName=="Ship1")
				{
					if(GameManager.myScript.MyGameState==GameManager.GameState.AtInGame)
					{
						LevelComplete_Call();
					}
				}
			}
			break;
		case 10:
			if((int)UnityStandardAssets.Vehicles.Aeroplane.AeroplaneController.myScript.ForwardSpeed<=0 && WheelGroundCheck.myScript.Is_OnGround)
			{
				if(WheelGroundCheck.myScript.GroundName=="Runway1")
				{
					if(GameManager.myScript.MyGameState==GameManager.GameState.AtInGame)
					{
						LevelComplete_Call();
					}
				}
			}
			break;
		}
	}
	public bool ApplyBrakes=false;

	public void MidDestination_check(){
		Debug.Log (CollectedRings+" :: "+" cke "+LevelManager.TotalRings);
	//	#if UNITY_EDITOR
	//	if (TotalRingsInLevel [Selected_Level - 1] ==0 || (CollectedRings <= (LevelManager.TotalRings *0.5f) ) ) {
	//	#elif
	//		if (TotalRingsInLevel [Selected_Level - 1] ==0 || (CollectedRings >= (LevelManager.TotalRings *0.5f) ) ) {
	//			#endif	

			if (TotalRingsInLevel [Selected_Level - 1] ==0 || (CollectedRings >= (LevelManager.TotalRings *0.5f) ) ) {
			ApplyBrakes = true;
			Invoke ("StopPlane", 1);

			MidStationHandler.mee.Invoke ("OpenMidComplete",1);

		} else {
			ApplyBrakes = true;
			Invoke ("StopPlane", 5);
			Defeat_In("notcollected");
		}

	}
	public void LevelComplete_Call()
	{
		Debug.Log (CollectedRings + " : " + LevelManager.TotalRings);
		//	#if UNITY_EDITOR
		//	if (CollectedRings <= LevelManager.TotalRings){
		//	#elif
		//	if (CollectedRings >= LevelManager.TotalRings){
		//	#endif
		if (Lfailed == false) {

		

		if (CollectedRings >= LevelManager.TotalRings) {
			LevelFailCount = 0;
			if (HelpManager.myScript != null) {
				HelpManager.myScript.off_TotalHelp ();
			}
			if (SoundsManager.myScript != null) {
				SoundsManager.myScript.Sound_LC.GetComponent<AudioSource> ().Play ();
			}
			UnityStandardAssets.Vehicles.Aeroplane.AeroplaneAudio.myScript.m_AdvancedSetttings.engineMasterVolume = 0;
			UnityStandardAssets.Vehicles.Aeroplane.AeroplaneAudio.myScript.m_AdvancedSetttings.windMasterVolume = 0.2f;	
			ApplyBrakes = true;

			MainCamm.transform.parent.gameObject.SetActive (false);


			RandomOpner.mee.MainCam.SetActive (false);
			RandomOpner.mee.FObj.gameObject.SetActive (true);
			RandomOpner.mee.FObj.transform.parent = MyPlayer.transform;
			RandomOpner.mee.FObj.transform.localPosition = Vector3.zero;
			RandomOpner.mee.FObj.transform.localPosition = new Vector3 (-283, 12, 16);

			RandomOpner.mee.FObj.transform.parent = null;

			RandomOpner.mee.FObj.LookObj = MyPlayer.transform;

			MyPlayer.GetComponent<UnityStandardAssets.Vehicles.Aeroplane.AeroplaneController> ().enabled = false;
			MyPlayer.GetComponent<UnityStandardAssets.Vehicles.Aeroplane.AeroplaneUserControl4Axis> ().enabled = false;


			//	UnityStandardAssets.Vehicles.Aeroplane.AeroplaneController.myScript


			Invoke ("StopPlane", 5);
			UnityStandardAssets.Cameras.AutoCam.myScript.enabled = false;
			GameManager.myScript.MyGameState = GameManager.GameState.AtLevelC;

			Invoke ("MakeDelayComplete", 3);
		
		} else {
			//show fail
			ApplyBrakes = true;
			Invoke ("StopPlane", 5);
			Defeat_In ("notcollected");
		}
	}
	}


	void MakeDelayComplete(){

		PlayArea_Tween.myScript. PlayArea_Out ();
		PlayArea_Tween.myScript.PlayAreaObjs [7].transform.parent.position = new Vector3 (1500, 1500, 1500);
		print ("Level Completed");
		Is_LevelCompleted = true;
		LevelCompleteEffect ();
		Invoke ("SetOrbitCamFalse", 1);
		CheckLevelComplete_Stuff ();


	//	Btm_GPGManager.submitScoreToLeaderBoard (PlayerPrefs.GetInt (MyGamePrefs.Total_Coins));
	//	GameConfigs2018.mee.showRotationAds (PlayerPrefs.GetInt (MyGamePrefs.Selected_Level),AdsPageType.lc);
	//arj ad

	}
	public void LevelCompleteEffect()
	{
		OrbitCamX ();
	}

	public void OrbitCamX()
	{
		iTween.ValueTo (this.gameObject, iTween.Hash ("from",OrbitCam.myScript.CameraYOffset , "to", 25, "time",1, "delay", 0, "easetype", iTween.EaseType.linear, "onupdate", "SetOrbitCamX", "oncomplete", "SetOrbitCam", "oncompletetarget", this.gameObject));
	}
	
	public void SetOrbitCamX(float Value)
	{
		OrbitCam.myScript.CameraXOffset = Value;
//		OrbitCam.myScript.CameraYOffset = Value;
//		OrbitCam.myScript.CameraZOffset = Value;
	}
	
	public void SetOrbitCamFalse()
	{
		OrbitCam.myScript.SetCameraActive(false); 
		Victory_Page.gameObject.SetActive (true);
		Rewards_Tween.myScript.Victory_In ();
	}

	public static bool Lfailed = false;
	public void Defeat_In(string _reson="Crashed")
	{


		if( _reson=="Crashed"){
			DefeatMeassageTxt.text = "Oops...your flight was crashed";
		}
		else if( _reson=="notcollected"){
			DefeatMeassageTxt.text = "Oops.. you have missed some stars";
		}
		else if( _reson=="TimeOut"){
			DefeatMeassageTxt.text = "Oops..Time is out";
		}

	//	notcollected
		LevelFailCount+=1;
		if(LevelFailCount==5)
		{
		//	NativePopUp.myScript.Invoke("UnLockAllLevels",1);
			LevelFailCount=0;
		}
		if(HelpManager.myScript!=null)
		{
			HelpManager.myScript.off_TotalHelp();
		}
		if(SoundsManager.myScript!=null)
		{
			SoundsManager.myScript.Sound_LF.GetComponent<AudioSource>().Play();
		}
		UnityStandardAssets.Vehicles.Aeroplane.AeroplaneAudio.myScript.m_AdvancedSetttings.engineMasterVolume=0;
		UnityStandardAssets.Vehicles.Aeroplane.AeroplaneAudio.myScript.m_AdvancedSetttings.windMasterVolume=0.2f;


		//AdManager.instance.RunActions (AdManager.PageType.LF,PlayerPrefs.GetInt (MyGamePrefs.Selected_Level));

		//arjj GameConfigs2018.mee.showRotationAds (PlayerPrefs.GetInt (MyGamePrefs.Selected_Level),AdsPageType.lf);

		Defeat_Page.gameObject.SetActive (true);
		//Defeat_Tween.myScript.Wrecked_In ();
		//PlayArea_Tween.myScript.PlayAreaObjs[7].transform.parent.position=new Vector3(1500,1500,1500);

		//arj ad



	}

	public static int mCount;
	void CheckLevelComplete_Stuff()
	{
//		print("Selected Level : "+)

		Debug.Log ("level Increment arj");
		if(PlayerPrefs.GetInt ("Training") <=2){
			int count = PlayerPrefs.GetInt ("Training");
			count=3;
			PlayerPrefs.SetInt ("Training",count);



		}


		else if(Application.loadedLevelName=="GameplayEurope")
		{

			Phase_Tween.ComingFromPlayArea = true;

			Debug.Log ("------------ "+PlayerPrefs.GetInt(MyGamePrefs.Selected_Level)+ " Levels Unlocked "+PlayerPrefs.GetInt(MyGamePrefs.Unlocked_Levels_inCountry[StartCountryManger.StoredIndex]));
			int aa=	PlayerPrefs.GetInt(MyGamePrefs.Unlocked_Levels_inCountry[StartCountryManger.StoredIndex]);

			mCount = aa;

			if (PlayerPrefs.GetInt (MyGamePrefs.Selected_Level) >= aa) {
				aa++;
				PlayerPrefs.SetInt(MyGamePrefs.Unlocked_Levels_inCountry[StartCountryManger.StoredIndex],aa);

			}

			if(aa>=9 ){
				//PlayerPrefs.SetInt (MyGamePrefs.CountryData[StartCountryManger.StoredIndex+1],1);

				Debug.Log ("arj "+(PlayerPrefs.GetInt (MyGamePrefs.Unlocked_Levels_inCountry [StartCountryManger.StoredIndex + 1])));

				PlayerPrefs.SetInt (MyGamePrefs.CountryData[StartCountryManger.StoredIndex+1],1);
//				if (PlayerPrefs.GetInt (MyGamePrefs.Unlocked_Levels_inCountry [StartCountryManger.StoredIndex + 1]) <=1) {
//					PlayerPrefs.SetInt (MyGamePrefs.Unlocked_Levels_inCountry [StartCountryManger.StoredIndex + 1], 1);
//				} 

			}

//			Debug.Log (PlayerPrefs.GetInt(MyGamePrefs.Selected_Level)+ " Levels Unlocked :: "+PlayerPrefs.GetInt(MyGamePrefs.Unlocked_Levels_inCountry[StartCountryManger.StoredIndex]));

//			if(PlayerPrefs.GetInt(MyGamePrefs.Selected_Level)>=PlayerPrefs.GetInt(SelectCountryManager.LevelsIncountry+"A"))
//			{
//				PlayerPrefs.SetInt((SelectCountryManager.LevelsIncountry+"A"),(PlayerPrefs.GetInt(MyGamePrefs.Selected_Level)+1));
//			}


		}
	

	}
}
