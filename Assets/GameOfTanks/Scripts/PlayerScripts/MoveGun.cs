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
		//Debug.DrawRay(transform.position,hit.point);

		//Debug.Log(newRotation.x);
		//Debug.Log(transform.rotation.eulerAngles.x);
		if(Mathf.Abs (newRotation.x - transform.rotation.eulerAngles.x) > 1f){
			float currentRotationX = transform.rotation.eulerAngles.x;
			//Debug.Log(currentRotationX);
			if((currentRotationX - newRotation.x < - 180 || currentRotationX - newRotation.x < 180 
				&& currentRotationX - newRotation.x >= 0) ){
//				&& ((currentRotationX >= 320 && currentRotationX <= 359)
//					|| (currentRotationX >= 0 && currentRotationX <= 10))){

				transform.Rotate(-speed * Time.deltaTime , 0f , 0f);
//			}else if((currentRotationX >= 0 && currentRotationX <= 10) 
//				|| (currentRotationX >= 320 && currentRotationX <= 359)){
			}else{
				transform.Rotate(speed * Time.deltaTime , 0f , 0f);
			}
		}

	}
}