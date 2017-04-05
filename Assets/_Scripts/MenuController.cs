using UnityEngine;
using System.Collections;

// reference to scene management
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
		
	public void StartButton_Click() {
		SceneManager.LoadScene ("Level1");
	}
}
