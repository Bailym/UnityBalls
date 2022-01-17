using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusOne : MonoBehaviour
{
    private GameController gc;
    // Start is called before the first frame update
    void Start()
    {
        gc = FindObjectOfType<GameController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if collides with ball
        if (collision.gameObject.CompareTag("Ball"))
        {
            gc.getPlusOne();
            Destroy(gameObject);

        }
    }
}
