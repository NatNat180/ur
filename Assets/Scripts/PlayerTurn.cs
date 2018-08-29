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

public class PlayerTurn : MonoBehaviour
{

    public int rollMin = 0;
    public int rollMax = 5;
    public Button p1Roll;
    public Button p2Roll;
    public static bool isP1Turn;
    public static bool isP2Turn;
    public static bool playerAlreadyRolled;
    public static int rolledNumber;
    public Transform[] p1Pieces;
    public Transform[] p2Pieces;
    public Transform[] p1SafeZone;
    public Transform[] p2SafeZone;
    public Transform[] warZone;

    void Start() {
        // Let Player 1 go first
        isP1Turn = true;
    }

    void Update() {
        if (isP1Turn) {
            p2Roll.onClick.RemoveListener(p2RollEvent);
            if (playerAlreadyRolled == false) {
                p1Roll.onClick.AddListener(p1RollEvent);
            }
            play(rolledNumber, p1Roll);
        }

        if (isP2Turn) {
            p1Roll.onClick.RemoveListener(p1RollEvent);
            if (playerAlreadyRolled == false) {
                p2Roll.onClick.AddListener(p2RollEvent);
            }
            play(rolledNumber, p2Roll);
        }
    }

    void p1RollEvent() {
        rolledNumber = Random.Range(rollMin, rollMax);
        Debug.Log("Player 1 rolled a " + rolledNumber + "!");
        // if logic to go here in case player is on special tile, allowing for a second roll, otherwise...
        playerAlreadyRolled = true;
        p1Roll.onClick.RemoveAllListeners();
    }

    void p2RollEvent() {
        rolledNumber = Random.Range(rollMin, rollMax);
        Debug.Log("Player 2 rolled a " + rolledNumber + "!");
        // if logic to go here in case player is on special tile, allowing for a second roll, otherwise...
        playerAlreadyRolled = true;
        p2Roll.onClick.RemoveAllListeners();
    }

    void play(int rolledNumber, Button playerButton) {
        if (rolledNumber > 0) {
            // play logic
            // After play is done, reset playerAlreadyRolled to false, and switch player turn
            StartCoroutine(Timer());
        }
    }

    IEnumerator Timer() {
        yield return new WaitForSeconds(3f);
    }

}
