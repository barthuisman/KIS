using UnityEngine;
using System.Collections;

public class GUIScript : MonoBehaviour {
	public bool boolGUI = false;
	public bool howtoBool = false;
	public Texture2D howTo;
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.F5))
		{
			Application.LoadLevel(0);
		}
		if(Input.GetKeyDown(KeyCode.Delete))
		{
			Application.Quit();
		}
	}
	void OnGUI()
	{
		if(boolGUI)
		{
			if(GUI.Button(new Rect(0,0,100,100), "Resume"))
			{
				boolGUI = false;
			}
			if(GUI.Button(new Rect(0,100,100,100), "Quit"))
			{
				Application.Quit();
			}
			if(GUI.Button(new Rect(0,200,100,100), "How To"))
			{
				howtoBool = true;
			}
		}
		if(howtoBool)
		{
			GUI.Label(new Rect(300,300,400,400), howTo);
		}
	}
}
