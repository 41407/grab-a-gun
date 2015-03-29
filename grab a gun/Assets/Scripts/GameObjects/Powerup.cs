using UnityEngine;
using System.Collections;

public class Powerup : MonoBehaviour {

	public PowerupClass powerupClass = PowerupClass.MachineGun;

	void OnCollisionEnter2D (Collision2D coll) {
		if(coll.gameObject.tag.Equals("Player")) {
			coll.gameObject.SendMessage("SetPowerup", powerupClass);
			gameObject.SetActive(false);
		}
	}
}
