using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour {

	public ParticleSystem boomfx;
	public ParticleSystem boomfxDeux;
	public GameObject Ninja;
	public float speed = 8.0f;
	public GameObject bullet;
	public Transform target;
	public float lifetime = 50;
	// Use this for initialization
	void Start () {
		




	}
	
	// Update is called once per frame
	void Update () {
		float step = speed * Time.deltaTime;
	
		lifetime -= 13 * Time.deltaTime;
		transform.position = Vector3.MoveTowards (transform.position,  GameObject.FindGameObjectWithTag("Player").transform.position, step);

		if (lifetime <= 0) {


			Instantiate(boomfx, transform.position, Quaternion.identity) ;
			Instantiate(boomfxDeux, transform.position, Quaternion.identity) ;
			Destroy (gameObject);
		}
			

	}

	void OnCollisionEnter2D(Collision2D col){

		if (col.gameObject.tag == ("Player") ) {

			Instantiate(boomfx, col.transform.position, Quaternion.identity) ;
			Instantiate(boomfxDeux, col.transform.position, Quaternion.identity) ;
			Destroy (gameObject);

		}
		if (col.gameObject.tag == ("Untagged") ) {

			Instantiate(boomfx, col.transform.position, Quaternion.identity);
			Instantiate(boomfxDeux, col.transform.position, Quaternion.identity) ;
			Destroy (gameObject);

		}


	}
}
