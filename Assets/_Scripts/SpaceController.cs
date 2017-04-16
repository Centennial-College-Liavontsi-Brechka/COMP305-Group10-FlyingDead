/*
 *      Authors: Tony Bogun, Leonti Brechka, Baljinder Tanda, Hao Jiang
 *      Last Modified By: Tony Bogun
 *      Date Modified: 2017-04-15
 *      Description: Controller for background 'Space' object
 *      Version: 3.0 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceController : MonoBehaviour {
	private int _speed;
	private Transform _transform;

    // Speed property getter and setter
	public int Speed {
		get {
			return this._speed;
		}
		set {
			this._speed = value;
		}
	}
		
	// Use this for initialization
	void Start () {
		this._transform = this.GetComponent<Transform> ();
		this._reset ();
	}

	// Update is called once per frame
	void Update () {
		this._move ();
		this._checkBounds ();
	}
		
	// This method moves the game object down the screen by _speed px every frame
	private void _move() {
		Vector2 newPosition = this._transform.position;

		newPosition.x -= this._speed;

		this._transform.position = newPosition;
	}
		
	// This method checks to see if the game object meets the top-border of the screen
	private void _checkBounds() {
		if (this._transform.position.x <= -640) {
			this._reset ();
		}
	}
		
	// This method resets the game object to the original position
	private void _reset() {
		this._speed = 5;
		this._transform.position = new Vector2 (640f, 0f);
	}
}
