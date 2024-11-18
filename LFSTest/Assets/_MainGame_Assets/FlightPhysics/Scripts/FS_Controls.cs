using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FS_Controls : MonoBehaviour 
{
	public static FS_Controls myScript;

	public GameObject Obj_Throttel;
	public Text TextA_Speed,Text_Speed,Text_Altitude;

	[HideInInspector]
	public float Value_Throttle,Value_Break;

	public GameObject Btn_Gear,Btn_Breaks;
	public Sprite Sprite_GearOn,Sprite_GearOff,Sprite_BreaksOn,Sprite_BreaksOff;

	[HideInInspector]
	public bool Is_Breaks,Is_LandGears;
	
	void Awake()
	{
		myScript=this;
	}

	void Start () 
	{
	
	}
	
	void Update () 
	{
		if(LevelManager.myScript.Is_LevelStarted)
		{
			GetThrottleValue ();
		//	TextA_Speed.text=""+Aircraft.myScript.KnotValue;
		//	Text_Speed.text=""+Aircraft.myScript.KnotValue+" knotA";
		//	Text_Altitude.text=""+Aircraft.myScript.AltitudeValue+" Bft";
		}
	}

	public void GetThrottleValue()
	{
		Value_Throttle = Obj_Throttel.GetComponent<Slider> ().value;
	}

	public void Set_Cam(int Value)
	{
		Aircraft.myScript.ChangeCamera ();
	}

	public void Call_LandGears()
	{
		if(Aircraft.myScript.AltitudeValue>10)
		{
			if(!Is_LandGears)
			{
				Btn_Gear.GetComponent<Image> ().sprite = Sprite_GearOn;
				Is_LandGears=true;
			}
			else
			{
				Btn_Gear.GetComponent<Image> ().sprite = Sprite_GearOff;
				Is_LandGears=false;
			}
			LandingGear.myScript.LandingGears ();
		}
	}

	public void Call_Break()
	{
		if (!Is_Breaks) 
		{
			Btn_Breaks.GetComponent<Image> ().sprite = Sprite_BreaksOn;
//			WheelBrake.myScript.Apply_Break ();

			print ("Break Down");
			Is_Breaks=true;
		}
		else
		{
			Btn_Breaks.GetComponent<Image> ().sprite = Sprite_BreaksOff;
//			WheelBrake.myScript.Remove_Break ();
			print("Break Up");
			Is_Breaks=false;
		}
	}
	public void Remove_Break()
	{
		Btn_Breaks.GetComponent<Image> ().sprite = Sprite_BreaksOff;
		WheelBrake.myScript.Remove_Break ();
		print("Break Up");
	}
}
