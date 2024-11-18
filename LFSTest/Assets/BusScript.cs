using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusScript : MonoBehaviour {


	public bool canRotate = false;
	public bool backward = false;
	public GameObject[] Doors;

	public GameObject[] Wheels;
	// Use this for initialization
	void Start(){
		//OpenDoors ();
	}
 public	void OpenDoors () {
		float Door1Z = Doors [0].transform.position.z;
		float Door2Z= Doors [1].transform.position.z;
	//	iTween.MoveTo (Doors[0].gameObject,iTween.Hash("z",Door1Z-2));
	//	iTween.MoveTo (Doors[1].gameObject,iTween.Hash("z",Door2Z+2));

		iTween.RotateTo (Doors[0].gameObject,iTween.Hash("y",-90,"time",5));
		iTween.RotateTo (Doors[1].gameObject,iTween.Hash("y",90,"time",5));

	}

	public void CloseDoors(){
		iTween.RotateTo (Doors[0].gameObject,iTween.Hash("y",0,"time",5));
		iTween.RotateTo (Doors[1].gameObject,iTween.Hash("y",0,"time",5,"islocal",true));
	}
	
	// Update is called once per frame
	void Update () {
		if (canRotate) {
			if (backward) {
				Wheels[0].transform.Rotate (Vector3.right * -5);
				Wheels[1].transform.Rotate (Vector3.right * -5);
				Wheels[2].transform.Rotate (Vector3.right * -5);
				Wheels[3].transform.Rotate (Vector3.right * -5);
			} else {


				Wheels[0].transform.Rotate (Vector3.right * -5);
				Wheels[1].transform.Rotate (Vector3.right * -5);
				Wheels[2].transform.Rotate (Vector3.right * -5);
				Wheels[3].transform.Rotate (Vector3.right * -5);
			}

		}
	}
}
