using UnityEngine;
using System.Collections;

public class MoveGunAI : MonoBehaviour {
	public float speed = 15;
	public float curRotation = 0;
	public Camera cameraPlayer;
	TankControllerAI tankControllerAI;
	TankHealth AIhealth;  
	Transform player; 
	Transform firePoint;
	private Vector3 newRotation;

	void Start(){
		tankControllerAI = GetComponentInParent<TankControllerAI>();
	}

	void Awake(){
		AIhealth = GetComponentInParent <TankHealth> ();
		firePoint = GetComponentInChildren<Transform>();
	}

	void Update (){
		if(!AIhealth.empty()){
			
			if(!player){
				player = tankControllerAI.player;
				return;
			}

			RaycastHit hit;
			if (Physics.Raycast(firePoint.position, transform.forward, out hit, LayerMask.GetMask("Terrain"))){
				if(hit.collider.gameObject.tag == "Allies"){
					//tankControllerAI.NavStop();
					tankControllerAI.Fire();
				}else{
					//tankControllerAI.NavResume();
				}
			}

			Vector3 errorCorrecting = new Vector3(0,2,0);
			newRotation = Quaternion.LookRotation(player.position + errorCorrecting - transform.position).eulerAngles;

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
}