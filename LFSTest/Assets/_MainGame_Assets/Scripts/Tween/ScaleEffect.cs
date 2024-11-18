using UnityEngine;
using System.Collections;

public class ScaleEffect : MonoBehaviour {

	public bool Is_Rotate;
	public bool Is_Scale;
	public float _val;
	public float _time;
    public float Delayy;
	void Start () 
	{
		if (Is_Rotate) 
		{
			iTween.RotateTo (this.gameObject, iTween.Hash ("y", 60, "time", 02, "delay", Delayy, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.pingPong));
		}
		else if(Is_Scale)
		{
			iTween.ScaleTo(this.gameObject, iTween.Hash ("x",_val,"y",_val,"z", _val, "time", _time, "delay", Delayy, "islocal",true,"easetype", iTween.EaseType.easeOutSine, "looptype", iTween.LoopType.pingPong));
		}
	}
	

	void Update () 
	{
		
	}
}
