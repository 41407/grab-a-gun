using UnityEngine;
using System.Collections;

public class DefaultGun : MonoBehaviour
{
	public PowerupClass currentPowerup = PowerupClass.None;
	public int ammo;
	private bool firing = false;
	private float fireTimer = 0;
	private bool triggerReleased = true;
	public GameObject gunsmoke;

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
		triggerReleased = true;
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
		case PowerupClass.Shotgun:
			FireShotgun ();
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
		case PowerupClass.Shotgun:
			ammo = 15;
			break;
		}
	}
	
	void ShootBullet ()
	{
		ShootBullet (0, 0);
	}
	
	void ShootBullet (float accuracy)
	{
		ShootBullet (accuracy, 0);
	}

	void ShootBullet (float accuracy, float speed)
	{
		Quaternion rotation = transform.rotation * Quaternion.AngleAxis (Random.Range (-accuracy, accuracy), Vector3.forward);
		GameObject bullet = Factory.create.PlayerBullet (transform.position, rotation);
		bullet.SendMessage ("SetVelocity", GetComponent<Rigidbody2D> ().velocity);
		bullet.SendMessage ("SetSpeed", speed);
		if (gunsmoke) {
			Factory.create.ByReference (gunsmoke, transform.position, transform.rotation);
		}
	}

	void FireDefaultGun ()
	{
		fireTimer = 0.2f;
		ShootBullet (3);
	}

	void FireMachineGun ()
	{
		fireTimer = 0.05f;
		ammo--;
		ShootBullet (5);

	}

	void FireShotgun ()
	{
		if (triggerReleased) {
			fireTimer = 0.2f;
			ammo--;
			for (int i = 0; i < 13; i++) {
				ShootBullet (8, Random.Range (0, 20f));
			}
			triggerReleased = false;
		}
	}
}
