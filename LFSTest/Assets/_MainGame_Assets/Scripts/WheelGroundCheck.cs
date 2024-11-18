using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WheelGroundCheck : MonoBehaviour 
{
	public static WheelGroundCheck myScript;
	public bool Is_OnGround;
	public string GroundName;
	
	void Awake()
	{
		myScript=this;
		Is_OnGround = false;
	}

	void Start () 
	{
	
	}


	void Update () 
	{
		var ray = new Ray(transform.position, -Vector3.up*10);
	//	Debug.DrawRay (transform.position, -Vector3.up*10,Color.red);
		RaycastHit hit;
		if (Physics.Raycast (ray,out hit))
		{
			//Debug.Log ("Distance "+hit.distance);
			if(hit.distance<=1 && (hit.transform.name.Contains("ControlPoint")))
			{
				print ("--- Coontrol Point Hit--- " + hit.transform.name);

			}


			if(hit.distance<=2 && (hit.transform.tag.Contains("Runway") || hit.transform.tag=="RunWay" || hit.transform.tag=="RunWayShip"))
			{
				GroundName=""+hit.transform.name;
//				print("FLight on RunWay");
				Is_OnGround=true;
			}
			else
			{
				Is_OnGround=false;
			}
		}
	}
}
