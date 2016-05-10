using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour{
	static long score;
	Text text;

	void Awake (){
		
		text = GetComponent <Text> ();
		score = 0;
	}

	void Update (){
		
		text.text = "Score: " + score;
	}
	public void addScore(int newScore){
		score += newScore;
	}
	public long getScore(){
		return score;
	}
}