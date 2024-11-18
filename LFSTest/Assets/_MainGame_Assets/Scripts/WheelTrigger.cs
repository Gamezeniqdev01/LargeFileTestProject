using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WheelTrigger : MonoBehaviour 
{
	public static WheelTrigger myScript;
	
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

	public void OnTriggerEnter(Collider Obj)
	{
		print("Coontrol Point Hit "+Obj.name);

		if(Obj.tag=="Ground")
		{
			print("Wheels on Ground");
		}

		if(Obj.name=="ControlPoint")
		{
			print("Coontrol Point Hit");
		}
	}
}
