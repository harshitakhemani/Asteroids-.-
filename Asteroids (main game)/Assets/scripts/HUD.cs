using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField]
    Text textscore;
    int score = 0;
    float elapsedseconds = 0f;
    bool running = true;
    // Start is called before the first frame update
    void Start()
    {


        textscore.text = "Score " + score.ToString();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (running)
        {
            elapsedseconds += Time.deltaTime;
            textscore.text = "Score " + Convert.ToInt32(elapsedseconds).ToString();
        }
    }

    public void stopgametimer()
    {
        running = false;
    }


}
