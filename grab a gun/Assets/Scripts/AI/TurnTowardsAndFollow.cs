using UnityEngine;
using System.Collections;

public class TurnTowardsAndFollow : MonoBehaviour
{
		public GameObject player;
		public float turningSpeed;
		public float moveSpeed;
	
		void Update ()
		{
				if (player) {
						TurnTowardsPlayer ();
				}
				GetComponent<Rigidbody2D>().AddForce (transform.rotation * Vector2.up * moveSpeed * Time.deltaTime);
		}

		public void SetPlayer (GameObject player)
		{
				this.player = player;
		}

		void TurnTowardsPlayer ()
		{
				Vector2 heading = player.transform.position - transform.position;
				float angle = transform.rotation.eulerAngles.z;
				float angleBetween = Vector2.Angle (Vector2.up, heading);
				if (heading.x > 0) {
						angleBetween = 360 - angleBetween;
				}
				if (angleBetween - angle > 180) {
						angleBetween -= 360;	
				}
		
				if (angleBetween - angle < -180) {
						angleBetween += 360;	
				}
				if (angleBetween - angle > 0) {
						gameObject.transform.Rotate (new Vector3 (0, 0, turningSpeed * Time.deltaTime));
				} else {
						gameObject.transform.Rotate (new Vector3 (0, 0, -turningSpeed * Time.deltaTime));
				}	
		}
}
