using UnityEngine;
using System.Collections;

public class SmoothCameraFolow : MonoBehaviour {
	public Transform target;

	public float distance = 10.0f;

	public float height = 5.0f;

	public float heightDamping = 2.0f;
	public float rotationDamping = 3.0f;
	Camera cam;

	void Start(){
		cam = GetComponent<Camera>();
	}

	void Awake(){
		float wantedRotationAngle = target.eulerAngles.y;
		float currentRotationAngle = transform.eulerAngles.y;
		currentRotationAngle = Mathf.LerpAngle (currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);
		Quaternion currentRotation = Quaternion.Euler (0, currentRotationAngle, 0);
		transform.position = target.position;
		transform.position -= currentRotation * Vector3.forward * distance;
	}


	void  LateUpdate (){

		RaycastHit hit;
		Ray ray = cam.ScreenPointToRay(Input.mousePosition);

		Physics.Raycast(ray, out hit, LayerMask.GetMask("Terrain"));
		//Debug.DrawRay(transform.position,hit.point);

		if (!target)
			return;

		float wantedRotationAngle = target.eulerAngles.y;
		float wantedHeight = target.position.y + height;

		float currentRotationAngle = transform.eulerAngles.y;
		float currentHeight = transform.position.y;

		currentRotationAngle = Mathf.LerpAngle (currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);
	
		currentHeight = Mathf.Lerp (currentHeight, wantedHeight, heightDamping * Time.deltaTime);
	
		Quaternion currentRotation = Quaternion.Euler (0, currentRotationAngle, 0);

		transform.position = target.position;
		transform.position -= currentRotation * Vector3.forward * distance; // Vector3.forward


		transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);

	}
}