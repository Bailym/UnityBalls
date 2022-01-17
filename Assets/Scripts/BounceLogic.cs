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
        //inDirection = rb.velocity;
        //outDirection = Vector2.Reflect(inDirection, collision.contacts[0].normal);
        //rb.velocity = outDirection;


    }

}
