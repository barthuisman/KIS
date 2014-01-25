using UnityEngine;
using System.Collections;

public class FootPrint : MonoBehaviour {
	public GameObject footPrint;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Instantiate(footPrint, gameObject.transform.position, new Quaternion(90,90,0,0));
	}
}
