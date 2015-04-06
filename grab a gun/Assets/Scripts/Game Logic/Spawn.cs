using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour
{

	public float spawnerTimer = 0f;
	public float spawnInterval = 10f;

	void Awake ()
	{
		spawnerTimer = 0;
	}

	void Update ()
	{
		spawnerTimer -= Time.deltaTime;
		if (spawnerTimer <= 0) {
			print ("Spawner created");
			Factory.create.Spawner (new Vector2 (Random.Range (-16, 16), Random.Range (-16, 16)), Quaternion.AngleAxis (Random.Range (0, 360), Vector3.forward));
			spawnerTimer = spawnInterval;
		}
	}
}
