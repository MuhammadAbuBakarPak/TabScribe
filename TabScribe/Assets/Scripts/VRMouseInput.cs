using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Valve.VR;

public class VRMouseInput : MonoBehaviour
{
	
	public float mouseSensitivity = 1.0f;
	//const float YAxis3D = 0.01f;
	//const float XAxis3D = 0.01f;

	private void Start()
	{
		
	}

    // Update is called once per frame
	private void Update()
	{
		 //Ball movement Code
		// Read mouse input
		float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
		float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

		Vector3 cursorPosition = transform.position + new Vector3(mouseX, mouseY, 1);
		//Vector3 cursorPosition = transform.position + new Vector3(mouseX * XAxis3D, mouseY * YAxis3D, 0);
		transform.position = cursorPosition;
	

	}
		
}