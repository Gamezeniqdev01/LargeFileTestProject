using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;



public class CameraSmoothFollowWithRotation : MonoBehaviour
{

	public static CameraSmoothFollowWithRotation Instance;

	public Transform[] _tInitialView;
	public List<Transform> _arrInitialViewList;

	public Transform _tDriverView;
	public Transform _tStationView;
	public Transform _tFreeHandView;
	public Transform _tLevelCompleteView;
	public Transform _tLevelFailedView;
	public Transform _tBridgeView1,_tBridgeView2,_tBridgeView3;
	public Transform _tTrainFullView;

	Transform target;
	public float distance;
	public float height;
	public Vector3 rotationOffSet;
	public float rotationDamping;
	public float heightDamping;

	[SerializeField] float XTouchSwipeLowerLimit;
	[SerializeField] float XTouchSwipeHighrLimit;
	[SerializeField] float YTouchSwipeLowerLimit;
	[SerializeField] float YTouchSwipeHigherLimit;


	void Awake ()
	{
		Instance	= this;
	}



	void OnStartResetCameraValues ()
	{
		
		mf_TimerForCameraChange = 0f;
		_icurrentInitialCamera	= 0;
		_arrInitialViewList.Clear ();
		_arrInitialViewList	= null;
	}

	int totalInitalViews	= 3;

	void SetLayerClippingDistanceOnStart ()
	{
		string _transString = "";
		if (_arrInitialViewList == null)
			_arrInitialViewList	= new List<Transform> ();
		for (int i = 1; i <= totalInitalViews; i++) {
			_transString	= "Pos" + i;
			Transform _tr	= GameObject.Find (_transString).transform;
			_arrInitialViewList.Add (_tr);
		}

		float[] distance	= new float[32];
		distance [9]	= 200;    // Layer 9 
		distance [8]	= 200;    // Layer 10 
		distance [10]	= 200;   // Layer 11
		distance [11]	= 200;   // Layer 12
		Camera _Camera	= GetComponent<Camera> ();
		_Camera.layerCullDistances	= distance;
	}

	void Start ()
	{
		OnStartResetCameraValues ();
		SetLayerClippingDistanceOnStart ();

		XTouchSwipeLowerLimit	= Screen.width / 10f;
		XTouchSwipeHighrLimit	= Screen.width - Screen.width / 9f;

		YTouchSwipeLowerLimit	= Screen.height / 8f;
		YTouchSwipeHigherLimit	= Screen.height - Screen.height / 10f; 

	
		Invoke ("FindObjectsAtStartForPsotions", 0.1f);
		transform.position = _arrInitialViewList [2].position;

	//	iTween.MoveTo (_arrInitialViewList [2].gameObject,iTween.Hash("z",(_arrInitialViewList [2].position.z+50),"time",10,"delay",1));

		Invoke ("makeCamMove",0.1f);//5
		SetTargetForCameraToFollow ();


	}

	public Transform lookObj;



	void makeCamMove(){
		startView = false;

		Invoke ("shownful",0.2f);//8
		//transform.position= _arrInitialViewList [1].position;
		Debug.Log ("can move now.....");
	}

	void shownful(){
		ShownFull = true;


		SetTargetForCameraToFollow ();
	}
	void FindObjectsAtStartForPsotions ()
	{
	//	_tDriverView	= GameObject.Find ("DriverView").transform;
		_tFreeHandView	= GameObject.Find ("FreeHandDriverView").transform;
	//	_tBridgeView1	= GameObject.Find ("BridgeView_1").transform;
	//	_tTrainFullView	= GameObject.Find ("TrainFullView").transform;
//		_tStationView	= GameObject.Find("StationView").transform;

		//_tBridgeView2	= GameObject.Find ("BridgeView_2").transform;
	//	_tBridgeView3	= GameObject.Find ("BridgeView_3").transform;

	
	}

	TouchPhase _touchPhaseInScreen;
	bool _bIsTouch	= false;
	Vector3 _touchPosInScreen;

