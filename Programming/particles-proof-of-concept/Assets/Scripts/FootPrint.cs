using UnityEngine;
using System.Collections;

public class FootPrint : MonoBehaviour
{
		public GameObject footPrintLeft;
		public GameObject footPrintRight;
		public float seconds;
		private bool rightFoot;
		private Transform oldTransform;
		private Vector3 oldPosition;
	private float minDistance =0.5f;

		void Start ()
		{
				oldTransform = transform.parent;
				seconds = 0.1f;	
				StartCoroutine (WaitSeconds());
		}
	
		IEnumerator WaitSeconds ()
		{
		Vector3 temp=  Vector3.zero;
		Debug.Log(temp);
				yield return new WaitForSeconds (seconds);
				switch (rightFoot) {
				case true:
				temp = oldPosition - transform.parent.position;
				
				if(temp.sqrMagnitude > minDistance*minDistance){
								Debug.Log(rightFoot);
								rightFoot = false;
								Instantiate (footPrintRight, transform.position, new Quaternion (0, transform.parent.rotation.y + 90, 0, 0));
								oldPosition = transform.parent.position;
						}
						break;
				case false:
			temp = oldPosition - transform.parent.position;
			if(temp.sqrMagnitude > minDistance*minDistance) {
								rightFoot = true;
								Instantiate (footPrintLeft, transform.position, new Quaternion (0, transform.parent.rotation.y + 90, 0, 0));
								oldPosition = transform.parent.position;
						}
								//StartCoroutine (WaitSeconds ());
						break;
				}
				StartCoroutine (WaitSeconds ());

				
		}
}