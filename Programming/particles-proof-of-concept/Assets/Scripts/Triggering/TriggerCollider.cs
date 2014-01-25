using UnityEngine;
using System.Collections;

public class TriggerCollider : Trigger
{
		public enum TriggerMode
		{
				OnEnter,
				OnExit,
				OnStay
		}
		public TriggerMode mode;
		

		void Reset ()
		{
				if (collider != null)
						collider.isTrigger = true;
		}

		void OnTriggerEnter (Collider collider)
		{
				if (mode == TriggerMode.OnEnter)
						TriggerAction ();
		}

		void OnTriggerExit (Collider collider)
		{
				if (mode == TriggerMode.OnExit)
						TriggerAction ();
		}

		void OnTriggerStay (Collider collider)
		{
				if (mode == TriggerMode.OnStay)
						TriggerAction ();
		}
}
