using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {
	private int levelPoints = 0;
	// Use this for initialization

	public void ChangePoints (int changedPoints){
		levelPoints += changedPoints;
	}
		

	public int Score(){
	
		return levelPoints;

	}
}
