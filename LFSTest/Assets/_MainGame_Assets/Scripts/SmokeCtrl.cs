using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SmokeCtrl : MonoBehaviour 
{
	public static SmokeCtrl myScript;

	public GameObject SmokeObj;
	
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

	public void OnSmoke()
	{
		SmokeObj.gameObject.SetActive (true);
	}
	public void OffSmoke()
	{
		SmokeObj.gameObject.SetActive (false);
	}
}
