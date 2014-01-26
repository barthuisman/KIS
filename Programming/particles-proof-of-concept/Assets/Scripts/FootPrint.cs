using UnityEngine;
using System.Collections;

public class FootPrint : MonoBehaviour
{
		public GameObject footPrintLeft;
		public GameObject footPrintRight;
		public float seconds;
		public AudioClip[] footstepClips;
		private bool rightFoot;
		private Vector3 oldPosition;
		private float minDistance = 0.5f;

		private System.Random rand = new System.Random();

		void Start ()
		{
				seconds = 0.1f;	
				StartCoroutine (WaitSeconds ());
		}
	
		IEnumerator WaitSeconds ()
		{
				Vector3 temp = Vector3.zero;
				yield return new WaitForSeconds (seconds);
				switch (rightFoot) {
				case true:
						temp = oldPosition - transform.parent.position;
				
						if (temp.sqrMagnitude > minDistance * minDistance) {
								rightFoot = false;
								Quaternion orientation = Quaternion.LookRotation(transform.TransformDirection(Vector3.forward));
								Instantiate (footPrintRight, transform.position, orientation);
								oldPosition = transform.parent.position;
								//Debug.Log(transform.parent.rotation.y);
								audio.clip = footstepClips [rand.Next(footstepClips.Length-1)];
								audio.Play ();
						}
						break;
				case false:
						temp = oldPosition - transform.parent.position;
						if (temp.sqrMagnitude > minDistance * minDistance) {
								rightFoot = true;
								Quaternion orientation = Quaternion.LookRotation(transform.TransformDirection(Vector3.forward));
								Instantiate (footPrintLeft, transform.position, orientation);
								oldPosition = transform.parent.position;
								//Debug.Log(transform.parent.rotation.y);
								audio.clip = footstepClips [rand.Next(footstepClips.Length-1)];
								audio.Play ();
						}
						break;
				}
				StartCoroutine (WaitSeconds ());

				
		}
}