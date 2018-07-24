using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* Action Items:
 * - Disable player ability to roll twice in a row
 * - Create CoRoutine to enable play for both players
 * - Create arrays for tiles and their locations - include special tile behaviour
 * - Create array for pieces, allow them to be clickable
 * - Display roll number after a player rolls
 */

public class PlayerTurn : MonoBehaviour {

	public int rollMin = 0;
	public int rollMax = 5;
	public Button P1Roll;
	public Button P2Roll;
	private bool isP1Turn;
	private bool isP2Turn;
	private bool playerAlreadyRolled;
	private int rolledNumber;

	void Start () {
		// Let Player 1 go first
		isP1Turn = true;
	}
	
	void Update () {
		if (isP1Turn) {
			P2Roll.onClick.RemoveListener(P2RollEvent);
			if (playerAlreadyRolled == false) {
				P1Roll.onClick.AddListener(P1RollEvent);
			}
			play(rolledNumber, P1Roll);
		}

		if (isP2Turn) {
			P2Roll.onClick.AddListener(P2RollEvent);
			P1Roll.onClick.RemoveListener(P1RollEvent);
			play(rolledNumber, P2Roll);
		}
	}

	void P1RollEvent() {
		rolledNumber = Random.Range(rollMin, rollMax);
		Debug.Log("Player 1 rolled a " + rolledNumber + "!");
		playerAlreadyRolled = true;
		P1Roll.onClick.RemoveAllListeners();
	}

	void P2RollEvent() {
		rolledNumber = Random.Range(rollMin, rollMax);
		Debug.Log("Player 2 rolled a " + rolledNumber + "!");
	}

	void play (int rolledNumber, Button playerButton) {
		if (rolledNumber > 0) {
			// play logic
			// After play is done, reset playerAlreadyRolled to false, and switch player turn
			StartCoroutine(Timer());
		}
	}

	IEnumerator Timer() {
		yield return new WaitForSeconds(5f);
	}
		
}
