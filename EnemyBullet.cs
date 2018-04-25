using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

	public Transform target;
	public float speed;

	public float radius = 5.0F;
	public float power = 10.0F;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


	}
	public static void AddExplosionForce(Rigidbody2D body, float expForce, Vector3 expPosition, float expRadius){
		var dir = (body.transform.position - expPosition);
		float calc = 1 - (dir.magnitude / expRadius);
		if (calc <= 0) {
			calc = 0;


		}

		body.AddForce (dir.normalized * expForce * calc);


	}

	void OnCollisionEnter2D(Collision2D col){
		
		if (col.gameObject.tag == ("EnemyBullet") ) {
			Debug.Log ("Boom");
			Vector3 cible = col.transform.position;
			AddExplosionForce (GetComponent <Rigidbody2D>(), power, cible, radius);
			Debug.Log ("Badaboom");


			}

		}




}
