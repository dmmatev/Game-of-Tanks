using UnityEngine;
using System.Collections;

public class MoveTurret : MonoBehaviour {
	public float speed = 30f;
	public Camera cameraPlayer;

	private Vector3 newRotation;
	
	void  Update (){
		
		// Turn Right
//		if (Input.GetKey (KeyCode.D)) 
//			transform.Rotate(new Vector3(0, speed * Time.deltaTime, 0));
		RaycastHit hit;
		Ray ray = cameraPlayer.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray, out hit, LayerMask.GetMask("Terrain"))){

			newRotation = Quaternion.LookRotation(hit.point - transform.position).eulerAngles;
			//			transform.Rotate(new Vector3(0, speed * Time.deltaTime, 0));
		}
		//transform.rotation = Quaternion.Euler(0f, newRotation.y , 0f);
		if(Mathf.Abs (newRotation.y) - Mathf.Abs(transform.rotation.y) < 1f){
			Debug.Log("THEY ARE THE SAME");
		}




		Debug.Log(newRotation.y);
		Debug.Log(transform.rotation.eulerAngles.y);
		if(Mathf.Abs (newRotation.y - transform.rotation.eulerAngles.y) > 1f){
			float currentRotationY = transform.rotation.eulerAngles.y;
			if(currentRotationY - newRotation.y < - 180 || currentRotationY - newRotation.y < 180 && currentRotationY - newRotation.y >= 0){
				transform.Rotate(0f, -speed , 0f);
			}else{
				transform.Rotate(0f, speed , 0f);
			}
		}
		
	}
}