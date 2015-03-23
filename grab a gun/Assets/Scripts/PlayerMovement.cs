using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	public float maxSpeed;

	void Update ()
	{
		Vector2 movementVector;
		movementVector = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
		transform.Translate (movementVector * Time.deltaTime * maxSpeed);
	}

}
