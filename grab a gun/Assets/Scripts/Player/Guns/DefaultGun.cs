using UnityEngine;
using System.Collections;

public class DefaultGun : MonoBehaviour
{
	public PowerupClass currentPowerup = PowerupClass.None;
	public int ammo;
	public bool firing = false;
	public float fireTimer = 0;

	void Update ()
	{
		fireTimer -= Time.deltaTime;
		if (fireTimer <= 0 && firing) {
			Fire ();
		}
		if (ammo <= 0) {
			currentPowerup = PowerupClass.None;
		}
	}

	void StartFiring ()
	{
		firing = true;
	}

	void CeaseFire ()
	{
		firing = false;
	}

	void Fire ()
	{
		switch (currentPowerup) {
		case PowerupClass.None:
			FireDefaultGun ();
			break;
		case PowerupClass.MachineGun:
			FireMachineGun ();
			break;
		}
	}

	public void SetPowerup (PowerupClass newPowerup)
	{
		currentPowerup = newPowerup;
		switch (newPowerup) {
		case PowerupClass.MachineGun:
			ammo = 100;
			break;
		}
	}

	void FireDefaultGun ()
	{
		fireTimer = 0.2f;
		GameObject bullet = Factory.create.PlayerBullet (transform.position, transform.rotation);
		bullet.SendMessage ("SetVelocity", GetComponent<Rigidbody2D> ().velocity);
	}

	void FireMachineGun ()
	{
		fireTimer = 0.05f;
		ammo--;
		Quaternion rotation = transform.rotation * Quaternion.AngleAxis (Random.Range (-5.0f, 5.0f), Vector3.forward);
		GameObject bullet = Factory.create.PlayerBullet (transform.position, rotation);
		bullet.SendMessage ("SetVelocity", GetComponent<Rigidbody2D> ().velocity);
	}
}
