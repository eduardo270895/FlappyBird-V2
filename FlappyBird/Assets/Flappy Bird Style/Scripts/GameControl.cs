using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour 
{

	public static GameControl instance;			//Reference to our game control.
	public Text scoreText;						//Reference to the score
	public GameObject gameOvertext;				//It holds the gameover text
    private int score = 0;						//The player's score.
	public bool gameOver = false;				//holds the state of the game
	public float scrollSpeed = -1.5f;
    

	void Awake()
	{
		
		if (instance == null)
			
			instance = this;
		
		else if(instance != this)
			// Duplicate destruction
			Destroy (gameObject);
	}

	void Update()
	{
		//Once the game is over the player has pressed some input
		if (gameOver && Input.GetMouseButtonDown(0)) 
		{
			//Reload the scene
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}

	public void BirdScored()
	{
        //Cant score with the game over
        if (gameOver)
        { return; }
		//Incre the score while the game is on
		score++;
       
		//Update the score value
		scoreText.text = "Score: " + score.ToString();
	}

	public void BirdDied()
	{
		//Show the game over text.
        
		gameOvertext.SetActive (true);
		//Game to be over.
		gameOver = true;
	}
}
