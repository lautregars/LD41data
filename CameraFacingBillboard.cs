using UnityEngine;
using System.Collections;

public class CameraFacingBillboard : MonoBehaviour
{
	public Camera m_Camera;

	void Update()
	{
		GameObject g = GameObject.Find ("Ninja");
		if (g != null) {
			LeNinja leninja = g.GetComponent<LeNinja> ();

			if (leninja.FPSCAM.enabled == true) {
				transform.LookAt (transform.position + m_Camera.transform.rotation * Vector3.forward,
					m_Camera.transform.rotation * Vector3.up);

			}

			if (leninja.FPSCAM.enabled == false) {

				gameObject.transform.rotation = new Quaternion (0, 0, 0, 0);

			}

		}
	}

}