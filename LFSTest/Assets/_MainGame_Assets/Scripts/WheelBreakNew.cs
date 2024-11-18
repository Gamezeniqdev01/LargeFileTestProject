using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WheelBreakNew : MonoBehaviour 
{
	public static WheelBreakNew myScript;

	public float BrakeTorque = 10000.0f;
	public WheelCollider Wheel = null;
	public static bool Is_BreakPressing;
	
	void Awake()
	{
		myScript=this;
	}

	void Start () 
	{
		Is_BreakPressing = false;
		
		Wheel = GetComponent<WheelCollider>();
	}
	
	void Update () 
	{
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
