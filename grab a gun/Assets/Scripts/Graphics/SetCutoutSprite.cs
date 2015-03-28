using UnityEngine;
using System.Collections;

public class SetCutoutSprite : MonoBehaviour
{
	
	public Texture sprite;
	public Texture normalMap;

	// Use this for initialization
	void OnEnable ()
	{
		GetComponent<Renderer> ().material.mainTexture = sprite;
		if (normalMap) {
			GetComponent<Renderer> ().material.SetTexture ("_BumpMap", normalMap);
		}
	}
}
