using UnityEngine;
using System.Collections;

public class HealthBarFacingCamera : MonoBehaviour
{
	public Camera camera;

	void Awake(){
		camera = Camera.main;
	}

	void Update()
	{
		transform.LookAt(transform.position + camera.transform.rotation * Vector3.back,
			camera.transform.rotation * Vector3.up);
	}
}