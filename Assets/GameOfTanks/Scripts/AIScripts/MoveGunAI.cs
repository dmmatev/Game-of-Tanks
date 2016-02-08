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

	void  Update (){
		if(!AIhealth.empty()){
			
			if(!player){
				player = tankControllerAI.player;
				return;
			}

			RaycastHit hit;
			Ray ray = new Ray(firePoint.position, Vector3.forward);
			if (Physics.Raycast(ray, out hit, LayerMask.GetMask("Terrain"))){
				if(hit.collider.gameObject.tag == "Allies"){
					tankControllerAI.NavStop();
					tankControllerAI.Fire();
				}else{
					tankControllerAI.NavResume();
				}
			}
			//Debug.DrawRay(firePoint.position,hit.point);


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
}