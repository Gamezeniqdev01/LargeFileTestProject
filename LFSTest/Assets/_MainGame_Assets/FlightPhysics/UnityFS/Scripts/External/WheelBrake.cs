//

// UnityFS - Flight Simulation Toolkit. Copyright 2013 Chris Cheetham.
//

using UnityEngine;
using System.Collections;


[AddComponentMenu("UnityFS/External/Wheel Brake")]
[RequireComponent( typeof(WheelCollider) )]
public class WheelBrake : MonoBehaviour 
{
	public static WheelBrake myScript;

	public float BrakeTorque = 10000.0f;
	
	[HideInInspector]
	public InputController Controller = new InputController();
	
	private WheelCollider Wheel = null;

	public static bool Is_BreakPressing;
	
	// Use this for initialization
	void Start () 
	{
		myScript = this;
		Is_BreakPressing = false;

		Wheel = GetComponent<WheelCollider>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Brakes the attached wheel if key pressed.
		if ( null != Wheel )
		{
			if ( Controller.GetButton() )
			{
				Wheel.brakeTorque = BrakeTorque;
			}
			else
			{
				Wheel.brakeTorque = 0.0f;
			}
		}


		if( null != Wheel)
		{
			if(Is_BreakPressing)
			{
				Wheel.brakeTorque = BrakeTorque;
			}
			else
			{
				Wheel.brakeTorque = 0.0f;
			}
		}

	}

	public void Apply_Break()
	{
		Is_BreakPressing = true;
	}

	public void Remove_Break()
	{
		Is_BreakPressing = false;
	}
}
