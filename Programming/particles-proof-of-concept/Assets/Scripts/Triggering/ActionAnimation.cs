using UnityEngine;
using System.Collections;

// Use this action to play an animation
public class ActionAnimation : Action
{
	public PlayMode playMode;
	public string clipName;

	public override void TriggerAction ()
	{
		if(animation != null)
		{
			if(string.IsNullOrEmpty(clipName))
			{
				animation.Play(playMode);
			}
			else
			{
				animation.Play(clipName, playMode);
			}
		}
	} 
}
