using UnityEngine;
using System.Collections;

public class CaneraTumble : MonoBehaviour
{
	// Attach this script to you camera
	// This script should likely be used in conjunction with a CameraLookAt script in unity's standard assets.
	// Script created by Alexander MacLeod - 14th December 2013

	public float tumbleSensitivity = 0.3f;        //NB. This value should be adjusted until a natural result is achieved. It affects the amount the camera will tumble around the object as a swipe takes place.
	public Transform pivotPoint;                //this should be the location the camera tumbles around
	public bool naturalMotion = true;            //this determines whether a left swipe will make the camera tumble clockwise or anticlockwise around the object

	private GameObject camParent;                //this will be the rotating parent to which the camera is attached. Rotating this object will have the effect of making the camera a specified location.
	private Vector2 oldInputPosition;            //records the position of the finger last update

	void Start ()
	{
		
	}

	private bool StartRot = false;
	public  void startCamFun(){
		Transform originalParent = transform.parent;            //check if this camera already has a parent
		camParent = new GameObject ("camParent");                //create a new gameObject
		camParent.transform.position = pivotPoint.position;        //place the new gameObject at pivotPoint location
		transform.parent = camParent.transform;                    //make this camera a child of the new gameObject
		camParent.transform.parent = originalParent;            //make the new gameobject a child of the original camera parent if it had one


		//StartRot = true;
	}
	// Update is called once per frame
	void Update ()
	{
		//TOUCH
		if (StartRot) {

		if (Input.touchCount > 0) {
			foreach (Touch touch in Input.touches) {
				if (touch.phase == TouchPhase.Began && touch.fingerId == 0) {
					oldInputPosition = touch.position;
				}
				if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary) {
					if (touch.fingerId == 0) {
						float xDif = touch.position.x - oldInputPosition.x;    //this calculates the horizontal distance between the current finger location and the location last frame.
						if (!naturalMotion) {
							xDif *= -1;
						}
						if (xDif != 0) {
							camParent.transform.Rotate (Vector3.up * xDif * tumbleSensitivity);
						}
						oldInputPosition = touch.position;
					}
				}
				if (touch.phase == TouchPhase.Ended && touch.fingerId == 0) {
					oldInputPosition = touch.position;
				}
			}
		}

		//MOUSE

		if (Input.GetMouseButtonDown (0)) {
			oldInputPosition = Input.mousePosition;
		}
		if (Input.GetMouseButton (0)) {
			float xDif = Input.mousePosition.x - oldInputPosition.x;
			if (!naturalMotion) {
				xDif *= -1;
			}
			if (xDif != 0) {
				camParent.transform.Rotate (Vector3.up * xDif * tumbleSensitivity);
			}
			oldInputPosition = Input.mousePosition;
		}
		if (Input.GetMouseButtonUp (0)) {
			oldInputPosition = Input.mousePosition;
		}
	}
	}
}