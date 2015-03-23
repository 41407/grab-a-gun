using UnityEngine;
using System.Collections;

public class DamageDealer : MonoBehaviour
{
		public string tags;
		public int damage;
		public int variance;

		void OnCollisionEnter2D (Collision2D col)
		{
				if (tags.Contains (col.gameObject.tag)) {
						col.gameObject.SendMessage ("TakeDamage", (Mathf.Max (damage + Random.Range (-variance, variance), 1)));
				}
		}
}
