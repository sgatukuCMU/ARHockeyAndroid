using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score2Script : MonoBehaviour
{
    public GameObject puck;
    public Text score2;
    Puck puckScript;
    // Start is called before the first frame update
    void Start()
    {
        puckScript = puck.GetComponent<Puck>();
    }

    // Update is called once per frame
    void Update()
    {
        
        score2.text = "Score: " + (puckScript.Player2Score).ToString();
    }
}
