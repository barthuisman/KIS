﻿using UnityEngine;
using System.Collections;

// This trigger forms the foundation for all others.
public abstract class Trigger : MonoBehaviour
{
		public Action[] actions = new Action[0];
		public bool singleUse;
		public bool used;
		public bool debugLogs = false;

		[ContextMenu("Trigger")]
		public void TriggerAction ()
		{
				if (!used || !singleUse) {
						used = true;

						for (int i = 0; i < actions.Length; ++i) {
								Action a = actions [i];
								if (a != null) {
										Debug.Log (string.Format ("Trigger {0} signalling Action {1}.", this.name, a.name), this);
										a.TriggerAction ();
								}
						}
				}

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
