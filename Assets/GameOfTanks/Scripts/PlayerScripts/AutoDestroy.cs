using UnityEngine;
using System.Collections;

public class AutoDestroy : MonoBehaviour {
	
	
	ParticleSystem tmpPtclObj;
	
	void  Awake (){
		tmpPtclObj = gameObject.GetComponent<ParticleSystem>();
	}
	
	void  Update (){
		if (tmpPtclObj.isStopped)
			Destroy(gameObject);
	}
}