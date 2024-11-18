using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AxisCheck : MonoBehaviour 
{
	public static AxisCheck myScript;
	
	public bool Is_Vertical;
	public bool Is_Horizontal;

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
}
