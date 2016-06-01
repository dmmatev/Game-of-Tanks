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