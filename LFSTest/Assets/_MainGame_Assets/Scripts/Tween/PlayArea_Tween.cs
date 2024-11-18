using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayArea_Tween : MonoBehaviour 
{
	public static PlayArea_Tween myScript;

	public GameObject[] PlayAreaObjs;
	
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


	public void PlayArea_In()
	{
		for(int i=0;i<PlayAreaObjs.Length;i++)
		{
			PlayAreaObjs[i].GetComponent<AlphaScript>().AlphaValue=1;
			PlayAreaObjs[i].GetComponent<AlphaScript>().TimeInSec=0.5f;
			PlayAreaObjs[i].GetComponent<AlphaScript>().AlphFade();
		}
	}
	public void PlayArea_Out()
	{
		for(int i=0;i<PlayAreaObjs.Length;i++)
		{
			PlayAreaObjs[i].GetComponent<AlphaScript>().AlphaValue=0;
			PlayAreaObjs[i].GetComponent<AlphaScript>().TimeInSec=0.5f;
			PlayAreaObjs[i].GetComponent<AlphaScript>().AlphFade();
		}
	}
}
