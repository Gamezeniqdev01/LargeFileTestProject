using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StarCount : MonoBehaviour 
{
	public static StarCount myScript;

	public bool ISStar=true;

	public bool Is_OnlyOnce;
	
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
		if(Obj.transform.tag=="Body" && Is_OnlyOnce  && ISStar)
		{
			Is_OnlyOnce=false;
			LevelManager.myScript.CollectedStars+=1;
			this.gameObject.transform.GetComponent<MapMarker> ().isActive = false;
			this.gameObject.transform.GetComponent<MapMarker>().enabled=false;
			this.gameObject.transform.GetComponent<Renderer>().enabled=false;
			print("Stars : "+LevelManager.myScript.CollectedStars);
			this.gameObject.SetActive (true);
		}else if(Obj.transform.tag=="Body" && Is_OnlyOnce ){
			Is_OnlyOnce=false;


			//if(Obj.gameObject.tag=="Airballon"){
				LevelManager.checkPointScore +=1;
			//}
			this.gameObject.transform.GetComponent<MapMarker> ().isActive = false;

			//this.gameObject.transform.GetComponent<MapMarker>().enabled=false;
			this.gameObject.transform.GetComponent<Renderer>().enabled=false;

			LevelManager.myScript.SavePointPos.position = this.transform.position;

			this.transform.parent.gameObject.GetComponent<CheckPlayerPos> ().enabled = false;
			this.transform.parent.gameObject.GetComponent<MeshCollider> ().enabled = false;

			//this.transform.parent.gameObject.SetActive (false);

		}
	}
}
