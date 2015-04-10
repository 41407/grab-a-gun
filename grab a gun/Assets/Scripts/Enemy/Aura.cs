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
		if (coll.gameObject.tag.Equals ("Enemy")) {
			coll.gameObject.SendMessage ("ApplyAura", emittedAura);
		}
	}

	private void ApplyAura (AuraType newAura)
	{
		switch (newAura) {
		case AuraType.Speed:
			gameObject.SendMessage ("SetMoveSpeedModifier", 1.5f);
			Invoke ("DisableSpeedAura", 1.0f);
			break;
		default:
			break;
		}
	}

	private void DisableSpeedAura() {
		gameObject.SendMessage("SetMoveSpeedModifier", 1.0f);
	}

	private AuraType SetEmittedAura ()
	{
		return AuraType.Speed;
	}
}
