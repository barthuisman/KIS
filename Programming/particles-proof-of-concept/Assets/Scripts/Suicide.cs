using UnityEngine;
using System.Collections;

public class Suicide : MonoBehaviour
{
		public int seconds;
		// Use this for initialization
		void Start ()
		{
				StartCoroutine (DestroyAfterSeconds ());
		}
	
		IEnumerator DestroyAfterSeconds ()
		{
				//print(Time.time);
				yield return new WaitForSeconds (seconds);
				Destroy (this.gameObject);
				//print(Time.time);
		}
		// Update is called once per frame
		void Update ()
		{
	
		}
}
