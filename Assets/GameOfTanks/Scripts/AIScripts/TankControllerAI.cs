using UnityEngine;
using System.Collections;

public class TankControllerAI: MonoBehaviour
{
	public Transform player;               
	TankHealth AIhealth;      
	TankHealth playerHealth;       
	NavMeshAgent nav;               


	void Awake (){
		AIhealth = GetComponent <TankHealth> ();
		nav = GetComponent <NavMeshAgent> ();		
	}


	void Update (){
		if(!player){
			player = GameObject.FindGameObjectWithTag("Player").transform;
			playerHealth = player.GetComponent <TankHealth> ();
		}

		if(playerHealth.getTankHealth() > 0 && AIhealth.getTankHealth() > 0){
			//nav.Resume();
			nav.SetDestination (player.position);
		}else{
			
			nav.enabled = false;
			//nav.Stop();
		}
	} 
}