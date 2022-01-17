using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int turnNumber;
    public int numBalls;
    // Start is called before the first frame update
    void Start()
    {
        turnNumber = PlayerPrefs.GetInt("currentTurn");
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
        PlayerPrefs.SetInt("currentTurn", turnNumber); ;
    }


    void spawnRow(int turnNumber)
    {

    }


}
