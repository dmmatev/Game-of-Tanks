using UnityEngine;
using System.Collections;

public class ArmorManager : MonoBehaviour {

	public int armor;
	public TankHealthManager tankHealthManager;


	void Start () {

	}
	
	// Update is called once per frame
//	void Update () {
//	
//	}

	void OnCollisionEnter(Collision collision){
		if(!tankHealthManager.isDead()){
			// get the angle of the collision 
			// get the collider that colides with the armor
			// get the angle ot the collision (bounse or not)
			// generate number (for example from 300 to 410) for the dmg (this depends on the shell)
			tankHealthManager.subtractTankHealth(300);
		}
	}
}
