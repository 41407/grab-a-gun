using UnityEngine;
using System.Collections;

public class BulletBehavior : MonoBehaviour {

	public float speed = 500.0f;

	void Start () {
		GetComponent<Rigidbody2D>().AddForce(transform.rotation * Vector3.up * speed);
	}

	public void SetVelocity (Vector2 velocity) {
		GetComponent<Rigidbody2D> ().velocity = velocity;
	}
}
