using UnityEngine;
using System.Collections;

public class ActionChangeScene : Action
{
	public string sceneName;

	public override void TriggerAction ()
	{
		if(string.IsNullOrEmpty(sceneName))
		{
			Application.LoadLevel(Application.loadedLevel + 1);
		}
		else
		{
			Application.LoadLevel(sceneName);
		}
	}
}
