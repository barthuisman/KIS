using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour
{
		public Action[] actions = new Action[0];

		void Reset ()
		{
				if (collider != null)
						collider.isTrigger = true;
		}

		void OnTriggerEnter (Collider collider)
		{
				// trigger action
		}

		void OnDrawGizmos ()
		{
				Gizmos.color = Color.green;
				Gizmos.DrawWireSphere (transform.position, 0.1f);
				for (int i = 0; i < actions.Length; ++i) {
						Action a = actions [i];
						if (a != null) {
								Gizmos.DrawLine (transform.position, a.transform.position);
						}
				}
		}
}
