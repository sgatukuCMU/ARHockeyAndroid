using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score1Script : MonoBehaviour
{
    public GameObject puck;
    public Text score1;
    Puck puckScript;
    // Start is called before the first frame update
    void Start()
    {
        puckScript = puck.GetComponent<Puck>();
    }

    // Update is called once per frame
    void Update()
    { 
        score1.text = "Score: " + (puckScript.Player1Score).ToString();
    }
}
