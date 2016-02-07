using UnityEngine;
using System.Collections;

public class TankBotController	 : MonoBehaviour
{
	Transform enemy;               
	TankHealth health;      
	TankHealth enemyHealth;       
	NavMeshAgent nav;               


	void Awake (){
		//player = GameObject.FindGameObjectWithTag("Player").transform;
//		health = player.GetComponent <TankHealth> ();
		health = GetComponent <TankHealth> ();
		nav = GetComponent <NavMeshAgent> ();		
	}


	void Update (){
		if(!enemy){
			enemy = GameObject.FindGameObjectWithTag("Player").transform;
			enemyHealth = enemy.GetComponent <TankHealth> ();
		}

		if(enemyHealth.getTankHealth() > 0 && health.getTankHealth() > 0){
			nav.SetDestination (enemy.position);
		}else{
			
			nav.enabled = false;
		}
	} 
}