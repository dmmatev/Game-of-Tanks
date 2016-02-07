using UnityEngine;
using System.Collections;

public class TankBotController	 : MonoBehaviour
{
	Transform player;               
	TankHealth health;      
	TankHealth enemyHealth;       
	NavMeshAgent nav;               


	void Awake (){
		player = GameObject.FindGameObjectWithTag("Player").transform;
		health = player.GetComponent <TankHealth> ();
		enemyHealth = GetComponent <TankHealth> ();
		nav = GetComponent <NavMeshAgent> ();	
	}


	void Update (){

		if(enemyHealth.getTankHealth() > 0 && health.getTankHealth() > 0){
			
			nav.SetDestination (player.position);
		}else{
			
			nav.enabled = false;
		}
	} 
}