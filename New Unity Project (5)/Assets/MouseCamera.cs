using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCamera : MonoBehaviour
{
	[SerializeField] Rigidbody playerRb;
	//[SerializeField] float rotSpeed;
	[SerializeField] float moveSensitivity = 100f;
	float xRotation = 0f;
	void Update()
	{
		// Get the mouse movement on both axis 
		float mouseX = Input.GetAxis("Mouse X") * moveSensitivity * Time.deltaTime;
		float mouseY = Input.GetAxis("Mouse Y") * moveSensitivity * Time.deltaTime;

		// Calculate new Rotation
		xRotation -= mouseY;
		xRotation = Mathf.Clamp(xRotation, -90f, 90f);

		// Rotate player around Y 
		playerRb.rotation = Quaternion.Euler(playerRb.rotation.eulerAngles + Vector3.up * mouseX);

		//Rotate Camera around X
		transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
	}
	void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
	}
}