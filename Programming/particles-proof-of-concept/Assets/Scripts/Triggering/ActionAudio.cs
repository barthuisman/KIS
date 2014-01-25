using UnityEngine;
using System.Collections;

// Use this Action to play an AudioSource
public class ActionAudio : Action
{
		public override void TriggerAction ()
		{
				audio.Play ();
		}
}