	void CheckForTouch ()
	{
#if UNITY_EDITOR
		if (Input.GetMouseButtonDown (0) && _bIsTouch	== false) {
			_bIsTouch	= true;
			_touchPhaseInScreen	= TouchPhase.Began;
			_touchPosInScreen	= Input.mousePosition;
		} else if (Input.GetMouseButtonUp (0) && _bIsTouch	== true) {
			_bIsTouch	= false;
			_touchPhaseInScreen	= TouchPhase.Ended;
			_touchPosInScreen	= Input.mousePosition;
		} else if (Input.GetMouseButton (0) && _bIsTouch	== true) {
			_touchPhaseInScreen	= TouchPhase.Moved;
			_touchPosInScreen	= Input.mousePosition;
		}



#elif UNITY_ANDROID
		if(Input.touchCount <= 0)
			return;
		
		Touch[] _touches	= Input.touches;
		if(_touches[0].phase == TouchPhase.Began && _bIsTouch	== false)
		{
			_bIsTouch	= true;
			_touchPhaseInScreen	= TouchPhase.Began;
			_touchPosInScreen	= _touches[0].position;
		}
		else if((_touches[0].phase == TouchPhase.Ended || _touches[0].phase == TouchPhase.Canceled) && _bIsTouch	== true)
		{
			_bIsTouch	= false;
			_touchPhaseInScreen	= TouchPhase.Ended;
			_touchPosInScreen	= _touches[0].position;
		}
		else if((_touches[0].phase == TouchPhase.Moved || _touches[0].phase == TouchPhase.Stationary) && _bIsTouch	== true)
		{
			_touchPhaseInScreen	= TouchPhase.Moved;
			_touchPosInScreen	= _touches[0].position;
		}
#endif
	}

	float mf_TimerForCameraChange = 0;
	float mf_TargetTimerForCameraChange	= 1f;
	int _icurrentInitialCamera = 0;


	private bool startView = true;
	private bool ShownFull = false;
	//void LateUpdate ()
	void FixedUpdate ()
	{

		CheckForTouch ();


		OnFreeHandModeTouch ();
		UpdateCameraPositionOnLateUpdateForDriverView ();

	}

	public void SetTargetForCameraToFollow ()
	{


		rotationOffSet	= new Vector3 (0, 10, 0);
		target = _tFreeHandView;
		distance	= 15f;//10
		height = 5.5f;//3.5f

		heightDamping	= 2;
		rotationDamping	= 3;


		
	}


	//******* VIEW FREE HAND MODE ***********//
	bool isSingleTouch = false;
	Vector3 mv_InitialPos = Vector3.zero;
	float xDiff, yDiff, xOffset, yOffset;
	[SerializeField] float mf_FreeHandResponse = 0.1f;

	void OnFreeHandModeTouch ()
	{
		#region SINGLE TOUCH 
#if UNITY_EDITOR || UNITY_WEBPLAYER
		if (Input.mousePosition.x > XTouchSwipeLowerLimit && Input.mousePosition.x < XTouchSwipeHighrLimit && Input.mousePosition.y > YTouchSwipeLowerLimit && Input.mousePosition.y < YTouchSwipeHigherLimit) {
			if (Input.GetMouseButtonDown (0)) {
				isSingleTouch	= true;
				mv_InitialPos	= Input.mousePosition;
			} else if (Input.GetMouseButtonUp (0)) {
				isSingleTouch	= false;
			}
		} else
			isSingleTouch	= false;

#elif UNITY_ANDROID
		if(Input.touchCount == 1)
		{
			Touch _touch = Input.GetTouch(0);
			if(_touch.phase	== TouchPhase.Began && Input.mousePosition.x > XTouchSwipeLowerLimit && Input.mousePosition.x < XTouchSwipeHighrLimit && Input.mousePosition.y > YTouchSwipeLowerLimit && Input.mousePosition.y < YTouchSwipeHigherLimit)
			{
				mv_InitialPos	= _touch.position;
				isSingleTouch	= true;
			}
			else if(_touch.phase	== TouchPhase.Ended || _touch.phase == TouchPhase.Canceled)
			{
				isSingleTouch	= false;
			}

//			if(isSingleTouch && GamePlayManager.Instance.mb_IsTouchHasTexture)
//				isSingleTouch	= false;
		}
		else
			isSingleTouch	= false;
#endif
		

		if (isSingleTouch) {
			xDiff	= Input.mousePosition.x - mv_InitialPos.x;
			yDiff	= Input.mousePosition.y - mv_InitialPos.y;

			mv_InitialPos	= Input.mousePosition;

			if (Mathf.Abs (xDiff) > 0.001f) {
				xOffset	= xDiff * mf_FreeHandResponse;
			}

			if (Mathf.Abs (yDiff) > 0.001f) {
				yOffset	= yDiff * mf_FreeHandResponse;
			}
		}
//		else
		{
			xOffset	*= 0.9f;
			yOffset	*= 0.9f;
		}

		rotationOffSet.x	-= yOffset; 
		rotationOffSet.y	-= xOffset;
	
		rotationOffSet.x	= 0f;
		height	-= yOffset;
		height	= Mathf.Clamp (height, 0f, 10);

//		rotationOffSet.x	= clampAngles(rotationOffSet.x);
//		rotationOffSet.y	= clampAngles(rotationOffSet.y);

		#endregion
	}

