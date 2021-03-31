using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IconScript : MonoBehaviour {

	string direction;       // hold up, down, left, right
	int score;              // how many button presses
	float timeLeft;         // in seconds
	bool gameOver = false;  // is game over

	// Use this for initialization
	void Start () {
	
		// initialize
		timeLeft = 10;

		// set to a random direction
		SetToRandom();
	}

	// Update is called once per frame
	void Update () {

		if (gameOver == false) {
			
			// if any arrow key has been pressed
			if (Input.GetKeyDown("up") || 
				Input.GetKeyDown("right") || 
				Input.GetKeyDown("down") || 
				Input.GetKeyDown("left"))
			{
				
				// if that key matches our direction add to the score otherwise game over
				// e.g. this is like saying Input.GetKey("up")
				if ( Input.GetKeyDown(direction) )
				{
					Debug.Log("SCORE: " + score);
					score++;
					SetToRandom();
				}
				else {
					Debug.Log("You lost.");
					gameOver = true;
				}
			}

			// check if time is up
			if (timeLeft < 0) {
				Debug.Log("Times up! score: " + score);
				gameOver = true;
			}

			// update time
			timeLeft -= Time.deltaTime;
		}
	}

	void SetToRandom() {

		// get a random number: 0, 1, 2, 3
		var randDirection = Random.Range(0,4);

		// set up left, right, up or down depending on which #
		if (randDirection == 0) {
			transform.eulerAngles = new Vector3(0, 0, 0);
			direction = "up";
		}
		else if (randDirection == 1) {
			transform.eulerAngles = new Vector3(0, 0, 270);
			direction = "right";
		}
		else if (randDirection == 2) {
			transform.eulerAngles = new Vector3(0, 0, 180);
			direction = "down";
		}
		else if (randDirection == 3) {
			transform.eulerAngles = new Vector3(0, 0, 90);
			direction = "left";
		}

		Debug.Log(direction);
	}
}
