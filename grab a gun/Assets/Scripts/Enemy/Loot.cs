using UnityEngine;
using System.Collections;

public class Loot : MonoBehaviour
{
	public bool dropOnDisable = false;
	public int level;

	void SetLoot (int newLevel)
	{
		dropOnDisable = true;
		level = newLevel;
	}

	void OnDisable ()
	{
		if (dropOnDisable) {
			CreateLoot ();
		}
		dropOnDisable = false;
	}

	void CreateLoot ()
	{
		int randomNumber = Random.Range (0, 3);
		switch (randomNumber) {
		case(0):
			Factory.create.Revolver (transform.position, Quaternion.identity);
			break;
		case(1):
			Factory.create.MachineGun (transform.position, Quaternion.identity);
			break;
		case(2):
			Factory.create.Shotgun (transform.position, Quaternion.identity);
			break;
		}
	} 
}
