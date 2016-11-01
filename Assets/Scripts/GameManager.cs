using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static bool gamePaused=false;


	private LevelManager levelManager;



	void Start () {
		levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
	

	}

	void Update () {


	}


	public void resetGame(){

		levelManager.Retry ();
	}
		



	public void pauseGame(){
		gamePaused = true;
	}
	public void unPauseGame(){
		gamePaused = false;
	}

//	public void TapHappenedAtPosition(float xPos){
//	
//		Debug.Log ("xPos: " + xPos);
//	
//	}

//	public void DeathHappened(string reason){
//		if (!deathHasHappened) {
//			deathHasHappened = true;
//			gameStarted = false;
//			OpenDeathMenu (reason);
//			Debug.Log ("DEATH HAPPENED: " + reason);
//
//		}
//	}

//	void OpenDeathMenu(string reason){
//
//
//		switch (reason) {
//
//		case "timeout":
//			GameObject.Find("DeathReason").GetComponent<Text>().text = "Your time ran out!";
//			break;
//
//		default:
//			GameObject.Find("DeathReason").GetComponent<Text>().text = "You have died!";
//			break;
//
//		}
//		standardUI.enabled = false;
//		deathMenu.enabled = true;
//		GameObject.Find ("ScoreText").GetComponent<Text> ().text = scoreManager.Score().ToString();
//		GameObject.Find ("BonusText").GetComponent<Text> ().text = "0";
//		GameObject.Find ("PenaltyText").GetComponent<Text> ().text = (penaltyPoints*-1).ToString();
//		totalScoreOnDeath = scoreManager.Score () - penaltyPoints;
//		GameObject.Find ("TotalText").GetComponent<Text> ().text = totalScoreOnDeath.ToString();
//		GameObject.Find ("HighScoreText").GetComponent<Text> ().text = PlayerPrefs.GetInt (playerPrefsLevelScoreName,0).ToString();
//
//
//
//		CallPlayerPrefsAndSave (scoreManager.Score());
//
//	}

//	private void CallPlayerPrefsAndSave(int points){
//		
//
//		PlayerPrefs.SetInt ("Currency", PlayerPrefs.GetInt ("Currency") + totalScoreOnDeath); //add points as currency
//
//
//		if (PlayerPrefs.GetInt (playerPrefsLevelScoreName,0) < totalScoreOnDeath) //if score is higher than previous score for that level or 0, add PlayerPrefs entry for this level with score
//		{
//			PlayerPrefs.SetInt ("playerPrefsLevelScoreName", totalScoreOnDeath);
//		}
//	}
		

}
