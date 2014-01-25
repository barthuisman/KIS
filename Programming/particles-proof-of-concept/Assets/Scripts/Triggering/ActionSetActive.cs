using UnityEngine;
using System.Collections;

// Use this Action to set entire GameObjects (and their children) to active or inactive.
public class ActionSetActive : Action
{
		public enum Mode
		{
				Activate,
				Deactivate,
				Toggle
		}
		public Mode mode;

		public override void TriggerAction ()
		{
				switch (mode) {
				case Mode.Activate:
						gameObject.SetActive (true);
						break;
				case Mode.Deactivate:
						gameObject.SetActive (false);
						break;
				case Mode.Toggle:
						gameObject.SetActive (!gameObject.activeSelf);
						break;
				}
		}
}
