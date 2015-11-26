using UnityEngine;
using System.Collections;

/// MouseLook rotates the transform based on the mouse delta.
/// Minimum and Maximum values can be used to constrain the possible rotation

/// To make an FPS style character:
/// - Create a capsule.
/// - Add the MouseLook script to the capsule.
///   -> Set the mouse look to use LookX. (You want to only turn character but not tilt it)
/// - Add FPSInputController script to the capsule
///   -> A CharacterMotor and a CharacterController component will be automatically added.

/// - Create a camera. Make the camera a child of the capsule. Reset it's transform.
/// - Add a MouseLook script to the camera.
///   -> Set the mouse look to use LookY. (You want the camera to tilt up and down like a head. The character already turns.)
[AddComponentMenu("Camera-Control/Mouse Look")]
public class MouseLook : MonoBehaviour {
//
//	public Texture2D cursorImage;
//	public float speed = 3.0F;
//	public float rotateSpeed = 3.0F;
//	void Update() {
//		Screen.lockCursor = true;
//		Cursor.visible = false;
//		//MoveTurret controller = GetComponent<MoveTurret>();
//		transform.Rotate(Input.GetAxis ("Mouse Y") * rotateSpeed, Input.GetAxis ("Mouse X") * rotateSpeed, 0);
//		Vector3 forward = transform.TransformDirection(Vector3.forward);
//		float curSpeed = speed * Input.GetAxis("Vertical");
//		//controller.SimpleMove(forward * curSpeed);
//	}
//	void OnGUI() {
//		Vector3 mPos = Input.mousePosition;
//		GUI.DrawTexture(new Rect(mPos.x-32, Screen.height-mPos.y-32, 64, 64), cursorImage);
//	}
	
public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
	public RotationAxes axes = RotationAxes.MouseXAndY;
	public float sensitivityX = 15F;
	public float sensitivityY = 15F;
	
	public float minimumX = -360F;
	public float maximumX = 360F;
	
	public float minimumY = -60F;
	public float maximumY = 60F;
	
	float rotationY = 0F;
	
	void Update ()
	{
		if(!Input.GetButton("Ctrl")){
			Screen.lockCursor = true;
			Cursor.visible = false;
			if (axes == RotationAxes.MouseXAndY)
			{
				float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;
				
				rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
				rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
				
				transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
			}
			else if (axes == RotationAxes.MouseX)
			{
				transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
			}
			else
			{
				rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
				rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
				
				transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
			}
		}else {
			Screen.lockCursor = false;
			Cursor.visible = true;
		}
	}
	
	void Start ()
	{
		//if(!networkView.isMine)
		//enabled = false;
		
		// Make the rigid body not change rotation
		//if (rigidbody)
		//rigidbody.freezeRotation = true;
	}
}