using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Analytics;

public enum GameState 
{
	StartGameCountdown,
	InGame,
	Pause,
	LoseScreen
};

//public class GameStateManager : Singleton<GameStateManager> {
//
//	public GameObject planet;
//
//	private GameObject player;
//
//	private PlayerHealth playerHealth;
//	private PlayerControl playerControl;
//	private PlanetController planetController;
//	private Animator playerAnim;
//	private GameState gameState = GameState.InGame;
//
//	[SerializeField]
//	private float startGameTextCounter = 5.5f;
//	[SerializeField]
//	private float inGameTimeLimit = 60.0f;
//	[SerializeField]
//	private float endGameTextGameCounter = 5.5f;
//	[SerializeField]
//	private float restartLevelTime = 3.0f;
//	[SerializeField]
//	private Text gameStartText;
//	[SerializeField]
//	private Text gameTimerText;
//	[SerializeField]
//	private float restartDelay = 3.0f;
//
//	private float restartLevelStopwatch = 0.0f;
//	private bool gameStarted = false;
//
//	public GameState GetGameState()
//	{
//		return gameState;
//	}
//
//	public void SetGameState(GameState state)
//	{
//		gameState = state;
//	}
//
//	void Awake ()
//	{
//		player = GameObject.FindGameObjectWithTag ("Player");
//		playerHealth = player.GetComponent <PlayerHealth> ();
//		playerControl = player.GetComponent <PlayerControl> ();
//		planetController = planet.GetComponent <PlanetController> ();
//		playerAnim = player.GetComponent <Animator> ();
//	}
//
//	void Start()
//	{
//		ResetRestartLevelCounter();
//	}
//
//	void Update () {
//
//		if (Input.GetButtonDown ("PauseGame")) 
//		{
//			if(gameState == GameState.InGame) 
//			{
//				Time.timeScale = 0.0f;
//				SetGameState(GameState.Pause);
//			} 
//			else if(gameState == GameState.Pause) 
//			{
//				Time.timeScale = 1.0f;
//				SetGameState(GameState.InGame);
//			}
//			//gamePauseMenu.SetActive (false);
//			//Analytics.CustomEvent("GamePaused", null);
//		}
//
//		if (playerHealth.IsDead())
//		{
//			SetGameState(GameState.LoseScreen);
//		}
//
//	}			
//
//
//	void FixedUpdate () {
//
//		switch (gameState)
//		{
//		case GameState.StartGameCountdown:
//			//Analytics.CustomEvent("StartGameCountdown", null);
//
//			startGameTextCounter -= Time.deltaTime;
//			// 0.5f instead of 0.0f float->int casting
//			if (startGameTextCounter > 0.5f)
//			{
//				gameStartText.text = startGameTextCounter.ToString("F0");
//			}
//			else if (startGameTextCounter <= 0.5f)
//			{
//				//gameStartText.text = "BEGIN";
//				SetGameState(GameState.InGame);
//			}
//			break;
//
//		case GameState.InGame:
//			//Analytics.CustomEvent("GameStarted", null);
//			if (!gameStarted)
//			{
//				//gongSound.Play();
//				gameStarted = true;
//			}
//
//			//inGameTimeLimit -= Time.deltaTime;
//
//			// Start game "BEGIN" Sign
//			if (startGameTextCounter > -0.5)
//			{
//				startGameTextCounter -= Time.deltaTime;
//			}
//			else if (startGameTextCounter <= -0.5f)
//			{
//				//gameStartText.gameObject.SetActive(false);
//			}
//
//			break;
//
//		case GameState.LoseScreen:
//			//Analytics.CustomEvent("LoseScreen", null);
//			restartLevelStopwatch -= Time.deltaTime;
//
//			if (restartLevelStopwatch > 0.0f)
//			{
//				// Display some results 
//			}
//			else
//			{
//				playerHealth.Reset();
//				planetController.ResetRotationAngleZ();
//				ResetRestartLevelCounter();
//				SetGameState(GameState.InGame);
//			}
//			break;
//
//		case GameState.Pause:
//			//Analytics.CustomEvent("GamePaused", null);
//			break;
//		}
//
//	}
//
//	void ResetRestartLevelCounter()
//	{
//		restartLevelStopwatch = restartLevelTime;
//	}
//}
