using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour {
	private int _speed;
	private Transform _transform;

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
		
	// this method moves the game object left the screen by _speed px every frame
	private void _move() {
		Vector2 newPosition = this._transform.position;

		newPosition.x -= this._speed;

		this._transform.position = newPosition;
	}


	// this method checks to see if the game object meets the left-border of the screen
	private void _checkBounds() {
		if (this._transform.position.x <= -354f) {
			this._reset ();
		}
	}


	// this method resets the game object to the original position
	private void _reset() {
		this._speed = 5;
		this._transform.position = new Vector2 (354f, Random.Range(-205f, -205f));
	}
}
