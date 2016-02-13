using UnityEngine;
using System.Collections;

public class TankController : MonoBehaviour {
	
	
	private MoveTrack leftTrack;
	private MoveTrack rightTrack;
	private TankHealth tankHealth;
	private float currentTime;
	private float distToGround;
	
	public float acceleration = 5f;
	public float reloadTime = 10f;
	public float currentVelocity = 0f;
	public float maxSpeed = 25f;
	public float rotationSpeed = 30f;
	public int armorPenetrationMM = 163;
	public int minDamage = 300;
	public int maxDamage = 410;
	
	public Transform spawnPoint;
	public GameObject bulletObject;
	public GameObject fireEffect;

	float timer = 0; 
	public float coolDown = 5f;


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
		Instantiate(fireEffect, spawnPoint.position, spawnPoint.rotation);

		GameObject shell = Instantiate(bulletObject, spawnPoint.position, spawnPoint.rotation) as GameObject;
		shell.GetComponent<Shell>().armorPenetrationMM = armorPenetrationMM;
		shell.GetComponent<Shell>().minDamage = minDamage;
		shell.GetComponent<Shell>().maxDamage = maxDamage;
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

	void MoveBackward(){
		leftTrack.speed = -currentVelocity;
		leftTrack.GearStatus = 2;
		rightTrack.speed = -currentVelocity;
		rightTrack.GearStatus = 2;
	}

	void MoveForward(){
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
			}
		
			if (Input.GetKey (KeyCode.UpArrow)) {
				// plus speed
				if (currentVelocity <= maxSpeed) 
					currentVelocity += acceleration * Time.deltaTime;
				
			} else if (Input.GetKey (KeyCode.DownArrow)) {
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
				MoveForward();
			}
			else if (currentVelocity < 0)	{
				MoveBackward();
			}
			else {
				// No Move
				leftTrack.GearStatus = 0;	
				rightTrack.GearStatus = 0;		
			}

			if (Input.GetKey (KeyCode.LeftArrow)) {
				if (Input.GetKey(KeyCode.DownArrow)) {
					TurnRight();
				} else {
					TurnLeft();
				}
			}
			
			if (Input.GetKey (KeyCode.RightArrow)) {
				if (Input.GetKey(KeyCode.DownArrow)) {
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