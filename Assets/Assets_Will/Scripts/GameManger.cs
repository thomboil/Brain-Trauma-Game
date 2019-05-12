using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class GameManger : MonoBehaviour
{
    pourcentage pourcentile;
    ObjectGravity objG;
    Light spotlight;

    Canvas cnv;
    // Start is called before the first frame update
    void Start()
    {
        pourcentile = GetComponent<pourcentage>();
        objG = GameObject.Find("Player").GetComponent<ObjectGravity>();
        spotlight = GameObject.Find("Player").GetComponentsInChildren<Light>().First(x => x.name == "Spot Light");

        cnv = GetComponentsInChildren<Canvas>().First(x => x.name == "EndGame");
        cnv.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(int.Parse(pourcentile.pourcentageTxt.text.Substring(0, pourcentile.pourcentageTxt.text.Length -1)) <= 0)
        {

            objG.gravity = 5;
            if (spotlight.range > 0)
                spotlight.range -= 0.1f;

            cnv.enabled = true;
        }
    }

    public void Restart()
    {
        SceneManager.UnloadSceneAsync(1);
        SceneManager.LoadScene(1);
    }
}
