using UnityEngine;
using System.Collections;

public class TankController : MonoBehaviour {
	
	
	MoveTrack leftTrack;
	MoveTrack rightTrack;
	TankHealth tankHealth;
	float currentTime;
	float distToGround;
	float timer = 0;
	
	public float acceleration = 5f;
	public float reloadTime = 5f;
	public float currentVelocity = 0f;
	public float maxSpeed = 25f;
	public float rotationSpeed = 30f;
	public int armorPenetrationMM = 163;
	public int minDamage = 300;
	public int maxDamage = 410;
	
	public Transform spawnPoint;
	public GameObject bulletObject;
	public GameObject fireEffect;


	void  Start (){
		leftTrack = GameObject.Find(gameObject.name + "/Lefttrack").GetComponent<MoveTrack>();
		rightTrack = GameObject.Find(gameObject.name + "/Righttrack").GetComponent<MoveTrack>();
		tankHealth = GetComponent<TankHealth>();
		distToGround = GetComponent<Collider>().bounds.extents.y;
		gameObject.tag = "Allies";
		
	}

	bool isGrounded(){
		return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
	}

	void Fire(){
		if(timer<=0){
			Instantiate(fireEffect, spawnPoint.position, spawnPoint.rotation);

			GameObject shell = Instantiate(bulletObject, spawnPoint.position, spawnPoint.rotation) as GameObject;
			shell.GetComponent<Shell>().armorPenetrationMM = armorPenetrationMM;
			shell.GetComponent<Shell>().minDamage = minDamage;
			shell.GetComponent<Shell>().maxDamage = maxDamage;
			timer = reloadTime;
		}
	}

	void TurnRight(){
		transform.Rotate(new Vector3(0, rotationSpeed * Time.deltaTime, 0));
		leftTrack.speed = rotationSpeed;
		leftTrack.GearStatus = 1;
		rightTrack.speed = rotationSpeed;
		rightTrack.GearStatus = 2;
	}

	void TurnLeft(){
		transform.Rotate(new Vector3(0, -rotationSpeed * Time.deltaTime, 0));
		leftTrack.speed = rotationSpeed;
		leftTrack.GearStatus = 2;
		rightTrack.speed = rotationSpeed;
		rightTrack.GearStatus = 1;
	}

	void MoveTracksBackward(){
		leftTrack.speed = -currentVelocity;
		leftTrack.GearStatus = 2;
		rightTrack.speed = -currentVelocity;
		rightTrack.GearStatus = 2;
	}

	void MoveTracksForward(){
		leftTrack.speed = currentVelocity;
		leftTrack.GearStatus = 1;
		rightTrack.speed = currentVelocity;
		rightTrack.GearStatus = 1;
	}

	void FixedUpdate(){
		
	}
	
	void  Update (){
		if(!tankHealth.empty()){
			
			if(timer>0){
				timer -= Time.deltaTime;
				Debug.Log(timer);
			}
		
			if (Input.GetKey (KeyCode.W)) {
				// plus speed
				if (currentVelocity <= maxSpeed) 
					currentVelocity += acceleration * Time.deltaTime;
				
			} else if (Input.GetKey(KeyCode.S)) {
				// minus speed
				if (currentVelocity >= -maxSpeed) 
					currentVelocity -= acceleration * Time.deltaTime;
				
			} else {
				// No key input. 
				if (currentVelocity > 0) 
					currentVelocity -= acceleration * Time.deltaTime;
				else if (currentVelocity < 0) 
					currentVelocity += acceleration * Time.deltaTime;
				
			}
			// Turn off engine if currentVelocity is too small. 
			if (Mathf.Abs(currentVelocity) <= 0.05f)
				currentVelocity = 0;
			
			// Move Tank by currentVelocity
			transform.Translate(new Vector3(0, 0, currentVelocity * Time.deltaTime));
			
			// Move Tracks by currentVelocity	 
			if (currentVelocity > 0) {
				MoveTracksForward();
			}
			else if (currentVelocity < 0)	{
				MoveTracksBackward();
			}
			else {
				// No Move
				leftTrack.GearStatus = 0;	
				rightTrack.GearStatus = 0;		
			}

			if (Input.GetKey (KeyCode.A)) {
				if (Input.GetKey(KeyCode.S)) {
					TurnRight();
				} else {
					TurnLeft();
				}
			}
			
			if (Input.GetKey (KeyCode.D)) {
				if (Input.GetKey(KeyCode.S)) {
					TurnLeft();
				} else {
					TurnRight();
				}
			}
		
			if (Input.GetButtonDown("Fire1") ) {
					Fire();	
			}

		}
	}
}