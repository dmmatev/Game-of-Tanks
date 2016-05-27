using UnityEngine;
using System.Collections;
using System;

public class TankController : MonoBehaviour {
	
	
	MoveTrack leftTrack;
	MoveTrack rightTrack;
	TankHealth tankHealth;
	float currentTime;
	float distToGround;
	float timer = 0;
	AudioSource engineSource;
	float volLowRange = 0.5f;
	float volHighRange = 1.0f;
	
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
	public AudioClip shootSound;
	public AudioClip moveEngineSound;



	void  Start (){
		leftTrack = GameObject.Find(gameObject.name + "/Lefttrack").GetComponent<MoveTrack>();
		rightTrack = GameObject.Find(gameObject.name + "/Righttrack").GetComponent<MoveTrack>();
		tankHealth = GetComponent<TankHealth>();
		distToGround = GetComponent<Collider>().bounds.extents.y;
		gameObject.tag = "Allies";
		engineSource = GetComponent<AudioSource>();
	}

	void OnGUI() {
		Vector3 mPos = Input.mousePosition;
		if(timer <=0){
			GUI.Label(new Rect(mPos.x-100, Screen.height-mPos.y-10, 150, 150), reloadTime.ToString());
		}else{
			GUI.Label(new Rect(mPos.x-100, Screen.height-mPos.y-10, 150, 150), Math.Round(timer, 2).ToString());
		}
	}

	bool isGrounded(){
		return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
	}

	void Fire(){
		if(timer<=0){
			GameObject fire = Instantiate(fireEffect, spawnPoint.position, spawnPoint.rotation) as GameObject;
			fire.GetComponent<ExplosionAudio>().sound = shootSound;
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
			float pitch = currentVelocity/maxSpeed +0.3f;
			if((pitch >=0.3f && pitch <=1.1f) || (pitch <=-0.3f && pitch >=-1.1f) ){
				engineSource.pitch = pitch;	
			}
			if(timer>0){	
				timer -= Time.deltaTime;
			}
		
			if (Input.GetKey (KeyCode.W) && isGrounded()) {
				if (currentVelocity <= maxSpeed) 
					currentVelocity += acceleration * Time.deltaTime;
				
			} else if (Input.GetKey(KeyCode.S)  && isGrounded()) {

				if (currentVelocity >= -maxSpeed) 
					currentVelocity -= acceleration * Time.deltaTime;
				
			} else {
				if (currentVelocity > 0) 
					currentVelocity -= acceleration * Time.deltaTime;
				else if (currentVelocity < 0) 
					currentVelocity += acceleration * Time.deltaTime;
				
			}
			if (Mathf.Abs(currentVelocity) <= 0.05f)
				currentVelocity = 0;
			
			transform.Translate(new Vector3(0, 0, currentVelocity * Time.deltaTime));
			 
			if (currentVelocity > 0) {
				MoveTracksForward();
			}
			else if (currentVelocity < 0)	{
				MoveTracksBackward();
			}
			else {
				leftTrack.GearStatus = 0;	
				rightTrack.GearStatus = 0;		
			}

			if (Input.GetKey (KeyCode.A) && isGrounded()) {
				if (Input.GetKey(KeyCode.S)) {
					TurnRight();
				} else {
					TurnLeft();
				}
			}
			
			if (Input.GetKey (KeyCode.D) && isGrounded()) {
				if (Input.GetKey(KeyCode.S)) {
					TurnLeft();
				} else {
					TurnRight();
				}
			}
		
			if (Input.GetButtonDown("Fire1") && isGrounded()) {
					Fire();	
			}

		}
	}
}