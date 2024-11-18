using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class BreakLogic : MonoBehaviour 
{
	public static BreakLogic myScript;

	[HideInInspector]
	public bool Is_Breaks,Is_LandGears;
	public GameObject Btn_Gear,Btn_Breaks;
	public Sprite Sprite_BreaksOn,Sprite_BreaksOff;

	void Awake()
	{
		myScript=this;
	}

	void Start () 
	{
	
	}
	public InputAxisScrollbar ThrotleStickGo;
	void Update () 
	{
		if (Is_Breaks) {
			ThrotleStickGo.HandleInput (0);

			ThrotleStickGo.gameObject.GetComponent<Scrollbar> ().value = 0;
		}
	}

	public void Call_Break()
	{
		if (!Is_Breaks) 
		{
			Btn_Breaks.GetComponent<Image> ().sprite = Sprite_BreaksOn;
//			UnityStandardAssets.CrossPlatformInput.ButtonHandler.myScript.SetAxisPositiveState();
			WheelBreakNew.myScript.Apply_Break ();
			
			print ("Break Down");
			Is_Breaks=true;
		}
		else
		{
			Btn_Breaks.GetComponent<Image> ().sprite = Sprite_BreaksOff;
//			UnityStandardAssets.CrossPlatformInput.ButtonHandler.myScript.SetAxisNegativeState();
			WheelBreakNew.myScript.Remove_Break ();
			print("Break Up");
			Is_Breaks=false;
		}
	}
}
