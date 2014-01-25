using UnityEngine;
using System.Collections;

public class ActionSetEnabled : Action
{
		public MonoBehaviour targetMonoBehaviour;
		public enum Mode
		{
				Activate,
				Deactivate,
				Toggle
		}
		public Mode mode;

		public override void TriggerAction ()
		{
				if (targetMonoBehaviour != null) {
						switch (mode) {
						case Mode.Activate:
								targetMonoBehaviour.enabled = true;
								break;
						case Mode.Deactivate:
								targetMonoBehaviour.enabled = false;
								break;
						case Mode.Toggle:
								targetMonoBehaviour.enabled = !targetMonoBehaviour.enabled;
								break;
						}
				}
		}
}
