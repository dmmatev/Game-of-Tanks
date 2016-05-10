using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PositionScore : MonoBehaviour {
	
	public int position;
	Text text;
	GameObject scoreObject;
	Scores scoreManager;

	void Awake () {
		text = GetComponent<Text>();
	}

	void Update () {
		if(!scoreManager){
			scoreObject = GameObject.FindGameObjectWithTag("ScoreManager");
			scoreManager = scoreObject.GetComponent<Scores>();
		}
		text.text = scoreManager.Position(position).ToString();
	}
}
