using UnityEngine;
using System.Collections;

public class MoveTurretAI : MonoBehaviour {
	public float speed = 0.6f;
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