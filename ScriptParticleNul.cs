using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptParticleNul : MonoBehaviour {

	public ParticleSystem herb;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		PlatformerMotor2D platf = gameObject.GetComponent<PlatformerMotor2D> (); 

		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			herb.Play ();
			gameObject.transform.rotation = new Quaternion (0, 0, 0, 0);
	    }

		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			herb.Play ();
			gameObject.transform.rotation = new Quaternion (0, 180, 0, 0);
		}

		if (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown (KeyCode.Keypad0)) {
			herb.Clear ();
			herb.Pause ();

		}



}
}