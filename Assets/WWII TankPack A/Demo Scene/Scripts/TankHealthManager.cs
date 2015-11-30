using UnityEngine;
using System.Collections;

public class TankHealthManager : MonoBehaviour {

	public int maxHealth;
	int currentHealth;
	
	void Start () {
		currentHealth = maxHealth;
	}

	public bool isDead(){
		return (currentHealth <= 0)? true:false;
	}

	public int getTankHealth(){
		return currentHealth;
	}
	public void subtractTankHealth(int health){
		currentHealth -= health;
	}

}
