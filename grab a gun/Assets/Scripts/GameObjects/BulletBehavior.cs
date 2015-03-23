using UnityEngine;
using System.Collections;

public class BulletBehavior : MonoBehaviour {

	public float speed = 1.0f;

	void Update () {
		transform.Translate (transform.rotation * Vector3.up * speed * Time.deltaTime);
	}
}
