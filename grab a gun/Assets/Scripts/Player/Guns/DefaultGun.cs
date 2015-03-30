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
	
	void CreateBulletHereAndInheritVelocity (Quaternion rotation)
	{
		CreateBulletHereAndInheritVelocity (rotation, 0);
	}
	
	void CreateBulletHereAndInheritVelocity (Quaternion rotation, float speed)
	{
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
		CreateBulletHereAndInheritVelocity (transform.rotation);
	}

	void FireMachineGun ()
	{
		fireTimer = 0.05f;
		ammo--;
		Quaternion rotation = transform.rotation * Quaternion.AngleAxis (Random.Range (-5.0f, 5.0f), Vector3.forward);
		CreateBulletHereAndInheritVelocity (rotation);

	}

	void FireShotgun ()
	{
		if (triggerReleased) {
			fireTimer = 0.2f;
			ammo--;
			for (int i = 0; i < 13; i++) {
				Quaternion rotation = transform.rotation * Quaternion.AngleAxis (Random.Range (-8.0f, 8.0f), Vector3.forward);
				CreateBulletHereAndInheritVelocity (rotation, Random.Range (-20.0f, 0f));
			}
			triggerReleased = false;
		}
	}
}
