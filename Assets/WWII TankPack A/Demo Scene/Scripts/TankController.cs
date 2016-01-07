using UnityEngine;
using System.Collections;

public class TankController : MonoBehaviour {
	
	
	private MoveTrack leftTrack;
	private MoveTrack rightTrack;
	
	public float acceleration = 5;
	public float currentVelocity = 0;
	public float maxSpeed = 25;
	public float rotationSpeed = 30;
	public int armorPenetrationMM = 100;
	
	public Transform spawnPoint;
	public GameObject bulletObject;
	public GameObject fireEffect;
	
	void  Start (){
		
		// Get Track Controls
		leftTrack = GameObject.Find(gameObject.name + "/Lefttrack").GetComponent<MoveTrack>();
		rightTrack = GameObject.Find(gameObject.name + "/Righttrack").GetComponent<MoveTrack>();
		
	}
	
	
	void  Update (){
		
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
			// Move forward
			leftTrack.speed = currentVelocity;
			leftTrack.GearStatus = 1;
			rightTrack.speed = currentVelocity;
			rightTrack.GearStatus = 1;
		}
		else if (currentVelocity < 0)	{
			// Move Backward
			leftTrack.speed = -currentVelocity;
			leftTrack.GearStatus = 2;
			rightTrack.speed = -currentVelocity;
			rightTrack.GearStatus = 2;
		}
		else {
			// No Move
			leftTrack.GearStatus = 0;	
			rightTrack.GearStatus = 0;		
		}
		
		
		// Turn Tank
		if (Input.GetKey (KeyCode.LeftArrow)) {
			if (Input.GetKey(KeyCode.DownArrow)) {
				// Turn right
				transform.Rotate(new Vector3(0, rotationSpeed * Time.deltaTime, 0));
				
				leftTrack.speed = rotationSpeed;
				leftTrack.GearStatus = 1;
				rightTrack.speed = rotationSpeed;
				rightTrack.GearStatus = 2;
				
			} else {
				// Turn left
				transform.Rotate(new Vector3(0, -rotationSpeed * Time.deltaTime, 0));
				
				leftTrack.speed = rotationSpeed;
				leftTrack.GearStatus = 2;
				rightTrack.speed = rotationSpeed;
				rightTrack.GearStatus = 1;
				
			}
		}
		
		if (Input.GetKey (KeyCode.RightArrow)) {
			if (Input.GetKey(KeyCode.DownArrow)) {
				// Turn left
				transform.Rotate(new Vector3(0, -rotationSpeed * Time.deltaTime, 0));
				leftTrack.speed = rotationSpeed;
				leftTrack.GearStatus = 2;
				rightTrack.speed = rotationSpeed;
				rightTrack.GearStatus = 1;
				
			} else {
				// Turn right
				transform.Rotate(new Vector3(0, rotationSpeed * Time.deltaTime, 0));
				leftTrack.speed = rotationSpeed;
				leftTrack.GearStatus = 1;
				rightTrack.speed = rotationSpeed;
				rightTrack.GearStatus = 2;
				
			}
		}
		
		
		// Fire!
		if (Input.GetButtonDown("Fire1")) {
			// make fire effect.
			Instantiate(fireEffect, spawnPoint.position, spawnPoint.rotation);

			// make ball
			GameObject shell = Instantiate(bulletObject, spawnPoint.position, spawnPoint.rotation) as GameObject;
			shell.GetComponent<Shell>().armorPenetrationMM = armorPenetrationMM;
		}

	}
}