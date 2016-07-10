using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}


	public void Retry(){

		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}

	public void ReturnToMainMenu(){

		SceneManager.LoadScene(0);
	}
	public void StartGame(){

		SceneManager.LoadScene(1);
	}

	public string LoadedLevelName(){
	
		return SceneManager.GetActiveScene ().name;
	
	}

}