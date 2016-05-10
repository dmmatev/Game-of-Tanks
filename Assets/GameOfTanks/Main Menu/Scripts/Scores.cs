using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Scores : MonoBehaviour {

	List<long> scores;

	void Awake () {
		DontDestroyOnLoad (transform.gameObject);
		scores = new List<long>();
	}

	public void addScore(long score){
		scores.Add(score);
	}

	public long Position(int x){
		scores.Sort();
		return scores[x];
	}

}
