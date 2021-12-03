using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //variable initialize
    public KeyCode upButton = KeyCode.W;
    public KeyCode downButton = KeyCode.S;
    public float speed = 10.0f;
    public float yBoundary = 9.0f;
    private Rigidbody2D rigidBody2D;
    private int score;
    private ContactPoint2D lastContactPoint;

    public ContactPoint2D LastContactPoint
    {
        get { return lastContactPoint;  }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Ball")) {
            lastContactPoint = collision.GetContact(0);
        }
    }

   
    // Start is called before the first frame update
    void Start(){
        rigidBody2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        // Dapatkan kecepatan raket sekarang.
        Vector2 velocity = rigidBody2D.velocity;
 

        if (Input.GetKey(upButton))
        {
            velocity.y = speed;
        }

        else if (Input.GetKey(downButton))
        {
            velocity.y = -speed;
        }
 
        else
        {
            velocity.y = 0.0f;
        }
 
        rigidBody2D.velocity = velocity;

        //Boundaries Validation
        Vector3 position = transform.position;

        if(position.y > yBoundary)
        {
            position.y = yBoundary;
        }

        if(position.y < -yBoundary)
        {
            position.y = -yBoundary;
        }

        transform.position = position;

       
    }

    public void IncrementScore()
    {
        score++;
    }
    public void ResetScore()
    {
        score = 0;
    }
    public int Score
    {
        get { return score; }
    }
}
