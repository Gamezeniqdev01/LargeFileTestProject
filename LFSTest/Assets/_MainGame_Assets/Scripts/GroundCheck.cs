using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets;

public class GroundCheck : MonoBehaviour 
{
	public static GroundCheck myScript;

	public GameObject[] Engines;
	public GameObject CamRig;
	public GameObject Model;
	public GameObject ModelBlast;


	
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

	public bool Is_OnlyOnce;
	public void ContinuePlay(){



		LevelManager.MyPlayer.transform.position = LevelManager.myScript.SavePointPos.position;

		//LevelManager.myScript.Invoke ("StartPlane",0.5f);

		Time.timeScale = 1;
		Is_OnlyOnce=false;


		Model.transform.parent.gameObject.SetActive(true);
		ModelBlast.transform.parent = Model.transform;
		ModelBlast.gameObject.SetActive(false);
	}
	void OnCollisionEnter(Collision Obj)
	{
		Debug.Log(Obj.gameObject.tag+" hit "+UnityStandardAssets.Vehicles.Aeroplane.AeroplaneController.myScript.ForwardSpeed);
		if(Obj.gameObject.tag=="Ground" || Obj.gameObject.tag=="RunWay" || Obj.gameObject.tag=="Water" || Obj.gameObject.tag=="Objects" ||
			Obj.gameObject.tag=="Rocks" || Obj.gameObject.tag=="RunWayShip"  || Obj.gameObject.tag=="Airballon" || Obj.gameObject.tag=="SecondHit"|| Obj.gameObject.tag=="Walls" || Obj.gameObject.tag=="Fan")
		{
			if(UnityStandardAssets.Vehicles.Aeroplane.AeroplaneController.myScript.ForwardSpeed>15 && !Is_OnlyOnce)
			{
				if (GameManager.myScript.MyGameState == GameManager.GameState.AtInGame) {



					Is_OnlyOnce = true;

					ModelBlast.transform.parent=null;
					ModelBlast.gameObject.SetActive (true);
					Model.transform.parent.gameObject.SetActive (false);
					if (SoundsManager.myScript != null) {
						SoundsManager.myScript.Sound_Blast.GetComponent<AudioSource> ().Play ();
					}

				

					GameManager.myScript.Invoke("Call_CrashLife",0.3f);

					/*
					GameManager.myScript.MyGameState=GameManager.GameState.AtLevelF;
				
					ModelBlast.transform.parent=null;
					ModelBlast.gameObject.SetActive(true);
					Model.transform.parent.gameObject.SetActive(false);
					Model.transform.parent.GetComponent<Rigidbody>().drag=10;
					OrbitCamY();
					Invoke("SetOrbitCam",1);
					PlayArea_Tween.myScript.PlayArea_Out();
					print("Level Fail Blast "+Obj.gameObject.name);
					if(SoundsManager.myScript!=null)
					{
						SoundsManager.myScript.Sound_Blast.GetComponent<AudioSource>().Play();
					}
					*/
				}
			}
		}
	}

	public void OrbitCamY()
	{
		iTween.ValueTo (this.gameObject, iTween.Hash ("from",OrbitCam.myScript.CameraYOffset , "to", 50, "time",1, "delay", 0, "easetype", iTween.EaseType.linear, "onupdate", "SetOrbitCamY", "oncomplete", "SetOrbitCam", "oncompletetarget", this.gameObject));
	}
	
	public void SetOrbitCamY(float Value)
	{
		OrbitCam.myScript.CameraYOffset = Value;
	}

	public void SetOrbitCam()
	{
		OrbitCam.myScript.SetCameraActive(false);
		LevelManager.myScript.Defeat_In ();
	}
}
