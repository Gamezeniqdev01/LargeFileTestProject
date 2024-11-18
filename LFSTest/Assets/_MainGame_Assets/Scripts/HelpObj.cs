using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpObj : MonoBehaviour {
	public  bool Is_OnlyOnce=true;

	public bool Speedhelp=false;
	public bool WaitHelp=false;
	public bool CollectHelp=false;
	public bool CheckpointHelp=false;
	public bool landingOffhelp=false;
	// Use this for initialization
	void Start () {
		Is_OnlyOnce = true;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider Obj)
	{



		if(Obj.transform.tag=="Body" && Is_OnlyOnce && WaitHelp)
		{
			Is_OnlyOnce=false;

			HelpManager.myScript.OnWait_Help();


		}



		if(Obj.transform.tag=="Body" && Is_OnlyOnce && CollectHelp)
		{
			Is_OnlyOnce=false;

			HelpManager.myScript.OnCollect_Help();


		}



		if(Obj.transform.tag=="Body" && Is_OnlyOnce && CheckpointHelp)
		{
			Is_OnlyOnce=false;
			Debug.Log ("comingtimes");
			HelpManager.myScript.OnCheckPoint_help();
			this.gameObject.transform.GetComponent<Renderer>().enabled=false;

		}


		if(Obj.transform.tag=="Body" && Is_OnlyOnce && Speedhelp)
		{
			Is_OnlyOnce=false;
			Debug.Log ("comingtimes");
			HelpManager.myScript.OnLanding_Help();
			this.gameObject.transform.GetComponent<Renderer>().enabled=false;

		}


		if(Obj.transform.tag=="Body" && Is_OnlyOnce && landingOffhelp)
		{
			Is_OnlyOnce=false;
			Debug.Log ("comingtimes");
			HelpManager.myScript.OFFLanding_Help();
			this.gameObject.transform.GetComponent<Renderer>().enabled=false;

		}

		else if(Obj.transform.tag=="Body" && Is_OnlyOnce)
		{
			Is_OnlyOnce=false;
			Debug.Log ("comingtimes");
			HelpManager.myScript.On_Tilt ();
			this.gameObject.transform.GetComponent<Renderer>().enabled=false;

		}
	}
}
