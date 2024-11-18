using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

	Vector3 angle ;
	// Use this for initialization
	void Start () {
		angle = transform.eulerAngles ;
		iTween.ValueTo (gameObject, iTween.Hash ("from", angle.z, "to", angle.z-360, "time", 15, "easetype", iTween.EaseType.linear, "onupdate", "RotateAmount"));
	}

	void RotateAmount (float currentVal)
	{
		//Debug.Log ("CurVal" + currentVal);
		angle.z = currentVal;
		transform.eulerAngles = angle;
	}
}
