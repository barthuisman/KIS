﻿using UnityEngine;
using System.Collections;

public class GUIScript : MonoBehaviour {
	public bool boolGUI = false;
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
	void OnGUI()
	{
		if(boolGUI)
		{
			if(GUI.Button(new Rect(0,0,100,100), "Quit"))
			{
				Application.Quit();
			}
			if(GUI.Button(new Rect(0,100,100,100), "Start"))
			{
				Application.LoadLevel(0);
			}
		}
	}
}
