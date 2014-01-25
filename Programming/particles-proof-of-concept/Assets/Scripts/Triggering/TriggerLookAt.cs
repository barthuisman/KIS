using UnityEngine;
using System.Collections;

// Triggers when the player focused at the object for longer than a specified time.
public class TriggerLookAt : Trigger
{
		public float focusRequired = 1;
		public float currentFocus = 0;

		// Should be called by the player when looking at an object with this script.
		public void LookAtThisFrame ()
		{
				currentFocus += Time.deltaTime * 2;
				if (currentFocus > focusRequired) {
						currentFocus = 0;
						TriggerAction ();
				}
		}

		void Update ()
		{
				currentFocus = Mathf.Max (0, currentFocus - Time.deltaTime);
		}
}
