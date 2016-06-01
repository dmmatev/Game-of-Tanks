using UnityEngine;
using System.Collections;

public class HealthPackController : MonoBehaviour {

	public int addAmountOfHealth = 500;

	TankHealth playerHealth;

	void Awake () {
		
	}

	void OnCollisionEnter(Collision collision) {
		if(collision.gameObject.tag == "Allies"){
			playerHealth = collision.collider.GetComponent<TankHealth>();
			playerHealth.addHealth(addAmountOfHealth);
			Destroy(gameObject);
		}
	}

}
