using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class KeepScore : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void WriteHighScore(int score)
    {
        if(ReadHighScore() <= score)
        {
            using (StreamWriter write = new StreamWriter("highscore.txt"))
            {
                write.Write(score);
            }
        }
        
      
    }

    public static int ReadHighScore()
    {
        string score;
        using (StreamReader reader = new StreamReader("highscore.txt"))
        {
            score = reader.ReadLine();
        }
        return int.Parse(score);
    }
}
