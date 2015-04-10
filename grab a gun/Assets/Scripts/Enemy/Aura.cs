using UnityEngine;
using System.Collections;

public class Aura : MonoBehaviour
{
	public bool emitsAura = false;
	public AuraType emittedAura;
	public int level = 0;

	void OnEnable ()
	{
		emitsAura = false;
		gameObject.GetComponent<ParticleSystem> ().Stop ();
	}

	void EnableAura ()
	{
		emitsAura = true;
		emittedAura = SetEmittedAura ();
	}

	void SetLevel (int newLevel)
	{
		level = newLevel;
	}

	void OnTriggerStay2D (Collider2D coll)
	{
		if (emitsAura && Time.frameCount % 30 == 0) {
			if (coll.gameObject.tag.Equals ("Enemy")) {
				coll.gameObject.transform.FindChild ("Aura").SendMessage ("ApplyAura", emittedAura);
			}
		}
	}

	private void ApplyAura (AuraType newAura)
	{
		switch (newAura) {
		case AuraType.Speed:
			gameObject.GetComponent<ParticleSystem> ().Play ();
			gameObject.SendMessageUpwards ("SetMoveSpeedModifier", 1.5f);
			Invoke ("DisableSpeedAura", 1.0f);
			break;
		default:
			break;
		}
	}

	private void DisableSpeedAura ()
	{
		gameObject.GetComponent<ParticleSystem> ().Stop ();
		gameObject.SendMessageUpwards ("SetMoveSpeedModifier", 1.0f);
	}

	private AuraType SetEmittedAura ()
	{
		return AuraType.Speed;
	}
}
