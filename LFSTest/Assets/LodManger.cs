using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LodManger : MonoBehaviour {


	public GameObject TopOBJ;
	public GameObject SecondObj;


	public GameObject MainObjCam;

	public GameObject MainObj;

	public List<GameObject> TopLayerObjects= new List<GameObject>();
	public List<GameObject> SecondLayerObjects= new List<GameObject>();


	// Use this for initialization
	void StartA () {
		for(int i=0;i<MainObj.transform.childCount;i++){
			Transform bb = MainObj.transform.GetChild (i);
			Debug.Log (bb);
			TopLayerObjects.Add (bb.gameObject);
			bb.transform.parent = TopOBJ.transform;



			 if (bb.childCount == 0) {
				TopLayerObjects [i].name = "NoChild";
				GameObject newEmptyObj = new GameObject ();
				SecondLayerObjects.Add (newEmptyObj);
			}

			else if(bb.childCount>=1){

				for(int j=0;j<bb.childCount;j++){
					Debug.Log ("second "+ bb.GetChild(j));
					TopLayerObjects [i].name = "HadChild";

					GameObject cc = bb.GetChild(j).gameObject;

					SecondLayerObjects.Add (bb.GetChild(j).gameObject);

					cc.transform.parent = SecondObj.transform;
				}
			}


		}
	}
	
	// Update is called once per frame
	void Update () {
		if (MainObjCam.transform.position.y >= 500) {


		} else {
			
		}
	}
}
