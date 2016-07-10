using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public bool gameStarted = false;
	private bool deathHasHappened = false;

	private int penaltyPoints=0;

	public static bool gamePaused=false;
	private string playerPrefsLevelScoreName = "";
	private ScoreManager scoreManager;
	private LevelManager levelManager;
	private Canvas standardUI, deathMenu;

	private int totalScoreOnDeath;
	// Use this for initialization
	void Start () {
		levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
		scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager> ();

		standardUI = GameObject.Find ("StandardCanvas").GetComponent<Canvas> ();
		deathMenu = GameObject.Find ("DeathCanvas").GetComponent<Canvas> ();
		playerPrefsLevelScoreName = levelManager.LoadedLevelName () + "Score";


	

	}
	
	// Update is called once per frame
	void Update () {

		if (!deathHasHappened && gameStarted && !gamePaused) {

		}


	}


	public void resetGame(){
		deathHasHappened = false;
		gameStarted = false;
		levelManager.Retry ();
	}
		



	public void pauseGame(){
		gamePaused = true;
	}
	public void unPauseGame(){
		gamePaused = false;
	}

	public void TapHappenedAtPosition(float xPos){
	
		Debug.Log ("xPos: " + xPos);
	
	}

	public void DeathHappened(string reason){
		if (!deathHasHappened) {
			deathHasHappened = true;
			gameStarted = false;
			OpenDeathMenu (reason);
			Debug.Log ("DEATH HAPPENED: " + reason);

		}
	}

	void OpenDeathMenu(string reason){


		switch (reason) {

		case "timeout":
			GameObject.Find("DeathReason").GetComponent<Text>().text = "Your time ran out!";
			break;

		default:
			GameObject.Find("DeathReason").GetComponent<Text>().text = "You have died!";
			break;

		}
		standardUI.enabled = false;
		deathMenu.enabled = true;
		GameObject.Find ("ScoreText").GetComponent<Text> ().text = scoreManager.Score().ToString();
		GameObject.Find ("BonusText").GetComponent<Text> ().text = "0";
		GameObject.Find ("PenaltyText").GetComponent<Text> ().text = (penaltyPoints*-1).ToString();
		totalScoreOnDeath = scoreManager.Score () - penaltyPoints;
		GameObject.Find ("TotalText").GetComponent<Text> ().text = totalScoreOnDeath.ToString();
		GameObject.Find ("HighScoreText").GetComponent<Text> ().text = PlayerPrefs.GetInt (playerPrefsLevelScoreName,0).ToString();



		CallPlayerPrefsAndSave (scoreManager.Score());

	}

	private void CallPlayerPrefsAndSave(int points){
		

		PlayerPrefs.SetInt ("Currency", PlayerPrefs.GetInt ("Currency") + totalScoreOnDeath); //add points as currency


		if (PlayerPrefs.GetInt (playerPrefsLevelScoreName,0) < totalScoreOnDeath) //if score is higher than previous score for that level or 0, add PlayerPrefs entry for this level with score
		{
			PlayerPrefs.SetInt ("playerPrefsLevelScoreName", totalScoreOnDeath);
		}
	}
		

}
