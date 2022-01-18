using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]    //runs before the class is initialised. Requires LR component
public class DragNShoot : MonoBehaviour
{
    public float powerMultiplier = 10f;
    public Rigidbody2D rb;
    public LineRenderer lr;

    public Vector2 minPower;    //The min power
    public Vector2 maxPower;    //max power. Stops the user getting more power on a bigger screen.
    private GameController gc;

    Camera cam;
    Vector2 force;  //calculated force
    Vector3 endPoint;   //end of drag
    Vector3 objPoint;   //the point of this object. Used as an origin for the linerender
    Vector3 currentPoint;   //the current mouse point

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();  //reference for the line renderer.
        gc = FindObjectOfType<GameController>();
    }

    private void Start()
    {
        cam = Camera.main;  //set to main camera
        objPoint = GetComponent<Transform>().position;  //get the position of this obj
    }

    private void Update()
    {
 
        //if the left click is currently down.
        if (Input.GetMouseButton(0))
        {
            currentPoint = cam.ScreenToWorldPoint(Input.mousePosition); //get the current mouse pos
            currentPoint.z = 15;    //move to top layer
            lr.positionCount = 2;   //shows the line renderer

            Vector3[] points = new Vector3[2];  //points in the line renderer
            points[1] = objPoint;   //start from the object
            points[0] = currentPoint;   //draw to the mouse

            lr.SetPositions(points);    //set the positions
        }

        if(Input.GetMouseButtonUp(0))
        {
            endPoint = cam.ScreenToWorldPoint(Input.mousePosition); //set the end point to the mouse position - mouse position used pixels by default so it needs to be converted to world co ordinates
            endPoint.z = 15;  //move start point to top of scene layers.


            force = new Vector2(Mathf.Clamp(objPoint.x - endPoint.x, minPower.x, maxPower.x), Mathf.Clamp(objPoint.y - endPoint.y, minPower.y, maxPower.y));    //calculate the force

            rb.AddForce(force * powerMultiplier, ForceMode2D.Impulse);    //add the force to the rigidbody


            //TODO: Spawn all of a players balls.

            GameObject newBall;
            int ballsLeft = gc.numBalls;
            {
                //spawn in all balls
                for (int i=0;i< ballsLeft; i++)
                {
                    newBall = Instantiate(gameObject, objPoint, Quaternion.identity);
                    newBall.GetComponent<Rigidbody2D>().AddForce(rb.velocity * 55); //make the new balls slighly faster so they dont overlap
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Physics2D.IgnoreCollision(collision.collider, gameObject.GetComponent<CircleCollider2D>());
        }
    }

}
