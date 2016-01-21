using UnityEngine;
using System.Collections;

public class Shell : MonoBehaviour {
	
	
	private float speed = 200;
	private float range = 400;
	public int minDamage = 300;
	public int maxDamage = 410;
	private int damage;
	public int armorPenetrationMM = 100;	
	public GameObject ExploPtcl;
	
	private float dist;
	
	void  Update (){

		// Move Ball forward
		transform.Translate(Vector3.forward * Time.deltaTime * speed);
		
		// Record Distance.
		dist += Time.deltaTime * speed;
		// If reach to my range, Destroy. 
		if(dist >= range) {
			Instantiate(ExploPtcl, transform.position, transform.rotation);
			Destroy(gameObject);
		}
	}
	public int getDamage(){
		
		System.Random rnd = new System.Random();
		damage = rnd.Next(minDamage, maxDamage);

		return damage;
	}
	
	void  OnTriggerEnter ( Collider other  ){
		// If hit something, Destroy. 
		Instantiate(ExploPtcl, transform.position, transform.rotation);
		Destroy(gameObject);
	}
	
}