	float clampAngles (float val)
	{
		if (val > 360)
			val	-= 360;
		if (val < -360)
			val	+= 360;

		return val;



	}


	//****** VIEW DRIVER MODE ****************//
	Vector3 _startTouchPoint = Vector3.zero;
	Vector3 _currentTouchPoint = Vector3.zero;

	void OnDriverModeTouch (TouchPhase _phase, Vector3 _touchPos)
	{
		if (_phase == TouchPhase.Began) {
			rotationOffSet	= Vector3.zero;
			_startTouchPoint	= _touchPos;
		} else if (_phase == TouchPhase.Ended || _phase == TouchPhase.Canceled) {
			rotationOffSet = Vector3.zero;
			_startTouchPoint	= Vector3.zero;
			_currentTouchPoint	= Vector3.zero;

		} else if (_phase == TouchPhase.Moved) {
			if (_touchPos.x < XTouchSwipeLowerLimit || _touchPos.x > XTouchSwipeHighrLimit || _touchPos.y < YTouchSwipeLowerLimit || _touchPos.y > YTouchSwipeHigherLimit)
				return;

			_currentTouchPoint	= _touchPos;
			rotationOffSet = _currentTouchPoint - _startTouchPoint;
			rotationOffSet.x	= rotationOffSet.x / 10f;
			rotationOffSet.y	= Mathf.Clamp (rotationOffSet.x, -limitOnDirection, limitOnDirection);
		}
	}

	float limitOnDirection	= 20f;
	Vector3 transformEulerAngles;

	void UpdateCameraPositionOnLateUpdateForDriverView ()
	{
		float wantedRotationInY	= target.eulerAngles.y - rotationOffSet.y;
		float wantedRotationInX	= target.eulerAngles.x + rotationOffSet.x;
		float wantedHeight = target.position.y + height;

		transformEulerAngles	= transform.eulerAngles;
		float currentRotationYOffSet	= transformEulerAngles.y;
		float currentRotationXOffSet	= transformEulerAngles.x;
		float currentHeight	= transform.position.y;

		currentHeight = Mathf.Lerp (currentHeight, wantedHeight, heightDamping * Time.deltaTime);
		currentRotationYOffSet = Mathf.LerpAngle (currentRotationYOffSet, wantedRotationInY, rotationDamping * Time.deltaTime);
		currentRotationXOffSet = Mathf.LerpAngle (currentRotationXOffSet, wantedRotationInX, rotationDamping * Time.deltaTime);

		Quaternion rotationOfCamera	= Quaternion.Euler (0, currentRotationYOffSet, 0);

//		transformEulerAngles	= transformEulerAngles + new Vector3(0,currentRotationYOffSet,0);
//		transform.eulerAngles = new Vector3 (currentRotationYOffSet, transformEulerAngles.y, transformEulerAngles.z);
//		rotationOfCamera	= transform.rotation;
//
		//transform.position	= target.position + (rotationOfCamera * new Vector3 (0, 0, -distance));

		transform.position	=  target.position + (rotationOfCamera * new Vector3 (0, 0, -distance));
		transform.position=Vector3.Lerp(transform.position,new Vector3(target.transform.position.x,target.transform.position.y+distance,target.transform.position.z),Time.fixedDeltaTime*0.5f);

		transform.position	= new Vector3 (transform.position.x, currentHeight, transform.position.z);
		transform.LookAt (target);
	}
}
