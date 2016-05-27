using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour {

	public Texture2D cursorImage;
	public float sensitivityX = 15F;
	public float sensitivityY = 15F;
	
	public float minimumX = -60F;
	public float maximumX = 60F;

	public float minFov = 15f;
	public float maxFov = 90f;
	public float sensitivity = 10f;
	
	float rotationY = 0f;
	float rotationX = 0f;
	public GameObject player;
	TankHealth playerHealth;

	void Awake(){
		playerHealth = player.GetComponentInParent<TankHealth>();
	}

	void cameraZoom () {
		float fov = Camera.main.fieldOfView;
		fov += Input.GetAxis("Mouse ScrollWheel") * sensitivity;
		fov = Mathf.Clamp(fov, minFov, maxFov);
		Camera.main.fieldOfView = fov;
	}

	void OnGUI() {
		Vector3 mPos = Input.mousePosition;
		GUI.DrawTexture(new Rect(mPos.x-64, Screen.height-mPos.y-64, 128, 128), cursorImage);
	}
	
	void Update (){
		if(!Input.GetButton("Ctrl") || playerHealth.empty()){
			Screen.lockCursor = true;
			Cursor.visible = false;
			cameraZoom();
			rotationY += Input.GetAxis("Mouse X") * sensitivityX;
			
			rotationX += Input.GetAxis("Mouse Y") * sensitivityY;
			rotationX = Mathf.Clamp (rotationX, minimumX, maximumX);
			
			transform.localEulerAngles = new Vector3(-rotationX, rotationY, 0);
			
		}else {
			Screen.lockCursor = false;
			Cursor.visible = true;
		}
	}

}