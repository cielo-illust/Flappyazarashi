using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameController : MonoBehaviour {

	enum State
	{
		Ready,
		Play,
		GameOver
	}

	State state;
	int score;

	public AzarashiController azarashi;
	public GameObject blocks;
	public Text scoreLabel;
	public Text stateLabel;

	void Start () {
		Ready ();
	}

	void LateUpdate(){
		switch (state) {
		case State.Ready:
			if (Input.GetButtonDown ("Fire1")) {
				GameStart ();
			}
			break;
		case State.Play:
			if (azarashi.IsDead ()) {
				GameOver ();
			}
			break;
		case State.GameOver:
			if (Input.GetButtonDown ("Fire1")) {
				Reload ();
			}
			break;
		}
	}

	void Ready () {
		state = State.Ready;
		azarashi.SetSteerActive (false);
		blocks.SetActive (false);

		scoreLabel.text = "Score : " + score;
		stateLabel.gameObject.SetActive (true);
		stateLabel.text = "Ready";
	}

	void GameStart () {
		state = State.Play;
		azarashi.SetSteerActive (true);
		blocks.SetActive (true);

		azarashi.Flap ();

		stateLabel.gameObject.SetActive (false);
		stateLabel.text = "";
	}

	void GameOver () {
		state = State.GameOver;
		ScrollObject[] scrollObjects = GameObject.FindObjectsOfType<ScrollObject> ();
		foreach(ScrollObject so in scrollObjects) {
			so.enabled = false;
		}
		stateLabel.gameObject.SetActive (true);
		stateLabel.text = "GameOver";
	}

	void Reload () {
		SceneManager.LoadScene ("Flappyazarashi");
	}

	public void IncreaseScore(){
		score++;
		scoreLabel.text = "Score : " + score;
	}
}
