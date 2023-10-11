using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ActionPlayer : MonoBehaviour
{
    public KeyCode leftKey;
    public KeyCode rightKey;

    public float xAccel;
    public float gravity;
    public float bounceVel;

    public AudioSource revive;
    public AudioSource jump;
    public AudioSource boop;
    public AudioSource die;

    float timeToRespawn = 3f;
    float timeToRespawnCounter;

    public GameObject destroyCloud;
    public GameObject respawnLoc;
    public GameObject leftSpawn;
    public GameObject rightSpawn;

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] ParticleSystem clashParticle;

    private int score;

    bool goLeft;
    bool goRight;

    Rigidbody2D myBody;

    bool bounce = true;
    bool dead = false;

    private void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //movement
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

        if (dead)
        {
            //respawn delay
            timeToRespawnCounter += Time.deltaTime * 5;
            if (timeToRespawnCounter >= timeToRespawn)
            {
                //play revive sound
                revive.Play(1);
                //spawn player back in the map
                this.transform.position = respawnLoc.transform.position;
                dead = false;
            }
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
            //jump audio
            jump.Play(1);
            bounce = false;
            Destroy(destroyCloud);
        }

        if (goLeft)
        {
            newVel.x -= xAccel;
        } else if(goRight)
        {
            newVel.x += xAccel;
        }

        myBody.velocity = newVel; 

        //update text with score - converts int to string
        string scoreStr = score.ToString();
        scoreText.text = scoreStr;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //detect cloud collision + allow player to bounce
        if(collision.gameObject.tag == "Cloud" && myBody.velocity.y <= 0)
        {
            destroyCloud = collision.gameObject;
            bounce = true;
            boop.Play(1);
        }

        if (collision.gameObject.tag == "Player")
        {
            //bounce off player and add to score
            bounce = true;
            score++;
            boop.Play(1);

            //spawn particles when collide with player
            var emitter = clashParticle.emission;
            var pDuration = clashParticle.duration;

            //plays particle effect
            emitter.enabled = true;
            clashParticle.Play();
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Floor") //if fall down u die
        {
            score--;
            die.Play(1);
            dead = true;

        }

        if (collision.gameObject.tag == "Left Bound") //if you go to the side you spawn on other end of screen
        {
            transform.position = rightSpawn.transform.position;

        } else if (collision.gameObject.tag == "Right Bound")
        {
            transform.position = leftSpawn.transform.position;
        }


    }

}
