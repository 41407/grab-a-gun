using UnityEngine;
using System.Collections;

public class Mouse : MonoBehaviour {

	void Update () {
		Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		transform.position = newPosition;
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			Factory.create.Enemy(transform.position, Quaternion.identity);
		}
	}
}
