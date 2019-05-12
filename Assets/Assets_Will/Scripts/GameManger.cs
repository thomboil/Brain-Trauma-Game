using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManger : MonoBehaviour
{
    pourcentage pourcentile;
    ObjectGravity objG;
    Light spotlight;

    Canvas cnv;

    //audiosource
    public AudioSource gameOver_Sound;


    //UI score stuff

    public Text score;
    public Text highscore;
    public Text levelTxtBox;


    // Start is called before the first frame update
    void Start()
    {
        pourcentile = GetComponent<pourcentage>();
        objG = GameObject.Find("Player").GetComponent<ObjectGravity>();
        spotlight = GameObject.Find("Player").GetComponentsInChildren<Light>().First(x => x.name == "Spot Light");

        cnv = GetComponentsInChildren<Canvas>().First(x => x.name == "EndGame");
        cnv.enabled = false;
    }

    bool endGame = true;
    // Update is called once per frame
    void Update()
    {
        if(int.Parse(pourcentile.pourcentageTxt.text.Substring(0, pourcentile.pourcentageTxt.text.Length -1)) <= 0)
        {

            gameOver_Sound.Play();

            objG.gravity = 5;
            if (spotlight.range > 0)
                spotlight.range -= 0.1f;

            cnv.enabled = true;

            if (endGame)
            {
                score.text = "Score: " + levelTxtBox.text;
                KeepScore.WriteHighScore(int.Parse(levelTxtBox.text)); //Checker si new highscoer avec le fichier text
                highscore.text = "Top score: " + KeepScore.ReadHighScore();
                endGame = false;
            }
            
        }
    }

    public void Restart()
    {
        Ennemi.nbEnnemi = 0;
        Menu_Camera.play = false;
        SceneManager.LoadScene(1);
    }
}
