using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int turnNumber;
    public int numBalls;
    private int ballsInPlay;
    public Vector3 lastBallPos;
    public GameObject playerBallPrefab;
    public GameObject newBlockPrefab;
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

        //Move blocks down
        GameObject[] blocks = GameObject.FindGameObjectsWithTag("Block");       //list of blocks in play
        int numBlocks = GameObject.FindGameObjectsWithTag("Block").Length;    //count the number of blocks

        //move blocks don by 1 in the y axis
        for (int i = 0; i < numBlocks; i++)
        {
            Vector3 currentPos = blocks[i].transform.position;
            blocks[i].transform.position = new Vector2(currentPos.x, currentPos.y - 1);
        }


        GameObject[] newBlocksList = new GameObject[7];
        bool doFillSpace;   //Whethe or not to add a new block to the list (dont want to always spawn a whole line of blocks)

        //add up to 8 blocks
        for (int i = 0; i < newBlocksList.Length; i++)
        {
            doFillSpace = Random.value > 0.5f;  //random boolean

            if (doFillSpace)
            {
                newBlocksList[i] = newBlockPrefab;  //add a block to the list.
            }

        }

        Vector3[] blockSpawns = new Vector3[] {new Vector3(-3.09375f,4.5f,5) , new Vector3(-2.065f, 4.5f, 5), new Vector3(-1.05f, 4.5f, 5), new Vector3(-0.0075f, 4.5f, 5), new Vector3(1.02125f, 4.5f, 5), new Vector3(2.05f, 4.5f, 5), new Vector3(3.07875f, 4.5f, 5) };
        

        Vector3 nextTurnStartPos = new Vector3(lastBallPos.x, -4f, lastBallPos.z);  //position to spawn the next playerball (y must be the same as before)

        Instantiate(playerBallPrefab, nextTurnStartPos, Quaternion.identity);   //Spawn the blocks

        //add up to 8 blocks
        for (int i = 0; i < newBlocksList.Length; i++)
        {
            if (newBlocksList[i])
            {
                Instantiate(newBlocksList[i], blockSpawns[i], Quaternion.identity);
            }
        }


    }

    public void getPlusOne()
    {
        numBalls += 1;
    }


    void spawnRow(int turnNumber)
    {

    }


}
