using UnityEngine;
using System.Collections;

public class HealthPackController : MonoBehaviour {

	public int addAmountOfHealth = 500;
	public AudioClip sound;
	AudioSource audio;

	TankHealth playerHealth;

	void Awake () {
		audio = GetComponent<AudioSource>();
	}

	void OnCollisionEnter(Collision collision) {
		if(collision.gameObject.tag == "Allies"){
			playerHealth = collision.collider.GetComponent<TankHealth>();
			playerHealth.addHealth(addAmountOfHealth);

			audio.PlayOneShot(sound);
			GetComponent<BoxCollider>().isTrigger = true;
			GetComponentInChildren<Light>().color = new Color(127,255,0);
			GetComponentInChildren<Light>().intensity = 0.1f;
			Destroy(gameObject, sound.length); 
		}
	}

}
