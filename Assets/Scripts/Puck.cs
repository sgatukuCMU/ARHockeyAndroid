
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Puck : MonoBehaviour
{

    public delegate void GoalHandler();
    public event GoalHandler OnGoal;

    public float deceleration;
    public int Player1Score = 0;
    public int Player2Score = 0;
    public float startingHorizontalPosition;

    private Rigidbody puckRigidbody;
    Vector3 startPos;

    // Use this for initialization
    void Start()
    {
        puckRigidbody = gameObject.GetComponent<Rigidbody>();
        transform.position = new Vector3(
            startingHorizontalPosition * -1,
            transform.position.y,
            transform.position.z
        );
        startPos = transform.position;
        //ResetPosition(true);
    }

    void FixedUpdate()
    {
        puckRigidbody.velocity = new Vector3(
            puckRigidbody.velocity.x * deceleration,
            puckRigidbody.velocity.y * deceleration,
            puckRigidbody.velocity.z * deceleration
        );
    }

    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Goal")
        {
            Debug.Log("HIT GOAL");
            if(collision.gameObject.name == "Bound 1_goal")
            {
                Player1Score++;
                Debug.Log("Player 1 score updated");
            }
            else
            {
                Player2Score++;
                Debug.Log("Player 2 score updated");

            }
            ResetPosition(true);
           
        }
        else
        {
         //   gameObject.GetComponent<AudioSource>().Play();
        }
    }

    public void ResetPosition(bool isLeft)
    {
        transform.position = startPos;
        puckRigidbody.velocity = Vector3.zero;
        Debug.Log("RESET!");
    }
}



