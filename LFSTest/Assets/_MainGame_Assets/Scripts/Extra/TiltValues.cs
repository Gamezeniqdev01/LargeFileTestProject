using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TiltValues : MonoBehaviour 
{
	public static TiltValues myScript;

	public Text Value_X;
	public Text Value_Y;
	
	void Awake()
	{
		myScript=this;
	}

	void Start () 
	{
	
	}
	
	void Update () 
	{
		Value_X.text = "Accel X : " + Input.acceleration.x;
		Value_Y.text = "Accel Y : " + ((Input.acceleration.y+0.5f));
	}
}
