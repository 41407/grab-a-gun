using UnityEngine;
using System.Collections;

public class Mouse : MonoBehaviour {
	
	public static Vector3 GetWorldPositionOnPlane (Vector3 screenPosition, float z)
	{
		Ray ray = Camera.main.ScreenPointToRay (screenPosition);
		Plane xy = new Plane (Vector3.forward, new Vector3 (0, 0, z));
		float distance;
		xy.Raycast (ray, out distance);
		return ray.GetPoint (distance);
	}

	void Update () {
		Vector2 newPosition = GetWorldPositionOnPlane(Input.mousePosition, 0);
		transform.position = newPosition;
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			Factory.create.Enemy(transform.position, Quaternion.identity);
		}
		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			Factory.create.Spawner(transform.position, Quaternion.identity);
		}
	}
}
