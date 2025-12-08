using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoStylized
{
	public class CamearMovement : MonoBehaviour
	{
		public float slowSpeed;
		public float normalSpeed;
		public float sprintSpeed;
		float currentSpeed;

		public float sensitivity;	
		public float rotationSmoothTime = 0.1f; // tweak this for more/less smoothness
		private float pitch = 0f;
		private float yaw = 0f;
		private Vector2 currentRotation; // Smoothed version
		private Vector2 rotationVelocity; // For damping

		public Camera cam; // Drag your camera into this field in the Inspector
		public float zoomSpeed = 10f;
		public float minFOV = 20f;
		public float maxFOV = 90f;

		public KeyCode lockVerticalKey = KeyCode.Space;
		private bool lockVerticalMovement = false;

		void Start()
		{
			// Extract initial rotation from transform
			Vector3 euler = transform.rotation.eulerAngles;
			pitch = euler.x;
			yaw = euler.y;
			currentRotation = new Vector2(pitch, yaw);			
			
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}	
		
		void Update()
		{
			Movement();
			Rotation();
							
			float scroll = Input.GetAxis("Mouse ScrollWheel");
			if (Mathf.Abs(scroll) > 0.01f)
			{
				cam.fieldOfView -= scroll * zoomSpeed;
				cam.fieldOfView = Mathf.Clamp(cam.fieldOfView, minFOV, maxFOV);
			}
			
			if (Input.GetKeyDown(lockVerticalKey))
			{
				lockVerticalMovement = !lockVerticalMovement;
			}
			
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;
			}
		}
		
		public void Movement()
		{
			Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

			// Vertical movement via Q/E
			if (Input.GetKey(KeyCode.E))
			{
				input.y += 1f;
			}
			if (Input.GetKey(KeyCode.Q))
			{
				input.y -= 1f;
			}

			// Speed selection
			if (Input.GetKey(KeyCode.LeftShift))
			{
				currentSpeed = sprintSpeed;
			}
			else if (Input.GetKey(KeyCode.LeftControl))
			{
				currentSpeed = slowSpeed;
			}
			else
			{
				currentSpeed = normalSpeed;
			}

			Vector3 moveDirection = transform.TransformDirection(input);

			if (lockVerticalMovement)
			{
				// Remove vertical movement from the direction
				moveDirection.y = 0f;
				moveDirection.Normalize(); // Prevent speed loss from zeroing y
			}

			transform.position += moveDirection * currentSpeed * Time.deltaTime;
		}

		public void Rotation()
		{
			// Read mouse input
			float mouseX = Input.GetAxis("Mouse X") * sensitivity;
			float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

			// Update raw yaw/pitch
			yaw += mouseX;
			pitch -= mouseY;
			pitch = Mathf.Clamp(pitch, -89f, 89f);

			// Smooth current rotation toward target (yaw, pitch)
			currentRotation = Vector2.SmoothDamp(currentRotation, new Vector2(pitch, yaw), ref rotationVelocity, rotationSmoothTime);

			// Apply rotation (note: Z is zeroed)
			transform.rotation = Quaternion.Euler(currentRotation.x, currentRotation.y, 0f);
		}
	}
}