using UnityEngine;
using System.Collections;

public class MoveGun : MonoBehaviour {
	public float speed = 15;
	public float curRotation = 0;
	public Camera cameraPlayer;
	private Vector3 newRotation;
	
	
	void  Update (){

		RaycastHit hit;
		Ray ray = cameraPlayer.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray, out hit, LayerMask.GetMask("Terrain"))){
			
			newRotation = Quaternion.LookRotation(hit.point - transform.position).eulerAngles;
		}

		Debug.Log(newRotation.x);
		//Debug.Log(transform.rotation.eulerAngles.x);
		if(Mathf.Abs (newRotation.x - transform.rotation.eulerAngles.x) > 1f){
			float currentRotationX = transform.rotation.eulerAngles.x;
//			if(currentRotationY - newRotation.y < - 180 || currentRotationY - newRotation.y < 180 && currentRotationY - newRotation.y >= 0){
//				transform.Rotate(0f, -speed , 0f);
//			}else{
//				transform.Rotate(0f, speed , 0f);
//			}
			if(currentRotationX - newRotation.x < - 180 || currentRotationX - newRotation.x < 180 
			   && currentRotationX - newRotation.x >= 0 && curRotation > -5){
				transform.Rotate(-speed * Time.deltaTime , 0f , 0f);
			}else if(curRotation < 45){
				transform.Rotate(speed * Time.deltaTime , 0f , 0f);
			}
		}
		
//		// Gun Down
//		if(Input.GetKey(KeyCode.W)) {
//			if(curRotation > -5) {
//				transform.Rotate(new Vector3(speed * Time.deltaTime, 0, 0));
//				curRotation -= speed * Time.deltaTime;
//			}
//		}
//		
//		
//		// Gun Up
//		if(Input.GetKey(KeyCode.S)) {
//			if(curRotation < 45) {
//				transform.Rotate(new Vector3(-speed * Time.deltaTime, 0, 0));
//				curRotation += speed * Time.deltaTime;
//			}
//		}
	}
}