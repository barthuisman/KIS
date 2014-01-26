using UnityEngine;
using System.Collections;

// Triggers after being triggered X times.
public class ActionAccumulator : Action
{
		public Action[] actions = new Action[0];
		public int targetCount;
		public int currentCount = 0;

		public override void TriggerAction ()
		{
				currentCount++;
				if (currentCount >= targetCount) {
						currentCount = 0;
						InternalTrigger ();
				}
		}

		void InternalTrigger ()
		{	
				for (int i = 0; i < actions.Length; ++i) {
						Action a = actions [i];
						if (a != null) {
								Debug.Log (string.Format ("ActionAccumulator {0} signalling Action {1}.", this.name, a.name), this);
								a.TriggerAction ();
						}
				}
		}

		protected override void OnDrawGizmos ()
		{
				base.OnDrawGizmos();
				Gizmos.color = Color.green;
				for (int i = 0; i < actions.Length; ++i) {
						Action a = actions [i];
						if (a != null) {
								Gizmos.DrawLine (transform.position, a.transform.position);
						}
				}
		}
}
