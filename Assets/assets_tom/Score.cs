using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public static int score; //A level will be 1000 pts
    public Text scoreTxt;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreTxt.text = score.ToString();   //Text starts at zero
    }

    // Update is called once per frame
    void Update()
    {
        scoreTxt.text = score.ToString();
    }
}
