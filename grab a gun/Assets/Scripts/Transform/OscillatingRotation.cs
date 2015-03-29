using UnityEngine;
using System.Collections;

public class OscillatingRotation : MonoBehaviour
{

	public float speed;

	void Update ()
	{
		Vector3 rotationEulers = transform.rotation.eulerAngles;
		rotationEulers.x = 10 * Mathf.Sin (Time.frameCount / speed);
		transform.rotation = Quaternion.Euler(rotationEulers);
	}
}
