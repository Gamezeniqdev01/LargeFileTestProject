using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Sound_RS : MonoBehaviour 
{
	public static Sound_RS myScript;

	public Image SoundBtn;
	public Sprite Sound_Off_Texture;
	public Sprite Sound_On_Texture;

	[HideInInspector]
	public string SoundS;

	public string Prefs_String;
	public Text Text_Sound;
	public string Text_Sound_On;
	public string Text_Sound_Off;

	void Awake()
	{
		myScript=this;
		if(PlayerPrefs.HasKey(Prefs_String) == false)
		{
			PlayerPrefs.SetString(Prefs_String,"true");
		}
	}

	void Start () 
	{
		SoundS = PlayerPrefs.GetString(Prefs_String);

		if(SoundS=="false")
		{
			SoundBtn.GetComponent<Image>().sprite=Sound_Off_Texture;
			AudioListener.volume=0;
			Text_Sound.text=""+Text_Sound_Off;
        }
		else
		{
			SoundBtn.GetComponent<Image>().sprite=Sound_On_Texture;
			AudioListener.volume=1;
			Text_Sound.text=""+Text_Sound_On;
        }
	}
	

	void Update () 
	{
	}
	
	public void CheckSound()
	{
		if(SoundS=="true")
		{
			PlayerPrefs.SetString(Prefs_String,"false");
			SoundS = PlayerPrefs.GetString(Prefs_String);
			SoundBtn.GetComponent<Image>().sprite=Sound_Off_Texture;
			AudioListener.volume=0;
			Text_Sound.text=""+Text_Sound_Off;
			print("Off");
		}
		else
			if(SoundS=="false")
		{
			PlayerPrefs.SetString(Prefs_String,"true");
			SoundS = PlayerPrefs.GetString(Prefs_String);
			SoundBtn.GetComponent<Image>().sprite=Sound_On_Texture;
			AudioListener.volume=1;
			Text_Sound.text=""+Text_Sound_On;
			print("On");
		}
	}
}
