using UnityEngine;
using System.Collections;

public class Action : MonoBehaviour
{
	public virtual void TriggerAction()
	{
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(transform.position, 0.1f);
	}
}
