using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreController : MonoBehaviour{
	long score;
	Text text;
	GameObject player;
	TankHealth playerHealth;
	GameObject scoreObject;
	Scores scoreManager;

	void Start (){
		
		text = GetComponent <Text> ();
		score = 0;
	}

	void Update (){
		if(!player || !scoreManager){
			player = GameObject.FindGameObjectWithTag("Allies");
			playerHealth = player.GetComponent<TankHealth>();
			scoreObject = GameObject.FindGameObjectWithTag("ScoreManager");
			scoreManager = scoreObject.GetComponent<Scores>();
		}
		
		text.text = "Score: " + score;
		if(playerHealth.empty()){
			scoreManager.addScore(score);
			Application.LoadLevel("MainMenu");
		}
	}
	public void addScore(int newScore){
		score += newScore;
	}
	public long getScore(){
		return score;
	}
}