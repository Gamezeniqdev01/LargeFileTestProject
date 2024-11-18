using UnityEngine;
using System.Collections;

public class pingPongMove : MonoBehaviour {

	
	public float speed = 1.5f;
	public float frictionFactor = .999f;
	public float factor = 1.0f;
	
	Vector3 qStart, qEnd;

	public Vector3 startPos;
	public Vector3 endPos;
	public bool isTriggerControled;

	public GameObject MoveObj;

	public 
	// Use this for initialization
	void Start () {
		qStart = transform.position + startPos;

		qEnd = transform.position + endPos;
	}

	void OnCollisionEnter(Collision colis){
//		if (colis.gameObject.name == "front wheel" || colis.gameObject.name == "rear wheel") {
//				isTriggerControled = false;
//		}

	}
	// Update is called once per frame
	void Update () {
		if (!isTriggerControled) {
			//print ("can move now");
			transform.position = Vector3.Lerp (qStart, qEnd, (Mathf.Sin (Time.time * speed) * factor + 1.0f) / 2.0f);
			}
	}
}
