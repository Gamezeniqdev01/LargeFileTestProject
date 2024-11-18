using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartCountryManger : MonoBehaviour {



	public static string DefaultCountry="";
	public static int StoredIndex=0;
	public Button[] SelectButtons;
	public Button ContinuE_btn;
	// Use this for initialization
	void Start () {

		ContinuE_btn.interactable = false;
		Color aa = Color.grey;
		aa.a = 0.8f;
		ContinuE_btn.transform.GetChild (0).GetComponent<Text> ().color = aa;


	}



	public void SelectCountry(GameObject Selct_obj){

		Color aa = Color.white;
		aa.a = 1f;


		Color bb = Color.green;
		bb.a = 0.8f;


		Color cc = Color.white;
		cc.a = 0.8f;

		for(int i=0;i<SelectButtons.Length;i++){
			SelectButtons [i].interactable = true;
			SelectButtons [i].transform.parent.GetComponent<Image> ().color = cc;
			SelectButtons [i].transform.GetChild (0).GetComponent<Text> ().color = aa;


		}

		ContinuE_btn.interactable = true;
		Selct_obj.GetComponent<Button> ().interactable = false;

		Selct_obj.transform.parent.GetComponent<Image> ().color = bb;

		aa = Color.grey;
		aa.a = 0.8f;
		Selct_obj.transform.GetChild (0).GetComponent<Text> ().color = aa;
		ContinuE_btn.transform.GetChild (0).GetComponent<Text> ().color = cc;



		DefaultCountry = Selct_obj.transform.parent.GetChild(0).GetComponent<Text> ().text;
		StoredIndex = int.Parse (Selct_obj.transform.parent.name);

		Debug.Log (StoredIndex+" selected country "+DefaultCountry);


	}
	// Update is called once per frame
	void Update () {
		
	}
}
