using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPiece : MonoBehaviour {

	/* TODO: Problem - I want the pieces to know the positions of the safe zones so they can move accordingly. 
	However, I'm forced to set the position of every Transform tile to every piece in the scene, which is cumbersome.
	One index of the array is already set in the scene.... Should I follow through? Nah. Need a better way. */

	public Transform[] p1SafeZone;
	public Transform[] p2SafeZone;
	public Transform[] warZone;

	void Start () {
		
	}
	
	void Update () {
		
	}

	void OnMouseDown () {
		if (transform.tag == "P1Piece" &&
				PlayerTurn.isP1Turn) {
			Debug.Log("P1 piece was clicked!");
			int roll = PlayerTurn.rolledNumber;
			PlayerTurn.playerAlreadyRolled = false;
			transform.position = roll < p1SafeZone.Length ? p1SafeZone[roll].localPosition : warZone[roll].localPosition;
			PlayerTurn.isP1Turn = false;
            PlayerTurn.isP2Turn = true;
		} else if (transform.tag == "P2Piece" &&
				PlayerTurn.isP2Turn) {
			Debug.Log("P2 piece was clicked!");
			PlayerTurn.playerAlreadyRolled = false;
			//transform.position = 
			PlayerTurn.isP2Turn = false;
            PlayerTurn.isP1Turn = true;
		}
	}
}
