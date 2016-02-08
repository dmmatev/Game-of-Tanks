using UnityEngine;
using System.Collections;

public class Shell : MonoBehaviour {
	
	
	private float speed = 200;
	private float range = 2f;
	public int minDamage = 300;
	public int maxDamage = 410;
	private int damage;
	public int armorPenetrationMM = 100;	
	public GameObject ExploPtcl;
	
	private float dist;

	void  Update (){
		transform.Translate(Vector3.forward * Time.deltaTime * speed);
		dist += Time.deltaTime;
	 
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
	
	void OnCollisionEnter(Collision collision){

		Instantiate(ExploPtcl, transform.position, transform.rotation);
		Destroy(gameObject);
	}
	
}