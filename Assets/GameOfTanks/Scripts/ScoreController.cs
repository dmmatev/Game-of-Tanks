using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class ScoreController : MonoBehaviour{

	IEnumerator Wait() {
		isWaiting = true;
		yield return new WaitForSeconds(2f);
		isWaiting = false;
	}

	bool isWaiting = true;
	bool scoreSent = false;
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
			if(!scoreSent){
				scoreManager.addScore(score);
				scoreSent = true;
			}
			if(isWaiting)
				StartCoroutine(Wait());
			if(!isWaiting)
				SceneManager.LoadScene("MainMenu");
		}
	}
	public void addScore(int newScore){
		score += newScore;
	}
	public long getScore(){
		return score;
	}
}