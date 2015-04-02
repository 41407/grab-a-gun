using UnityEngine;
using System.Collections;

public class SetCutoutSprite : MonoBehaviour
{
	
	public Texture[] sprites;

	// Use this for initialization
	void OnEnable ()
	{
		GetComponent<Renderer> ().material.mainTexture = sprites[Random.Range(0, sprites.Length)];
	}
}
