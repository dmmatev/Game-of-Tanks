using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PositionScore : MonoBehaviour {
	
	public int position;
	Text text;
	GameObject scoreObject;
	Scores scoreManager;

	void Awake () {
		text = GetComponentInChildren<Text>();
	}

	void Update () {
		if(!scoreManager){
			scoreObject = GameObject.FindGameObjectWithTag("ScoreManager");
			scoreManager = scoreObject.GetComponent<Scores>();
		}
		text.text = position+1 + ": " + scoreManager.Position(position).ToString();
	}
}
