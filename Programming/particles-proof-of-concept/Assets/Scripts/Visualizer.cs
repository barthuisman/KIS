using UnityEngine;
using System.Collections;

public class Visualizer : MonoBehaviour
{
	public float minDistance = 1f;
	public float maxDistance = 5f;
	public float particleLifetime = 5f;
	public float size = 1f;
	public float conewidth = 0.5f;
	public Color32 color = new Color32 (255, 255, 255, 255);
	public int raycastSamplesPerFrame = 25;
	public LayerMask raycastLayerMask;

	public enum DecayType
	{
		Linear,
		Exponential
	}
	
	public float exponentialDecayRate = 0.99f;
	
	public DecayType decay;

	void Update ()
	{
		Camera cam = Camera.main;
		Vector3 pos = cam.transform.position;
		
		//if(Input.GetKeyDown(KeyCode.Q))
		//{
		ConeCast (pos, raycastSamplesPerFrame, conewidth, cam.transform.localToWorldMatrix);
		//}
	}
	
	public void SpawnParticle (Vector3 particlePosition, float distance, Vector3 normal)
	{
		float t = (distance - minDistance) / maxDistance;
		float intensity = Decay(t);
		Color32 color = Color.white * intensity;
		//particleSystem.Emit (particlePosition, Vector3.zero, size, lifetime, color);

		ParticleSystem.Particle p = new ParticleSystem.Particle();
		p.position = particlePosition;
		p.velocity = Vector3.zero;
		p.size = size;
		p.startLifetime = particleLifetime;
		p.lifetime = particleLifetime;
		p.color = color;
		particleSystem.Emit(p);
	}
	
	public float Decay (float t)
	{
		float result = 1;
		switch (decay) {
		case DecayType.Linear:
			result = 1 - t;
			break;
		case DecayType.Exponential:
			result = Mathf.Pow(1 - exponentialDecayRate, t);
			break;
		}
		return result;
	}
	
	public void ConeCast (Vector3 origin, int nSamples, float coneWidth, Matrix4x4 orientation)
	{
		//Vector3 origin = orientation * Vector3.zero;
		Vector3 direction;
		
		// for every sample
		for (int i = 0; i < nSamples; ++i) {
			// random point inside circle
			Vector2 circle = Random.insideUnitCircle * coneWidth;
			
			// local direction
			direction.x = circle.x;
			direction.y = circle.y;
			direction.z = 0.5f;
			
			// transform to world space
			direction = orientation * direction;
			
			// do raycast
			Ray ray = new Ray ();
			ray.origin = origin;
			ray.direction = direction;
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit, maxDistance, raycastLayerMask)) {
				// spawn a particle
				SpawnParticle (hit.point, hit.distance, hit.normal);
			}
		}
	}

	public void LineCast (Vector3 origin, Vector3 direction)
	{
		Ray ray = new Ray ();
		ray.origin = origin;
		ray.direction = direction;
		RaycastHit hit;
		
		// if we hit something
		if (Physics.Raycast (ray, out hit, maxDistance, raycastLayerMask)) {
			// spawn a particle
			SpawnParticle (hit.point, hit.distance, hit.normal);
		}
	}
}
