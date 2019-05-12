using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Level_Bar : MonoBehaviour
{

    Image fillBar;
    Text waveText;

    WavesManger wm;
    // Start is called before the first frame update
    void Start()
    {
        fillBar = GetComponentsInChildren<Image>().First(x => x.name == "xp_over");
        wm = GameObject.Find("GameManager").GetComponent<WavesManger>();
        waveText = GetComponentsInChildren<Text>().First(x => x.name == "level_txt");
    }

    // Update is called once per frame
    void Update()
    {
        fillBar.fillAmount = (wm.waves % 5)/5f;
        waveText.text = (wm.waves / 5).ToString();
    }
}
