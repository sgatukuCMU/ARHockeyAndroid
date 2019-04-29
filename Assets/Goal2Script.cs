using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal2Script : MonoBehaviour
{
    private int score1;
    public Text score1Text;

    // Start is called before the first frame update
    void Start()
    {
        score1 = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("In Goal2 collision:" + collision.gameObject.name);
        score1++;
        score1Text.text = "Score: " + (score1).ToString();

        
    }
}
