/*
 *      Authors: Tony Bogun, Leonti Brechka, Baljinder Tanda, Hao Jiang
 *      Last Modified By: Leonti Brechka
 *      Date Modified: 2017-04-15
 *      Description: Main controller of the game, controls all three level activities
 *      Version: 3.0 
 */

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level1Controller : MonoBehaviour {
	private int _livesValue;
	private int _scoreValue;
	private AudioSource _endGameSound;


    // Vars for testing
    public int cloudNumber = 3;
	public GameObject cloud;

	[Header("UI Objects")]
	public Text LivesLabel;
	public Text ScoreLabel;
	public Text GameOverLabel;
	public Text FinalScoreLabel;
	public Button RestartButton;

	[Header("Game Objects")]
	public GameObject zombie;
    public GameObject planet;

    //Lives value property getter and setter
    public int LivesValue {
		get {
			return this._livesValue;
		}

		set {
			this._livesValue = value;
			if (this._livesValue <= 0) {
				this._endGame ();
			} else {
				this.LivesLabel.text = "Lives: " + this._livesValue;
			}
		}
	}
    
    // Score value property getter and setter
	public int ScoreValue {
		get {
			return this._scoreValue;
		}

		set {
			this._scoreValue = value;
			this.ScoreLabel.text = "Score: " + this._scoreValue;
			if (this._scoreValue == 500 && SceneManager.GetActiveScene().name == "Level1") {
				SceneManager.LoadScene ("Level2");
            }
            else if (this._scoreValue == 1000 && SceneManager.GetActiveScene().name == "Level2")
            {
                SceneManager.LoadScene("Level3");         
            }
        }
	}

	// This is for initialization
	void Start () {
		this.LivesValue = 5;
		this.ScoreValue = 0;

		this.GameOverLabel.gameObject.SetActive (false);
		this.FinalScoreLabel.gameObject.SetActive (false);
		this.RestartButton.gameObject.SetActive (false);

		this._endGameSound = this.GetComponent<AudioSource> ();

		for (int cloudCount = 0; cloudCount < this.cloudNumber; cloudCount++) {
			Instantiate (this.cloud);
		}
	}

	// Update is called once per frame
	void Update () {
	}

	private void _endGame() {
		this.GameOverLabel.gameObject.SetActive (true);
		this.FinalScoreLabel.text = "Final Score: " + this.ScoreValue;
		this.FinalScoreLabel.gameObject.SetActive (true);
		this.RestartButton.gameObject.SetActive (true);
		this.ScoreLabel.gameObject.SetActive (false);
		this.LivesLabel.gameObject.SetActive (false);
        if(this.zombie)
        {
            this.zombie.SetActive(false);
        }
		if(this.planet)
        {
            this.planet.SetActive(false);
        }
		this._endGameSound.Play ();
	}

	// Public method to return back to menu on game over screen
	public void RestartButton_Click() {
		SceneManager.LoadScene ("Menu");
	}

    
}
