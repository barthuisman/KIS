using UnityEngine;
using System.Collections;

// Should be attached to the player's head to interact with TriggerLookAt.
public class LookAtTrigger : MonoBehaviour
{
	public float maxDistance = 5f;
	public LayerMask raycastLayerMask;

	public void Update()
	{
		Ray ray = new Ray();
		ray.origin = transform.position;
		ray.direction = transform.TransformDirection(Vector3.forward);

		RaycastHit hit;
		if(Physics.Raycast(ray, out hit, maxDistance, raycastLayerMask))
		{
			TriggerLookAt trig = hit.collider.gameObject.GetComponent<TriggerLookAt>();
			if(trig != null)
			{
				trig.LookAtThisFrame();
			}
		}
	}
}
