using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
	public float initialSpawnDelay = 1.5f;
	public int poolSize = 10;
	public int numberOfEnemies = 1;
	private int spawnedEnemies = 0;
	public int monsterLevel = 0;
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
		GameObject newEnemy = Factory.create.Enemy (transform.position, transform.rotation);
		spawnedEnemies++;
		if (spawnedEnemies >= numberOfEnemies) {
			newEnemy.SendMessage ("SetLoot", monsterLevel);
			gameObject.SetActive (false);
		}
	}

	void OnDisable ()
	{
		CancelInvoke ();
	}

	void SetMonsterLevel (int level)
	{
		monsterLevel = level;
	}

	public void SetPlayer (GameObject player)
	{
		GetComponent<LookAtObject> ().objectToLookAt = player;
	}
}
