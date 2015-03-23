using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour
{
	public float maxSpeed;

	void Update ()
	{
		Movement ();
		Firing ();
	}

	void Movement ()
	{	
		Vector2 input = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
		gameObject.GetComponent<Rigidbody2D>().AddForce(input * maxSpeed);
	}

	void Firing ()
	{
		if (Input.GetMouseButtonDown (0)) {
			InvokeRepeating ("InvokeFiring", 0, 0.16f);
		}
		if (Input.GetMouseButtonUp (0)) {
			CancelInvoke ();
		}
	}

	void InvokeFiring ()
	{
		gameObject.SendMessage ("Fire");
	}
}
