using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBarPlayer : MonoBehaviour
{
	TankHealth tankHealth;
	GameObject player; 
	int maxHealth;
	public float healthSpeed;
	Text healthText;
	Image visualHealth;
	float currentValue;

	void Start(){
		visualHealth = transform.Find("Background/HealthBackground/VisualHealth").GetComponent<Image>();
		healthText = transform.Find("Background/Text").GetComponent<Text>();
	}

	void Awake(){

//		player = GameObject.FindGameObjectWithTag("Allies");
//		tankHealth = player.GetComponent<TankHealth>();
//		maxHealth = tankHealth.maxHealth;
	}


	void Update(){

		HandleHealthbar();

	}

	private void HandleHealthbar(){  
		if(player == null){
			player = GameObject.FindGameObjectWithTag("Allies");
			tankHealth = player.GetComponent<TankHealth>();
			maxHealth = tankHealth.maxHealth;
		}
		healthText.text = "Health: " + tankHealth.getTankHealth();

		currentValue = Map(tankHealth.getTankHealth(), 0, maxHealth, 0, 1);

		visualHealth.fillAmount = Mathf.Lerp(visualHealth.fillAmount, currentValue, Time.deltaTime*healthSpeed);
		Debug.Log(visualHealth.fillAmount);

		if (tankHealth.getTankHealth() > maxHealth / 2) {
			visualHealth.color = new Color32((byte)Map(tankHealth.getTankHealth(), maxHealth / 2, maxHealth, 255, 0), 255, 0, 255);
		}
		else { 
			visualHealth.color = new Color32(255, (byte)Map(tankHealth.getTankHealth(), 0, maxHealth / 2, 0, 255), 0, 255);
		}
	}

	public float Map(float x, float in_min, float in_max, float out_min, float out_max){

		return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
	}
}
