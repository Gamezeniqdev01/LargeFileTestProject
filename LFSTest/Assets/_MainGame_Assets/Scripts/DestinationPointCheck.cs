using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DestinationPointCheck : MonoBehaviour 
{
	public static DestinationPointCheck myScript;
//	[HideInInspector]
	public bool Is_OnlyOnce;

	public bool CheckWithStay=false;


	public bool ISMidDestination=false;
	
	void Awake()
	{
		myScript=this;
	}

	void Start () 
	{
		Is_OnlyOnce = true;
	}
	
	void Update () 
	{
	
	}

	void OnTriggerEnter(Collider Obj)
	{
		if(Obj.transform.tag=="Body" && Is_OnlyOnce && ISMidDestination){
			
			Is_OnlyOnce=false;
			this.gameObject.transform.GetComponent<MapMarker>().enabled=false;
			MidStationHandler.NextStation = this.name;
			LevelManager.myScript.MidDestination_check();

			this.transform.parent.gameObject.SetActive (false);


		}
		else if(Obj.transform.tag=="Body" && Is_OnlyOnce && !CheckWithStay)
		{
			Is_OnlyOnce=false;
			this.gameObject.transform.GetComponent<MapMarker>().enabled=false;
			LevelManager.myScript.LevelComplete_Call();
			print("Level Checking From Here");
		}
	}

	void OnTriggerStay(Collider Obj)
	{
		if (Obj.transform.tag == "Body" && CheckWithStay && (int)UnityStandardAssets.Vehicles.Aeroplane.AeroplaneController.myScript.ForwardSpeed==0) {
			Debug.Log ("speed of body "+(int)UnityStandardAssets.Vehicles.Aeroplane.AeroplaneController.myScript.ForwardSpeed);
			this.gameObject.transform.GetComponent<MapMarker>().enabled=false;
			LevelManager.myScript.LevelComplete_Call();
		}
	}
}
