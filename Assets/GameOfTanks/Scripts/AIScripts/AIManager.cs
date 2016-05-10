using UnityEngine;
using System.Collections;

public class AIManager : MonoBehaviour {

	public TankHealth playerHealth;      
	public GameObject bot;                
	public float spawnTime = 35f;           
	public Transform[] spawnPoints;         


	void Start (){
		InvokeRepeating ("Spawn", 2f, spawnTime);
	}


	void Spawn (){
		if(spawnTime>=20f)
			spawnTime -= 1f;
		if(playerHealth.empty()){
			return;
		}
		int spawnPointIndex = Random.Range (0, spawnPoints.Length);

		Instantiate (bot, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
	}
}
