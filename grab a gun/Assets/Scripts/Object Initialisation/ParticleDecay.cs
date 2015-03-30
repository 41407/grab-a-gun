using UnityEngine;
using System.Collections;

public class ParticleDecay : MonoBehaviour
{
	void Update ()
	{
		if (gameObject.GetComponent<ParticleSystem> ().isStopped) {
			transform.parent.gameObject.SetActive (false);
		}
	}

	void OnEnable ()
	{
		gameObject.GetComponent<ParticleSystem> ().Play ();
	}
	
	void OnDisable ()
	{
		gameObject.GetComponent<ParticleSystem> ().Stop ();
	}
}
