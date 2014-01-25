using UnityEngine;
using System.Collections;

public class GUI : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.F4))
		{
			Application.LoadLevel(0);
		}
		if(Input.GetKeyDown(KeyCode.Delete))
		{
			Application.Quit();
		}
	}
}
