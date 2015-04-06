using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
	public float initialSpawnDelay = 1.5f;
	public int poolSize = 10;
	public int numberOfEnemies = 1;
	private int spawnedEnemies = 0;
	public GameObject player;

	void OnEnable ()
	{
		spawnedEnemies = 0;
		Invoke ("StartSpawning", initialSpawnDelay);
	}

	private void StartSpawning ()
	{
		InvokeRepeating ("SpawnEnemy", 0.5f, 0.5f);
	}

	private void SpawnEnemy ()
	{
		Factory.create.Enemy (transform.position, transform.rotation);
		spawnedEnemies++;
		if (spawnedEnemies >= numberOfEnemies) {
			
			gameObject.SetActive (false);
		}
	}

	void OnDisable ()
	{
		CancelInvoke ();
	}

	public void SetPlayer (GameObject player)
	{
		GetComponent<LookAtObject> ().objectToLookAt = player;
	}
}
