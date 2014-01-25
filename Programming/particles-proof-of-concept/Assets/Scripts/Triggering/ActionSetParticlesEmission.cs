using UnityEngine;
using System.Collections;

public class ActionSetParticlesEmission : Action
{
	public enum Mode { Enable, Disable, Toggle }
	public Mode mode;

	public override void TriggerAction ()
	{
		if(particleSystem != null)
		{
			switch(mode)
			{
				case Mode.Enable:
				particleSystem.enableEmission = true;
				break;
			case Mode.Disable:
				particleSystem.enableEmission = false;
				break;
			case Mode.Toggle:
				particleSystem.enableEmission = !particleSystem.enableEmission;
				break;
			}
		}


	}
}
