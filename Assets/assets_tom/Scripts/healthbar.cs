using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthbar : MonoBehaviour
{

    public Image bar;
    public float fillAmount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fillAmount = Score.score / 100; 
        bar.fillAmount = fillAmount;
        
    }
}
