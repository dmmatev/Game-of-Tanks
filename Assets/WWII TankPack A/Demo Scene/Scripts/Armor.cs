using UnityEngine;
using System.Collections;

public class Armor : MonoBehaviour {

	public int armor;
	private TankHealth tankHealthManager;


	void Start () {
		tankHealthManager = GetComponent<TankHealth>();

	}
	
	// Update is called once per frame
//	void Update () {
//
//	}

	void OnCollisionEnter(Collision collision){
		Debug.Log("I AM NOT HIT");
		Debug.Log(collision.gameObject.name);
		if(!tankHealthManager.isDead() && collision.gameObject.tag == "Shell"){
			Shell shell = collision.collider.GetComponent<Shell>();
			Debug.Log("I AM HIT");
			// get the angle of the collision 
			// get the collider that colides with the armor
			// get the angle ot the collision (bounse or not)
			// generate number (for example from 300 to 410) for the dmg (this depends on the shell)
			tankHealthManager.subtractTankHealth(shell.armorPenetrationMM);
		}
	}
}