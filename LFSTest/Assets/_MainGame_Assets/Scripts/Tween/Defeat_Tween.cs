using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Defeat_Tween : MonoBehaviour 
{
	public static Defeat_Tween myScript;

	public GameObject Page_Wrecked;
	
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

	public void Wrecked_In()
	{
	//	Camera.main.GetComponent<CameraFilterPack_Blur_Noise> ().enabled = true;
	}
}
