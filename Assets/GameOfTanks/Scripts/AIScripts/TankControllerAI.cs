using UnityEngine;
using System.Collections;

public class TankControllerAI: MonoBehaviour
{
	public Transform player;               
	TankHealth AIhealth;      
	TankHealth playerHealth;       
	NavMeshAgent nav;
	public Transform spawnPoint;
	public GameObject bulletObject;
	public GameObject fireEffect;

	public int armorPenetrationMM = 163;
	public int minDamage = 300;
	public int maxDamage = 410;
	public float reloadTime = 5f;

	private bool stop = false;
	private float timer = 0;


	public void Fire(){
		if(timer<=0){
			Instantiate(fireEffect, spawnPoint.position, spawnPoint.rotation);

			GameObject shell = Instantiate(bulletObject, spawnPoint.position, spawnPoint.rotation) as GameObject;
			shell.GetComponent<Shell>().armorPenetrationMM = armorPenetrationMM;
			shell.GetComponent<Shell>().minDamage = minDamage;
			shell.GetComponent<Shell>().maxDamage = maxDamage;
			timer = reloadTime;
		}
	}

	void Awake (){
		AIhealth = GetComponent <TankHealth> ();
		nav = GetComponent <NavMeshAgent> ();		
	}
	public void NavStop(){
		nav.Stop();
		stop = true;
	}

	public void NavResume(){
		nav.Resume();
		stop = false;
	}

	void Update (){
		if(!AIhealth.empty()){

			if(timer>0){
				timer -= Time.deltaTime;
			}

			
			if(!player){
				player = GameObject.FindGameObjectWithTag("Allies").transform;
				playerHealth = player.GetComponent <TankHealth> ();
			}

			//if(playerHealth.getTankHealth() > 0 && AIhealth.getTankHealth() > 0){
			if(!stop && AIhealth.getTankHealth() > 0){
				//nav.Resume();
				nav.SetDestination (player.position);
			}else if(!stop){
				
				nav.enabled = false;
				//nav.Stop();
			}
		}
	} 
}