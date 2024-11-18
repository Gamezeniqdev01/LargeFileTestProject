using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomOpner : MonoBehaviour {

	public GameObject[] MyBuses;
	public Transform TargetToMove;
	public GameObject CamObj;

	public FollowCameraBus FObj;

	public GameObject MainCam;
	public GameObject MainCamPiovt;

	public AlphaScript AlphaObj;
	public GameObject[] AllChars;
	private int randomm;

	public static RandomOpner mee;
	// Use this for initialization
	void Start () {
		mee = this;
		randomm = Random.Range (0,MyBuses.Length);
	
		MyBuses [randomm].SetActive (true);
		CamObj.transform.parent = MyBuses [randomm].transform;


	}
	private Coroutine myroutine;
	public void StartBus(){


		MyBuses [randomm].transform.localPosition = Vector3.zero;
		#if FULLINTRO_yes
		iTween.MoveTo (MyBuses [randomm].gameObject,iTween.Hash("position",TargetToMove.transform.position,"delay",1,"time",5,"easetype",iTween.EaseType.linear));
		#endif

		myroutine=StartCoroutine (OpenDoors(MyBuses [randomm].gameObject));


	}

			public  void StopIt(){
		StopCoroutine (myroutine);
			}
	private Vector3 P1Pos,p2pos,p3pos,p4pos,p5pos,p6pos;
	IEnumerator OpenDoors(GameObject aa){
		#if FULLINTRO_yes
		yield return new WaitForSeconds (1);
		aa.GetComponent<BusScript> ().canRotate = true;
		aa.GetComponent<BusScript> ().backward = true;

		yield return new WaitForSeconds (5);
		aa.GetComponent<BusScript> ().canRotate = false;
		aa.GetComponent<BusScript> ().backward = true;
		aa.GetComponent<BusScript> ().OpenDoors ();
		yield return new WaitForSeconds (1);



		P1Pos = AllChars [0].transform.localPosition;
		AllChars [0].GetComponent<CharacterAnimSelector> ().walk = true;
		AllChars [0].GetComponent<CharacterAnimSelector> ().ChangeState ();
		iTween.MoveTo (AllChars [0].gameObject,iTween.Hash("position",aa.transform.GetChild(0).transform.position,"delay",0.5,"time",2,"easetype",iTween.EaseType.linear));

		yield return new WaitForSeconds (0.5f);
		p2pos = AllChars [1].transform.localPosition;
		AllChars [1].GetComponent<CharacterAnimSelector> ().walk = true;
		AllChars [1].GetComponent<CharacterAnimSelector> ().ChangeState ();
		iTween.MoveTo (AllChars [1].gameObject,iTween.Hash("position",aa.transform.GetChild(0).transform.position,"delay",0.5,"time",2,"easetype",iTween.EaseType.linear));

		yield return new WaitForSeconds (0.5f);
		p3pos = AllChars [2].transform.localPosition;

		AllChars [2].GetComponent<CharacterAnimSelector> ().walk = true;
		AllChars [2].GetComponent<CharacterAnimSelector> ().ChangeState ();
		iTween.MoveTo (AllChars [2].gameObject,iTween.Hash("position",aa.transform.GetChild(0).transform.position,"delay",0.5,"time",2,"easetype",iTween.EaseType.linear));
		yield return new WaitForSeconds (0.5f);
		p4pos = AllChars [3].transform.localPosition;

		AllChars [3].GetComponent<CharacterAnimSelector> ().walk = true;
		AllChars [3].GetComponent<CharacterAnimSelector> ().ChangeState ();
		iTween.MoveTo (AllChars [3].gameObject,iTween.Hash("position",aa.transform.GetChild(0).transform.position,"delay",0.5,"time",2,"easetype",iTween.EaseType.linear));
		yield return new WaitForSeconds (0.5f);
		p5pos = AllChars [4].transform.localPosition;

		AllChars [4].GetComponent<CharacterAnimSelector> ().walk = true;
		AllChars [4].GetComponent<CharacterAnimSelector> ().ChangeState ();
		iTween.MoveTo (AllChars [4].gameObject,iTween.Hash("position",aa.transform.GetChild(0).transform.position,"delay",0.5,"time",2,"easetype",iTween.EaseType.linear));

		yield return new WaitForSeconds (0.5f);
		p6pos = AllChars [5].transform.localPosition;

		AllChars [5].GetComponent<CharacterAnimSelector> ().walk = true;
		AllChars [5].GetComponent<CharacterAnimSelector> ().ChangeState ();
		iTween.MoveTo (AllChars [5].gameObject,iTween.Hash("position",aa.transform.GetChild(0).transform.position,"delay",0.5,"time",2,"easetype",iTween.EaseType.linear));

		yield return new WaitForSeconds (1.5f);

//		AllChars [0].transform.localPosition=P1Pos;
//		AllChars [1].transform.localPosition=p2pos;
//		AllChars [2].transform.localPosition=p3pos;
//		AllChars [3].transform.localPosition=p4pos;
//		AllChars [4].transform.localPosition=p5pos;
//		AllChars [5].transform.localPosition=p6pos;

//		for(int i=0;i<AllChars.Length;i++){
//			//AllChars [i].transform.parent = aa.transform;
//			AllChars [i].gameObject.SetActive(false);
//			//Destroy (AllChars [i].gameObject);
//		}
		aa.GetComponent<BusScript> ().CloseDoors ();

		yield return new WaitForSeconds (2f);

		for(int i=0;i<AllChars.Length;i++){

			AllChars [i].gameObject.SetActive(false);

		}

				
		FObj.ChangeTarget ();


		aa.GetComponent<BusScript> ().canRotate = true;
		aa.GetComponent<BusScript> ().backward = false;
		iTween.MoveTo (aa.gameObject,iTween.Hash("z",TargetToMove.transform.position.z+30,"delay",0,"time",3,"easetype",iTween.EaseType.linear,"name","vhmove"));


		yield return new WaitForSeconds (3f);
		#endif
		FObj.ChangeTarget ();
		AlphaObj.AlphaValue=1f;
		AlphaObj.TimeInSec=0.01f;
		AlphaObj.AlphFade ();

		yield return new WaitForSeconds (0.5f);

		AlphaObj.AlphaValue=0;
		AlphaObj.TimeInSec=0.5f;

		AlphaObj.AlphFade ();

	


		aa.transform.position = new Vector3 (LevelManager.myScript.Flights [LevelManager.myScript.Selected_Flight - 1].gameObject.transform.position.x,aa.transform.position.y,LevelManager.myScript.Flights [LevelManager.myScript.Selected_Flight - 1].gameObject.transform.position.z-100);


		iTween.MoveTo (aa.gameObject,iTween.Hash("z",aa.transform.position.z+60,"delay",0.5f,"time",6,"easetype",iTween.EaseType.linear,"name","vhmove"));


		yield return new WaitForSeconds (6f);

		AlphaObj.AlphaValue=1f;
		AlphaObj.TimeInSec=0.5f;
		AlphaObj.AlphFade ();

		yield return new WaitForSeconds (1f);

		aa.GetComponent<BusScript> ().canRotate = false;
		aa.GetComponent<BusScript> ().backward = false;

		AlphaObj.AlphaValue=0;
		AlphaObj.TimeInSec=0.5f;

		AlphaObj.AlphFade ();

		FObj.gameObject.SetActive (false);
		MainCam.SetActive (true);

		if (LevelManager.ISDestinTemp == false) {
			LevelManager.myScript.AssignLevelTask ();
		} else {
			LevelManager.myScript.StartPlane ();

		}

		yield return new WaitForSeconds (1.5f);

		for(int i=0;i<AllChars.Length;i++){
			//AllChars [i].transform.parent = aa.transform;
			AllChars [i].gameObject.SetActive(true);
			//Destroy (AllChars [i].gameObject);

			AllChars [i].GetComponent<CharacterAnimSelector> ().walk = false;
			AllChars [i].GetComponent<CharacterAnimSelector> ().ChangeState ();
		}




		AllChars [0].transform.localPosition=P1Pos;
		AllChars [1].transform.localPosition=p2pos;
		AllChars [2].transform.localPosition=p3pos;
		AllChars [3].transform.localPosition=p4pos;
		AllChars [4].transform.localPosition=p5pos;
		AllChars [5].transform.localPosition=p6pos;




	}
	// Update is called once per frame
	void Update () {
		
	}
}
