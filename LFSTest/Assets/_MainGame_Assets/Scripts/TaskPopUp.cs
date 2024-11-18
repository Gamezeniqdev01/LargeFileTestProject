using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TaskPopUp : MonoBehaviour 
{
	public static TaskPopUp myScript;

	public GameObject TaskAlpha;
	public GameObject TaskPanel;
	public GameObject Ttl_Task;
	public GameObject Text_Task;
	public GameObject Btn_Start;

	public GameObject Text_TaskShow,Text_Star1,Text_Star2,Text_Star3;
	
	void Awake()
	{
		myScript=this;
	}

	void Start () 
	{
		Task_In ();
	}
	
	void Update () 
	{
	
	}

	public void Task_In()
	{
		TaskAlpha.GetComponent<AlphaScript> ().AlphFade ();
		TaskPanel.GetComponent<AlphaScript> ().AlphFade ();
		Ttl_Task.GetComponent<AlphaScript> ().AlphFade ();
		Text_Task.GetComponent<AlphaScript> ().AlphFade ();
		Btn_Start.GetComponent<AlphaScript> ().AlphFade ();
		Text_TaskShow.GetComponent<AlphaScript> ().AlphFade ();
		Text_Star1.GetComponent<AlphaScript> ().AlphFade ();
		Text_Star2.GetComponent<AlphaScript> ().AlphFade ();
		Text_Star3.GetComponent<AlphaScript> ().AlphFade ();
	
		int index = LevelManager.myScript.Selected_Level - 1;

	


		if (PlayerPrefs.GetInt ("Training") <= 2) {
			Text_TaskShow.GetComponent<Text> ().text = "" +LevelManager.myScript.HelpTask [index];
			Text_Star1.GetComponent<Text> ().text = ""+500;
		} else {

			Text_TaskShow.GetComponent<Text> ().text = "" + LevelManager.myScript.LevelTask [index];

		//arj	Text_Star1.GetComponent<Text> ().text = ""+(int)LevelManager.myScript._LFULLDATA.LevelReward;
		}
		//Text_Star1.GetComponent<Text> ().text = ""+(int)LevelManager.myScript.StarValues [index].x;

		//Text_Star2.GetComponent<Text> ().text = ""+(int)LevelManager.myScript.StarValues [index].y;
		//Text_Star3.GetComponent<Text> ().text = ""+(int)LevelManager.myScript.StarValues [index].z;
	}

	public void Task_0ut()
	{
		TaskPanel.gameObject.SetActive (false);
		TaskAlpha.gameObject.SetActive (false);
	}
}

