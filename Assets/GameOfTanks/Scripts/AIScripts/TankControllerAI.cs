using UnityEngine;
using System.Collections;

public class TankControllerAI: MonoBehaviour
{
	public Transform player;               
	TankHealth AIhealth;      
	TankHealth playerHealth;       
	NavMeshAgent nav;
	Transform canvas;
	ScoreController scoreManager;
	public Transform firePoint;
	public GameObject bulletObject;
	public GameObject fireEffect;
	public GameObject deathExplosion;
	public int score;
	bool isSinking = false;

	public int armorPenetrationMM = 163;
	public int minDamage = 300;
	public int maxDamage = 410;
	public float reloadTime = 5f;
	public float sinkSpeed = 2.5f; 

	private bool stop = false;
	private float timer = 0;



	public void Fire(){
		if(timer<=0){
			Instantiate(fireEffect, firePoint.position, firePoint.rotation);

			GameObject shell = Instantiate(bulletObject, firePoint.position, firePoint.rotation) as GameObject;
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

	public void Explode(){
		Instantiate(deathExplosion, transform.position, transform.rotation);
	}
	public void StartSinking ()
	{
		GetComponent <NavMeshAgent> ().enabled = false;
		GetComponent <Rigidbody> ().isKinematic = true;
		if(!isSinking)
			scoreManager.addScore(score);
		isSinking = true;

		Destroy (gameObject, 2f);
	}

	void Update (){
		if(isSinking)
		{
			transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
		}
		if(!canvas){
			canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Transform>();
			scoreManager = canvas.Find("Score").GetComponent<ScoreController>();
		}
		
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
		}else {
			Explode();
			StartSinking();
		}
	} 
}