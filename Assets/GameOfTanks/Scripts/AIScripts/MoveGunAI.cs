using UnityEngine;
using System.Collections;

public class MoveGunAI : MonoBehaviour {
	public float speed = 15;
	public float curRotation = 0;
	public Camera cameraPlayer;
	TankControllerAI tankControllerAI;
	Transform player; 
	private Vector3 newRotation;

	void Start(){
		tankControllerAI = GetComponentInParent<TankControllerAI>();
	}

	void  Update (){
		if(!player){
			player = tankControllerAI.player;
			return;
		}
		newRotation = Quaternion.LookRotation(player.position - transform.position).eulerAngles;

		if(Mathf.Abs (newRotation.x - transform.rotation.eulerAngles.x) > 1f){
			float currentRotationX = transform.rotation.eulerAngles.x;

			if((currentRotationX - newRotation.x < - 180 || currentRotationX - newRotation.x < 180 
				&& currentRotationX - newRotation.x >= 0) ){
				transform.Rotate(-speed * Time.deltaTime , 0f , 0f);
			}else{
				transform.Rotate(speed * Time.deltaTime , 0f , 0f);
			}
		}

	}
}