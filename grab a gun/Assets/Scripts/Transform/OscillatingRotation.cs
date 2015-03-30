using UnityEngine;
using System.Collections;

public class OscillatingRotation : MonoBehaviour
{
	public float xMagnitude = 0;
	public float yMagnitude = 0;
	public float zMagnitude = 20;
	public float speed = 30;

	void Update ()
	{
		Vector3 rotationEulers = transform.rotation.eulerAngles;
		rotationEulers.x = xMagnitude* Mathf.Sin (Time.frameCount / speed);
		rotationEulers.y = yMagnitude* Mathf.Sin (Time.frameCount / speed);
		rotationEulers.z = zMagnitude* Mathf.Sin (Time.frameCount / speed);
		transform.rotation = Quaternion.Euler(rotationEulers);
	}
}
