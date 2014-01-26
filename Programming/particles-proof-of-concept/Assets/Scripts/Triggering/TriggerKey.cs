using UnityEngine;
using System.Collections;

public class TriggerKey : Trigger
{
	public KeyCode key;

	void Update()
	{
		if(Input.GetKeyDown(key))
		{
			TriggerAction();
		}
	}
}
