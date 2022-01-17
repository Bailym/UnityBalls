using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BlockScore : MonoBehaviour
{

    private Transform blockCanvas; //The canvas over the block
    private Transform blockText;   //The text on the canvas
    private int textVal; 

    // Start is called before the first frame update
    void Start()
    {
        blockCanvas = gameObject.transform.GetChild(0); //get a reference to the canvas
        blockText = blockCanvas.transform.GetChild(0);  //reference to the TextMesh
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball")) //if collides with a ball
        {
            textVal = int.Parse(blockText.GetComponent<TextMeshProUGUI>().text);    //reduce score by 1
            textVal -= 1;

            //if the score reaches 0 destroy the block 
            if (textVal <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                blockText.GetComponent<TextMeshProUGUI>().text = textVal.ToString();    //update the text
            }

              

            
        }

    }
}
