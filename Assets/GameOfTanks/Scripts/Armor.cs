using UnityEngine;
using System.Collections;

public class Armor : MonoBehaviour {

	public int armor;
	private TankHealth tankHealthManager;


	void Start () {
		tankHealthManager = GetComponent<TankHealth>();

	}

	void OnCollisionEnter(Collision collision){
		if(!tankHealthManager.empty() && collision.gameObject.tag == "Shell"){
			Shell shell = collision.collider.GetComponent<Shell>();
			// get the angle of the collision 
			// get the angle ot the collision (bounse or not)
			if(armor< shell.armorPenetrationMM){
				tankHealthManager.subtractTankHealth(shell.getDamage());
			}
		}
	}
}