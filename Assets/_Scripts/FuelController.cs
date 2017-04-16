/*
 *      Authors: Tony Bogun, Leonti Brechka, Baljinder Tanda, Hao Jiang
 *      Last Modified By: Tony Bogun
 *      Date Modified: 2017-04-15
 *      Description: Controller for 'Fuel' pick-up object
 *      Version: 3.0 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelController : MonoBehaviour {

    private int _speed;
    private Transform _transform;
    public Level1Controller gameController;

    // Fuel speed property setter and getter
    public int Speed
    {
        get
        {
            return this._speed;
        }
        set
        {
            this._speed = value;
        }
    }

    // Use this for initialization
    void Start () {
        this._transform = this.GetComponent<Transform>();
        this._reset();
        InvokeRepeating("TakeLife", 2, 2);
    }
	
	// Update is called once per frame
	void Update () {
        this._move();
        this._checkBounds();
    }

    // This method moves the game object left the screen by _speed px every frame
    private void _move()
    {
        Vector2 newPosition = this._transform.position;

        newPosition.x -= this._speed;

        this._transform.position = newPosition;
    }

    // This method checks to see if the game object meets the left-border of the screen
    private void _checkBounds()
    {
        if (this._transform.position.x <= -354f)
        {
            this._reset();
        }
    }

    // This method resets the game object to the original position
    private void _reset()
    {
        this._speed = 9;
        this._transform.position = new Vector2(354f, Random.Range(-205f, 205f));
    }

    // This method resets fuel object position if it is picked up
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Zombie"))
        {
            this._reset();
        }
    }

    // This method decreases life of player by 1
    private void TakeLife()
    {
        if(this.gameController.LivesValue>0)
            this.gameController.LivesValue -= 1;
    }

}
