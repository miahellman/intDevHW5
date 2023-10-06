using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionPlayer : MonoBehaviour
{
    public KeyCode leftKey;
    public KeyCode rightKey;

    public float xAccel;
    public float gravity;
    public float bounceVel;

    bool goLeft;
    bool goRight;

    Rigidbody2D myBody;

    bool bounce = true;

    private void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKey(leftKey))
        {
            goLeft = true;
        }
        else
        {
            goLeft = false;
        }

        if (Input.GetKey(rightKey))
        {
            goRight = true;
        }
        else
        {
            goRight = false;
        }
    }

    private void FixedUpdate()
    {
        Vector3 newVel = myBody.velocity;

        newVel.x *= 0.9f;
        newVel.y += gravity;

        if (bounce)
        {
            newVel.y += bounceVel;
            bounce = false;
        }

        if (goLeft)
        {
            newVel.x -= xAccel;
        } else if(goRight)
        {
            newVel.x += xAccel;
        }

        myBody.velocity = newVel;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Cloud")
        {
            bounce = true;
        }
    }

}
