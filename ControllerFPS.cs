using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerFPS : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {
		

		GameObject g = GameObject.Find ("Ninja");
		PlatformerMotor2D pmotor = g.GetComponent<PlatformerMotor2D> ();
		float translation = Input.GetAxis ("Vertical") * pmotor.groundSpeed;
		float straffe = Input.GetAxis ("Horizontal") * pmotor.groundSpeed;

		translation *= Time.deltaTime;
		straffe *= Time.deltaTime;
		transform.Translate (straffe, 0, translation);
		if (Input.GetKeyDown ("escape"))
			Cursor.lockState = CursorLockMode.None;
	}
}
