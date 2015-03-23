using UnityEngine;
using System.Collections;

public class DefaultGun : MonoBehaviour {

	void Fire() {
		GameObject bullet = Factory.create.PlayerBullet(transform.position, transform.rotation);
		bullet.SendMessage("SetVelocity", GetComponent<Rigidbody2D> ().velocity);
	}
}
