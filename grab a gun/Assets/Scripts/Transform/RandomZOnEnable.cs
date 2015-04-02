using UnityEngine;
using System.Collections;

public class RandomZOnEnable : MonoBehaviour
{

	public float min;
	public float max;

	void OnEnable ()
	{
		Vector3 position = transform.position;
		position.z = Random.Range (min, max);
		transform.position = position;
	}
}
