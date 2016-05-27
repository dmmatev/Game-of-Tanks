using UnityEngine;
using System.Collections;

public class ExplosionAudio : MonoBehaviour {

	public AudioClip sound;
	private AudioSource source;
	float lowPitchRange = 0.75f;
	float highPitchRange = 1.25f;

	void Awake(){
		source = GetComponent<AudioSource>();
	}
	void Start(){
		System.Random rnd = new System.Random();
		source.pitch = (float) rnd.NextDouble() * (highPitchRange - lowPitchRange) + lowPitchRange;
		source.PlayOneShot(sound,1f);
	}

}
