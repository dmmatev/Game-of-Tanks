using UnityEngine;
using System.Collections;

public class starBattleAudio : MonoBehaviour {

	public AudioClip[] startBattleSound;
	AudioSource source;

	void Start(){
		source = GetComponent<AudioSource>();
		System.Random rnd = new System.Random();
		int number = rnd.Next(0, 1);
		source.PlayOneShot(startBattleSound[number]);
	}
}
