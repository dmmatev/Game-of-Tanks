using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour {

	public TankHealth playerHealth;      
	public GameObject gobject;                
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

		Instantiate (gobject, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
	}
}
