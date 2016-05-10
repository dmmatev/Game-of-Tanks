using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
	private int currentHealth;

	TankHealth tankHealth;
	GameObject player; 
	int maxHealth;
	public float healthSpeed;
	Text healthText;
	Image visualHealth;
	float currentValue;
	Canvas canvas;

	void Awake(){
		
		tankHealth = GetComponentInParent<TankHealth>();
		currentHealth = tankHealth.maxHealth; 
		player = GameObject.FindGameObjectWithTag("Allies");
	}


	void Update(){
		
		HandleHealthbar();

	}

	private void HandleHealthbar(){   
		if(player==null)
			player = GameObject.FindGameObjectWithTag("Allies");
		
		float dist = Vector3.Distance(player.transform.position, transform.position);
		if(dist>50)
			transform.localScale = new Vector3(-dist/600,dist/600,1);

		healthText.text = "Health: " + currentHealth;

		currentValue = Map(currentHealth, 0, maxHealth, 0, 1);

		visualHealth.fillAmount = Mathf.Lerp(visualHealth.fillAmount, currentValue, Time.deltaTime* healthSpeed);

 		if (currentHealth > maxHealth / 2) {
			visualHealth.color = new Color32((byte)Map(currentHealth, maxHealth / 2, maxHealth, 255, 0), 255, 0, 255);
		}
		else { 
			
			visualHealth.color = new Color32(255, (byte)Map(currentHealth, 0, maxHealth / 2, 0, 255), 0, 255);
		}
	}
		
	public float Map(float x, float in_min, float in_max, float out_min, float out_max){
		
		return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
	}
}
