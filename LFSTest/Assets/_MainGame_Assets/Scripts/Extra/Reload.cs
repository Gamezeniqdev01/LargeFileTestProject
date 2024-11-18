using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Reload : MonoBehaviour 
{
	public static Reload myScript;
	
	void Awake()
	{
		myScript=this;
	}

	void Start () 
	{
	
	}
	
	public void Call_Reload () 
	{
		Application.LoadLevel (Application.loadedLevelName);
	}
}
