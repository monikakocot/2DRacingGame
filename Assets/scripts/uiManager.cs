using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class uiManager : MonoBehaviour {
	
	public Button[] buttons;
	public Text scoreText;
	bool gameOver;
	int score;
	

	// Use this for initialization
	void Start () {
		gameOver = false;
		score = 0;
		InvokeRepeating ("scoreUpdate", 1.0f, 0.5f); //strat calling scoreUpdate function after 1,0 sekund, and every 0,5 sekunds
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = "Score: " + score;
	}

	void scoreUpdate(){
		if (gameOver == false) {
			score += 1;
		}
	}

	public void gameOverActivated(){
		gameOver = true;
		foreach (Button button in buttons) {
			button.gameObject.SetActive(true);
		}
	}

	public void Play(){
        Application.LoadLevel("level1");
	}

	public void Pause(){

        //When timeScale is 1.0 time passes as fast as realtime. When timeScale is 0.5 time passes 2x slower than realtime.
        //When timeScale is set to zero the game is basically paused if all your functions are frame rate independent.
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
		}
		else if (Time.timeScale == 0) {
			Time.timeScale = 1;
		}
	}
	
	public void Menu(){
		Application.LoadLevel ("menu");
	}
	public void Exit(){
		Application.Quit (); // to działa gdy gra jest zbuildowana
	}	
    
    //mine function
    public void Replay (){
        Application.LoadLevel(Application.loadedLevel);
	}
	

}
