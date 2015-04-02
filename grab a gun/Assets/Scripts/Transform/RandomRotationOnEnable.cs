using UnityEngine;
using System.Collections;

public class RandomRotationOnEnable : MonoBehaviour
{
	public float x = 0f;
	public float y = 0f;
	public float z = 360f;

	void OnEnable ()
	{
		transform.Rotate (Random.Range (0, x), Random.Range (0, y), Random.Range (0, z));
	}
}
