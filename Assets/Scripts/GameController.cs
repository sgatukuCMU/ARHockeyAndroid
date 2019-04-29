using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public Puck puck;
    public Text scoreText;

    private int score1;
    private int score2;

    // Use this for initialization
    void Start()
    {
        //puck.GoalScored += GoalScored;
    }

    // Update is called once per frame
    void Update()
    {
    }

    
}