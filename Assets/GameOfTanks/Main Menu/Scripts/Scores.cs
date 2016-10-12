using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Scores : MonoBehaviour {

	List<long> scores;

	void Awake () {
		DontDestroyOnLoad (transform.gameObject);
		scores = new List<long>();
		scores.Add(0);
		scores.Add(0);
		scores.Add(0);

	}

	public void addScore(long score){
		scores.Add(score);
	}

	public long Position(int x){
		var scoresDesc = scores.OrderByDescending(i => i).ToList();
		return scoresDesc[x];	
	}

}
