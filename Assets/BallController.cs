using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour {

	public float speed = 20.0f;
	private Rigidbody rb;
	private AudioSource audioSorce;
	public AudioClip ballStart;
	public AudioClip goalSound;
	public GameObject goalText;
	public GameObject ownGoalText;
	private int currentSceneIndex;

	// Use this for initialization
	void Start () {
		this.rb = GetComponent<Rigidbody> ();
		audioSorce = GetComponent<AudioSource> ();
		goalText = GameObject.Find ("GoalText");
		ownGoalText = GameObject.Find ("OwnGoalText");
		currentSceneIndex = SceneManager.GetActiveScene ().buildIndex;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			rb.AddForce (transform.forward * speed, ForceMode.VelocityChange);
			audioSorce.PlayOneShot (ballStart);
		}

		if (Input.GetKey (KeyCode.LeftCommand)) {
			transform.Rotate (0, -1, 0);
		}

		if (Input.GetKey (KeyCode.RightCommand)) {
			transform.Rotate (0, 1, 0);
		}
	}

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.tag == "TeamTag") {
			audioSorce.PlayOneShot (ballStart);
		}
		if (col.gameObject.tag == "GoalTag") {
			audioSorce.PlayOneShot (goalSound);
			goalText.GetComponent<Text> ().text = "Goal!";
		}
		if (col.gameObject.tag == "OwnGoalTag") {
			ownGoalText.GetComponent<Text> ().text = "OwnGoal";
			SceneManager.LoadScene (currentSceneIndex);
		}
		if (col.gameObject.tag == "BackStage") {
			SceneManager.LoadScene (currentSceneIndex);
		}
	}
}
