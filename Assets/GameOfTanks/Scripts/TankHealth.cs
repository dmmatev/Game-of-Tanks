using UnityEngine;
using System.Collections;

public class TankHealth : MonoBehaviour {

	public int maxHealth;
	int currentHealth;
	
	void Start () {
		currentHealth = maxHealth;
	}

	public bool empty(){
		return currentHealth <= 0;
	}

	public int getTankHealth(){
		return currentHealth;
	}
	public void subtractTankHealth(int health){
		if(currentHealth >= health){
			currentHealth -= health;
		}else{
			currentHealth = 0;
		}
	}
	public void addHealth(int health){
		currentHealth +=health;
		if(currentHealth > maxHealth){
			currentHealth = maxHealth;
		}
	}

}
