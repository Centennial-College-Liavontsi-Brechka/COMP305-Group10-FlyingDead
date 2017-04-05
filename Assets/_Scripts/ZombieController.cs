using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour {
	private Transform _transform;
	private Vector2 _currentPosition;
	private float _playerInput;
	private float _speed;

	// variable for testing
	public Level1Controller gameController;
	public AudioSource explosionSound;
	public AudioSource baaaaSound;
    public int scoreUpdateCounter;

	// Use this for initialization
	void Start () {
		this._speed = 5;

		AudioSource[] sounds = GetComponents<AudioSource> ();
		this.explosionSound = sounds [1];
		this.baaaaSound = sounds [2];
        this.explosionSound.volume = 0.3F;
        this._transform = this.GetComponent<Transform> ();
        this.scoreUpdateCounter = 5;
        InvokeRepeating("AddScore", scoreUpdateCounter,scoreUpdateCounter);
	}

	// Update is called once per frame
	void Update () {
		this._move ();

	}

	/**
	 * this method moves the game object across the x-axis following the mouse movement
	 */
	private void _move() {
		this._currentPosition = this._transform.position;

		this._playerInput = Input.GetAxis ("Vertical");

		if (this._playerInput > 0) {
			this._currentPosition += new Vector2 (0, this._speed);
		}

		if (this._playerInput < 0) {
			this._currentPosition -= new Vector2 (0, this._speed);
		}

		this._transform.position = new Vector2 (-260f, Mathf.Clamp(this._currentPosition.y, -240f, 240f));
	}

	private void OnTriggerEnter2D(Collider2D other) {

		if (other.gameObject.CompareTag ("Cloud")) {
			this.explosionSound.Play ();
			this.gameController.LivesValue -= 1;
		}

	}

    private void AddScore()
    {
        this.gameController.ScoreValue += 100;
    }
}
