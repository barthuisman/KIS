using UnityEngine;
using System.Collections;

public class ActionAdjustPlayerSpot : Action
{
		public RayCastLight target;
		public PlayerSpotSettings minIntensity;
		public PlayerSpotSettings maxIntensity;

		public enum Mode
		{
				Increment,
				Decrement,
				Min,
				Max
		}
		public Mode mode;
		public float incrementT = 0.2f;
		public static float currentT;

		public override void TriggerAction ()
		{
				switch (mode) {
				case Mode.Increment:
						currentT += incrementT;
						break;
				case Mode.Decrement:
						currentT -= incrementT;
						break;
				case Mode.Min:
						currentT = 0;
						break;
				case Mode.Max:
						currentT = 1;
						break;
				}

				Lerp (currentT);
		}

		[ContextMenu("Lerp")]
		public void Lerp (float t)
		{
				target.minDistance = Mathf.Lerp (minIntensity.minDistance, maxIntensity.minDistance, t);
				target.maxDistance = Mathf.Lerp (minIntensity.maxDistance, maxIntensity.maxDistance, t);
				target.conewidth = Mathf.Lerp (minIntensity.conewidth, maxIntensity.conewidth, t);
				target.randomness = Mathf.Lerp (minIntensity.randomness, maxIntensity.randomness, t);
				target.particleLifetime = Mathf.Lerp (minIntensity.particleLifetime, maxIntensity.particleLifetime, t);
				target.particleSize = Mathf.Lerp (minIntensity.particleSize, maxIntensity.particleSize, t);
				target.exponentialDecayRate = Mathf.Lerp (minIntensity.exponentialDecayRate, maxIntensity.exponentialDecayRate, t);
		}
}
