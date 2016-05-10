using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreController : MonoBehaviour{
	static long score;
	Text text;
	GameObject player;
	TankHealth playerHealth;
	GameObject scoreObject;
	Scores scoreManager;

	void Awake (){
		
		text = GetComponent <Text> ();
//		player = GameObject.FindGameObjectWithTag("Allies");
//		playerHealth = player.GetComponent<TankHealth>();
		scoreObject = GameObject.FindGameObjectWithTag("ScoreManager");
		scoreManager = scoreObject.GetComponent<Scores>();
		score = 0;
	}

	void Update (){
		if(!player){
			player = GameObject.FindGameObjectWithTag("Allies");
			playerHealth = player.GetComponent<TankHealth>();
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