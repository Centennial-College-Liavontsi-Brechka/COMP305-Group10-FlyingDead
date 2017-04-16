/*
 *      Authors: Tony Bogun, Leonti Brechka, Baljinder Tanda, Hao Jiang
 *      Last Modified By: Leonti Brechka
 *      Date Modified: 2017-04-15
 *      Description: Controller for player's 'Zombie' object
 *      Version: 3.0 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    private Transform _transform;
    private Vector2 _currentPosition;
    private float _playerInput;
    private float _speed;

    // Public variables
    public Level1Controller gameController;
    public AudioSource explosionSound;
    public AudioSource baaaaSound;
    public AudioSource fuelPickSound;
    public int scoreUpdateCounter;

    // This is for initialization
    void Start()
    {
        this._speed = 5;

        AudioSource[] sounds = GetComponents<AudioSource>();
        this.explosionSound = sounds[1];
        this.baaaaSound = sounds[2];
        this.fuelPickSound = sounds[3];
        this.explosionSound.volume = 0.3F;
        this._transform = this.GetComponent<Transform>();
        this.scoreUpdateCounter = 5;
        InvokeRepeating("AddScore", scoreUpdateCounter, scoreUpdateCounter);
    }

    // Update is called once per frame
    void Update()
    {
        this._move();

    }

	// This method moves the game object across the x-axis following the mouse movement
    private void _move()
    {
        this._currentPosition = this._transform.position;

        this._playerInput = Input.GetAxis("Vertical");

        if (this._playerInput > 0)
        {
            this._currentPosition += new Vector2(0, this._speed);
        }

        if (this._playerInput < 0)
        {
            this._currentPosition -= new Vector2(0, this._speed);
        }

        this._transform.position = new Vector2(-260f, Mathf.Clamp(this._currentPosition.y, -210f, 210f));
    }

    // This method takes 1 life if hit by cloud, gives 100 points if hit by planet, gives 1 life if hit by fuel can
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Cloud"))
        {
            this.explosionSound.Play();
            this.gameController.LivesValue -= 1;
        }


        if (other.gameObject.CompareTag("Planet"))
        {
            this.baaaaSound.Play();
            this.gameController.ScoreValue += 100;
        }

        if (other.gameObject.CompareTag("Fuel"))
        {
            this.fuelPickSound.Play();
            this.gameController.LivesValue += 1;
        }
    }

    // This method adds 100 point to score
    private void AddScore()
    {
        this.gameController.ScoreValue += 100;
    }
}
