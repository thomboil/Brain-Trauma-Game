using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavesManger : MonoBehaviour
{
    GenerationEnnemi ge;

    int level = 1;
    int waves = 0;
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
            ++waves;
            ge.cptSpawn = 0;
            ++ge.nbSpawn;
            ge.nextSpawnTime /= difficulte;
            ge.NextWave();
            Debug.Log(ge.nbSpawn);
            if(waves % 5 == 0)
            {
                ++level;
                ChangePlanet();
            }
        }

    }


    public GameObject Planet;

    private void ChangePlanet()
    {
        var thisPlanet = GameObject.Find("Planet");
        thisPlanet.name = "SikePlanet";
        GameObject player = GameObject.Find("Player");
        var planet = Instantiate(Planet, player.transform.up * 10, Quaternion.identity);

        //change the planet that attract
        player.GetComponent<ObjectGravity>().GetPlanet();
        //ObjectGravity
    }
}
