using UnityEngine;
using System.Collections;

public class rotateComponent : MonoBehaviour {
	public float xx;
	public float yy;
	public float zz;
	public float speed;
	// Use this for initialization
	void Start () {
		xx=xx*speed*Time.deltaTime;
		yy=yy*speed*Time.deltaTime;
		zz=zz*speed*Time.deltaTime;

	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(xx,yy,zz);
	}
}
