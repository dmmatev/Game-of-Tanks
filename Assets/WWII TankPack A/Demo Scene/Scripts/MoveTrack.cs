using UnityEngine;
using System.Collections;

public class MoveTrack : MonoBehaviour {
	
	
	public int currentTTIdx = 0;
	public  Texture[] trackTexturs;
	public float moveTick = 0.1f;
	public float speed = 40; //  km/h
	public int GearStatus = 0;
	
	
	void  Update (){

		switch (GearStatus) {
		case 0 : 
			// Neutral. do nothing
			break;
			
		case 1 : 
			// forward
			
			if (speed < 1)
				speed = 1;
			
			if (Time.time > moveTick) {
				currentTTIdx++;
				if (currentTTIdx >= trackTexturs.Length)
					currentTTIdx = 0;
				
				GetComponent<Renderer>().material.mainTexture = trackTexturs[currentTTIdx]; 
				  
				// One Texture made 4cm move
				moveTick = Time.time + 4 / (speed * 1000 / (60 * 60) * 100);
			}
			
			break;
			
		case 2 : 
			// backward
			if (speed < 1)
				speed = 1;
			
			if (Time.time > moveTick) {
				currentTTIdx--;
				if (currentTTIdx < 0)
					currentTTIdx = trackTexturs.Length - 1;
				
				GetComponent<Renderer>().material.mainTexture = trackTexturs[currentTTIdx]; 
				
				moveTick = Time.time + 4 / (speed * 1000 / (60 * 60) * 100);
			}
			
			break;
			
		}
		
	}
}