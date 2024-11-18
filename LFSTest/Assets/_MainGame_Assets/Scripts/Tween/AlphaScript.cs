using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AlphaScript : MonoBehaviour 
{		
	public static AlphaScript myScript;

	public bool IsText;
	public Color _textColor = Color.white;

	public float AlphaValue;
	public float TimeInSec;
	public float Delay;
	public bool IsOnStart;
	public bool IsNeedImageFalse;

	void Awake () 
	{
		myScript=this;
	}
	
	void Start () 
	{
		if(IsOnStart)
		AlphFade();
	}
	


	public void AlphFade()
	{
		if (IsText) 
		{
			_textColor	= _textColor;
			
			iTween.ValueTo (this.gameObject, iTween.Hash ("from", this.gameObject.GetComponent<Text> ().color.a, "to", AlphaValue, "time", TimeInSec, "delay", Delay, "easetype", iTween.EaseType.linear, "onupdate", "TextFade", "oncomplete", "OnTextFadeComplete", "oncompletetarget", this.gameObject));
		} 
		else 
		{
			iTween.ValueTo (this.gameObject, iTween.Hash ("from", this.gameObject.GetComponent<Image> ().color.a, "to", AlphaValue, "time", TimeInSec, "delay", Delay, "easetype", iTween.EaseType.linear, "onupdate", "SpriteFade", "oncomplete", "OnSpriteFadeComplete", "oncompletetarget", this.gameObject));
		}
	}

	public void TextFade (float value)
	{
		this.gameObject.GetComponent<Text> ().color = new Color (this.gameObject.GetComponent<Text> ().color.r, this.gameObject.GetComponent<Text> ().color.g, this.gameObject.GetComponent<Text> ().color.b, value);
	}
	public void OnTextFadeComplete ()
	{
		this.gameObject.GetComponent<Text> ().color = new Color (this.gameObject.GetComponent<Text> ().color.r, this.gameObject.GetComponent<Text> ().color.g, this.gameObject.GetComponent<Text> ().color.b, AlphaValue);
	}
	public void SpriteFade (float value)
	{
		this.gameObject.GetComponent<Image> ().color = new Color (this.gameObject.GetComponent<Image> ().color.r, this.gameObject.GetComponent<Image> ().color.g, this.gameObject.GetComponent<Image> ().color.b, value);
	}
	public void OnSpriteFadeComplete ()
	{
		if(IsNeedImageFalse)
		{
			this.gameObject.SetActive(false);
		}
		this.gameObject.GetComponent<Image> ().color = new Color (this.gameObject.GetComponent<Image> ().color.r, this.gameObject.GetComponent<Image> ().color.g, this.gameObject.GetComponent<Image> ().color.b, AlphaValue);
	}
}
