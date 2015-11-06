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
		if(Mathf.Abs (newRotation.y) - Mathf.Abs(transform.rotation.eulerAngles.y) > 1f){
			//transform.Rotate(0f, Mathf.Lerp(transform.rotation.y,newRotation.y,0.3f), 0f);
			if(newRotation.y > transform.rotation.eulerAngles.y){
				transform.Rotate(0f, speed , 0f);
			}else if(newRotation.y < transform.rotation.eulerAngles.y){
				transform.Rotate(0f, -speed , 0f);
			}
			//transform.Rotate(0f, newRotation.y * speed * Time.deltaTime, 0f);
		}

//		if(Input.GetAxis("Mouse X") > 0f) {
//			transform.Rotate(0f, speed , 0f);
//		}
//		if(Input.GetAxis("Mouse X") < 0f) {
//			transform.Rotate(0f, -speed , 0f);
//		}
		//transform.eulerAngles = new Vector3(transform.eulerAngles.x, newRotation.y, transform.eulerAngles.z);



		//transform.LookAt(new Vector3(0f, Mathf.Lerp(newDistance.y, transform.position.y, speed * Time.deltaTime)));

		//transform.Rotate(newDistance );


		// Turn Left
//		if (Input.GetKey (KeyCode.A)) 
//			transform.Rotate(new Vector3(0, -speed * Time.deltaTime, 0));
		
	}
}