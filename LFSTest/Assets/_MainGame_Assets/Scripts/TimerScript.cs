using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour 
{		
	public static TimerScript myScript;

	public float TimerTimeInSec;
	private int min=0;
	private int sec=0;
	public Text Text_Time;
	public float ElapsedTime;
	public bool Is_Stop;

	void Awake () 
	{
		myScript=this;
	}
	
	void Start () 
	{
	
	}

	public void AddTime(){

	}
	
	void Update () 
	{
		if(!Is_Stop)
		{
			if (GameManager.myScript.MyGameState == GameManager.GameState.AtInGame) 
			{
				if (TimerTimeInSec > 0) 
				{
					TimerTimeInSec -= Time.deltaTime;
					min = Mathf.CeilToInt (TimerTimeInSec) / 60;
					sec = Mathf.CeilToInt (TimerTimeInSec) % 60;
					Text_Time.text = "" + min.ToString ("00") + ":" + sec.ToString ("00");
					if (TimerTimeInSec < 5) 
					{
						Text_Time.color = Color.red;
					}
					else
						Text_Time.color = Color.white;
				}
				else 
				{
					if (TimerTimeInSec <= 0) 
					{
						if (GameManager.myScript.MyGameState == GameManager.GameState.AtInGame) 
						{
//							print ("Level Fail Timer && Add Life PopUp");    // Harish
							GameManager.myScript.Call_AddLife();
//							GameManager.myScript.MyGameState = GameManager.GameState.AtLevelF;
//							PlayArea_Tween.myScript.PlayArea_Out();
//
//							GroundCheck.myScript.OrbitCamY();

						}
					}
				}
			} 
			else
			{
				ElapsedTime=(int)(LevelManager.myScript.LevelTime[LevelManager.myScript.Selected_Level-1]-TimerTimeInSec);
				Is_Stop=true;
			}
		}
	}
}
