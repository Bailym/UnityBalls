using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int turnNumber;
    public int numBalls;
    private int ballsInPlay;
    public Vector3 lastBallPos;
    public Transform playerBallPrefab;
    // Start is called before the first frame update
    void Start()
    {
        turnNumber = PlayerPrefs.GetInt("currentTurn");     
    }

    // Update is called once per frame
    void Update()
    {
        ballsInPlay = GameObject.FindGameObjectsWithTag("Ball").Length; //the amount of balls in play.

        //if no balls are in play
        if (ballsInPlay <= 0)
        {
            nextTurn(); //start the next turn.
        }
        
    }

    void quitGame()
    {
        PlayerPrefs.SetInt("currentTurn", turnNumber);

    }

    void gameOver()
    {
        PlayerPrefs.SetInt("currentTurn", 0);

    }

    void nextTurn()
    {
        turnNumber += 1;
        PlayerPrefs.SetInt("currentTurn", turnNumber);

        Vector3 nextTurnStartPos = new Vector3(lastBallPos.x, -4f, lastBallPos.z);  //position to spawn the next playerball (y must be the same as before)

        Instantiate(playerBallPrefab, nextTurnStartPos, Quaternion.identity);

    }

    public void getPlusOne()
    {
        numBalls += 1;
    }


    void spawnRow(int turnNumber)
    {

    }


}
