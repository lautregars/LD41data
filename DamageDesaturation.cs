using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class DamageDesaturation : MonoBehaviour {
	private float lifePlayer;
	public GameObject playerG;
	public GameObject MainCam;

	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {
		GameObject g = GameObject.Find ("Ninja");
		LeNinja leninja = g.GetComponent<LeNinja> ();



	}
}
