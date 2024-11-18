using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RudderControls : MonoBehaviour 
{
	public static RudderControls myScript;

	public Slider RudderSlider;

	public float ResetTime=0.25f;

	public float RudderValue;
	
	void Awake()
	{
		myScript=this;
		RudderSlider.value = 1;

	}

	void Start () 
	{
//		Invoke ("FixRudderValue", 5);
	}
	
	void Update () 
	{
		RudderValue = RudderSlider.value - 1f;
		print ("Rudder Value : " + RudderValue);

	}

	public void SliderDown()
	{

	}
	public void SliderUp()
	{
		FixRudderValue ();
	}

	public void FixRudderValue()
	{
		iTween.ValueTo (this.gameObject, iTween.Hash ("from",RudderSlider.value , "to", 1, "time",ResetTime, "delay", 0, "easetype", iTween.EaseType.linear, "onupdate", "SetRudderPos", "oncomplete", "OnSpriteFadeComplete", "oncompletetarget", this.gameObject));
	}

	public void SetRudderPos(float Value)
	{
		RudderSlider.value = Value;
	}
}
