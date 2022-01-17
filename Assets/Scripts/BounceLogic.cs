using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceLogic : MonoBehaviour
{

    private Vector2 inDirection;
    private Vector2 outDirection;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        inDirection = rb.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //destroy any balls that hit the bottom
        if (collision.gameObject.CompareTag("Bottom"))
        {
            Destroy(gameObject);
        }

    }

}
