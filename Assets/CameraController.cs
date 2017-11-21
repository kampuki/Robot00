using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	private Camera MainCam;
	private Camera SecondCam;
	private Camera ThirdCam;
	private float ZPos;


	// Use this for initialization
	void Start () {
		MainCam = GameObject.Find ("Main Camera").GetComponent<Camera> ();
		SecondCam = GameObject.Find ("Second Camera").GetComponent<Camera> ();
		ThirdCam = GameObject.Find ("Third Camera").GetComponent<Camera> ();
		SecondCam.enabled = false;
		ThirdCam.enabled = false;
		ZPos = GameObject.Find ("Ball").transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			if (MainCam.enabled) {
				if (ZPos > 0) {
					MainCam.enabled = false;
					SecondCam.enabled = true;
					ThirdCam.enabled = false;
				} else {
					MainCam.enabled = false;
					SecondCam.enabled = false;
					ThirdCam.enabled = true;
				}
			}
					
		}
	}
}
