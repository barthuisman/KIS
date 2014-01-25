﻿using UnityEngine;
using System.Collections;

// Require a character controller to be attached to the same game object
[RequireComponent (typeof(CharacterMotor))]
[AddComponentMenu("Character/FPS Input Controller")]

public class FPSInputController : MonoBehaviour
{

		private CharacterMotor motor;
		public bool toggleCrouch = false;
	
		// Use this for initialization
		void Awake ()
		{
				motor = gameObject.GetComponent<CharacterMotor> ();
		}
	
		// Update is called once per frame
		void Update ()
		{
				// Get the input vector from keyboard or analog stick
				Vector3 directionVector = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
		
				if (directionVector != Vector3.zero) {
						// Get the length of the directon vector and then normalize it
						// Dividing by the length is cheaper than normalizing when we already have the length anyway
						float directionLength = directionVector.magnitude;
						directionVector = directionVector / directionLength;
			
						// Make sure the length is no bigger than 1
						directionLength = Mathf.Min (1, directionLength);
			
						// Make the input vector more sensitive towards the extremes and less sensitive in the middle
						// This makes it easier to control slow speeds when using analog sticks
						directionLength = directionLength * directionLength;
			
						// Multiply the normalized direction vector by the modified length
						directionVector = directionVector * directionLength;
						
				}
				Crouch ();
				// Apply the direction to the CharacterMotor
				motor.inputMoveDirection = transform.rotation * directionVector;
				motor.inputJump = Input.GetButton("Jump");
				//motor.inputCrouch = Input.GetButton("Crouch");
		}

		void Crouch ()
		{
				if (Input.GetKeyDown (KeyCode.LeftControl)) {
						toggleCrouch = true;
				}
				if (Input.GetKeyUp (KeyCode.LeftControl)) {
						toggleCrouch = false;
				}
			
				switch (toggleCrouch) {
				case true:
						Camera.main.transform.localPosition = new Vector3 (Camera.main.transform.localPosition.x, 0.01f, Camera.main.transform.localPosition.z);
						break;
				case false:
						Camera.main.transform.localPosition = new Vector3 (Camera.main.transform.localPosition.x, 1f, Camera.main.transform.localPosition.z);
						break;
				}
		}

}