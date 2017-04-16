/*
 *      Authors: Tony Bogun, Leonti Brechka, Baljinder Tanda, Hao Jiang
 *      Last Modified By: Leonti Brechka
 *      Date Modified: 2017-04-15
 *      Description: Controller for 'Planet' goal object
 *      Version: 3.0 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour {
	public Sprite initialSprite;
	public Sprite infectedSprite;

	private int _speed;
	private Transform _transform;

    // Speed preoperty getter and setter
	public int Speed {
		get {
			return this._speed;
		}
		set {
			this._speed = value;
		}
	}

	// This is for initialization
	void Start () {
		this._transform = this.GetComponent<Transform> ();

		this._reset ();
	}

	// Update is called once per frame
	void Update () {
		this._move ();
		this._checkBounds ();
	}
		
	// This method moves the game object left the screen by _speed px every frame
	private void _move() {
		Vector2 newPosition = this._transform.position;

		newPosition.x -= this._speed;

		this._transform.position = newPosition;
	}


	// This method checks to see if the game object meets the left-border of the screen
	private void _checkBounds() {
		if (this._transform.position.x <= -354f) {
			this._reset ();
		}
	}

    // Makes planet infected once hit by player
	private void OnTriggerEnter2D(Collider2D other) {

		if (other.gameObject.CompareTag ("Zombie")) {
			this.GetComponent<SpriteRenderer> ().sprite = infectedSprite;
		}
	}

	// This method resets the game object to the original position
	private void _reset() {
		this._speed = 5;
		this._transform.position = new Vector2 (354f, Random.Range(-205f, 205f));
		this.GetComponent<SpriteRenderer> ().sprite = initialSprite;
	}
}
