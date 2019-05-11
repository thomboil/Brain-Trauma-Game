using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavesManger : MonoBehaviour
{
    GenerationEnnemi ge;

    int level = 1;
    float difficulte = 1.1f;
    // Start is called before the first frame update
    void Start()
    {
        ge = GetComponent<GenerationEnnemi>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Ennemi.nbEnnemi == 0 && ge.cptSpawn >= ge.nbSpawn)
        {
            Debug.Log("hey");
            ++level;
            ge.cptSpawn = 0;
            ++ge.nbSpawn;
            ge.nextSpawnTime /= difficulte;
            ge.NextWave();
            Debug.Log(ge.nbSpawn);

        }

    }
}
