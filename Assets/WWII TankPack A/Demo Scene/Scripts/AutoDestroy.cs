using UnityEngine;
using System.Collections;

public class AutoDestroy : MonoBehaviour {
	
	
	ParticleSystem tmpPtclObj;
	
	void  Awake (){
		// get my ParticleSystem
		tmpPtclObj = gameObject.GetComponent<ParticleSystem>();
	}
	
	void  Update (){
		// When it finish the play, Destroy.
		if (tmpPtclObj.isStopped)
			Destroy(gameObject);
	}
}