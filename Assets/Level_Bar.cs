using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Level_Bar : MonoBehaviour
{

    Image fillBar;

    WavesManger wm;
    // Start is called before the first frame update
    void Start()
    {
        fillBar = GetComponentsInChildren<Image>().First(x => x.name == "xp_over");
        wm = GameObject.Find("GameManager").GetComponent<WavesManger>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(wm.waves);
        fillBar.fillAmount = wm.waves / 5f;
    }
}
