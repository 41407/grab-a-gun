using UnityEngine;
using System.Collections;

public class Aura : MonoBehaviour
{
	public bool emitsAura = false;
	public AuraType activeAura;
	public int level = 0;

	void OnEnable ()
	{
		emitsAura = false;
	}

	void EnableAura ()
	{
		emitsAura = true;
		activeAura = SetAuraByLevel ();
	}

	void SetLevel (int newLevel)
	{
		level = newLevel;
	}

	private AuraType SetAuraByLevel ()
	{
		return AuraType.Speed;
	}
}
