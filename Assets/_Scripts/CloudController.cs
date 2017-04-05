using UnityEngine;
using System.Collections;

public class CloudController : MonoBehaviour {
	private int _speed;
	private int _drift;
	private Transform _transform;

	public int Speed {
		get {
			return this._speed;
		}
		set {
			this._speed = value;
		}
	}

	public int Drift {
		get {
			return this._drift;
		}
		set {
			this._drift = value;
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

		newPosition.x -= this.Speed;
		newPosition.y += this.Drift;

		this._transform.position = newPosition;
	}
		
	// this method checks to see if the game object meets the left-border of the screen
	private void _checkBounds() {
		if (this._transform.position.x <= -440f) {
			this._reset ();
		}
	}
		
	// this method resets the game object to the original position
	private void _reset() {
		this.Speed = Random.Range (5, 10);
		this.Drift = Random.Range (-2, 2);
		this._transform.position = new Vector2 (440f, Random.Range(-335f, 333f));
	}
}
