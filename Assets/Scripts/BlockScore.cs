using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BlockScore : MonoBehaviour
{

    private GameObject blockCanvas; //The canvas over the block
    private GameObject blockText;   //The text on the canvas
    private int textVal; 

    // Start is called before the first frame update
    void Start()
    {
        blockCanvas = GameObject.Find("Canvas").gameObject; //get objects
        blockText = GameObject.Find("ValueText").gameObject;
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
            blockText.GetComponent<TextMeshProUGUI>().text = textVal.ToString();
        }

    }
}
