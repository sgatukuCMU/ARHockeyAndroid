using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal1Script : MonoBehaviour
{
    private int score2;
    public Text score2Text;

    // Start is called before the first frame update
    void Start()
    {
        score2 = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("In Goal1 collision:" +collision.gameObject.name);
            score2++;
            score2Text.text = "Score: " + (score2).ToString();

        
    }
}
