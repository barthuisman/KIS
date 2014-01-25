using UnityEngine;
using System.Collections;

public abstract class Action : MonoBehaviour
{
	public abstract void TriggerAction();

	protected virtual void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(transform.position, 0.1f);
	}
}
