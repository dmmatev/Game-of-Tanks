using UnityEngine;
using System.Collections;

public class TankBotController	 : MonoBehaviour
{
	Transform enemy;               
	TankHealth health;      
	TankHealth enemyHealth;       
	NavMeshAgent nav;               


	void Awake (){
		health = GetComponent <TankHealth> ();
		nav = GetComponent <NavMeshAgent> ();		
	}


	void Update (){
		if(!enemy){
			enemy = GameObject.FindGameObjectWithTag("Player").transform;
			enemyHealth = enemy.GetComponent <TankHealth> ();
		}

		if(enemyHealth.getTankHealth() > 0 && health.getTankHealth() > 0){
			//nav.Resume();
			nav.SetDestination (enemy.position);
		}else{
			
			nav.enabled = false;
			//nav.Stop();
		}
	} 
}