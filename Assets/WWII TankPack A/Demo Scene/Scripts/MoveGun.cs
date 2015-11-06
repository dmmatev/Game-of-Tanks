using UnityEngine;
using System.Collections;

public class MoveGun : MonoBehaviour {
	float speed = 15;
	float curRotation = 0;
	
	
	void  Update (){
		
		// Gun Down
		if(Input.GetKey(KeyCode.W)) {
			if(curRotation > -5) {
				transform.Rotate(new Vector3(speed * Time.deltaTime, 0, 0));
				curRotation -= speed * Time.deltaTime;
			}
		}
		
		
		// Gun Up
		if(Input.GetKey(KeyCode.S)) {
			if(curRotation < 45) {
				transform.Rotate(new Vector3(-speed * Time.deltaTime, 0, 0));
				curRotation += speed * Time.deltaTime;
			}
		}
	}
}