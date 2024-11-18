using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Hints : MonoBehaviour 
{
	public static Hints myScript;
	public Text Text_Hint;
	public string[] HintsText;
	
	void Awake()
	{
		myScript=this;
	}

	void Start () 
	{
		SetHint ();
	}
	
	void Update () 
	{
	
	}

	void SetHint()
	{
		Text_Hint.text = "" + HintsText [Random.Range (0,HintsText.Length)];
	}
}
