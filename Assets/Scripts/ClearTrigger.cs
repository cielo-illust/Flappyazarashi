using UnityEngine;
using System.Collections;

public class ClearTrigger : MonoBehaviour {
	GameObject gameController;
	void Start () {
		gameController = GameObject.FindWithTag ("GameController");
	}
	void OnTriggerExit2D () {
		gameController.SendMessage ("IncreaseScore");
	}
}
