using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WavesManger : MonoBehaviour
{
    GenerationEnnemi ge;
    Canvas cnv;

    int level = 1;
    int waves = 4;
    float difficulte = 1.1f;
    // Start is called before the first frame update
    void Start()
    {
        ge = GetComponent<GenerationEnnemi>();

        cnv = GetComponentsInChildren<Canvas>().First(x => x.name == "NextWave");
        cnv.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Ennemi.nbEnnemi == 0 && ge.cptSpawn >= ge.nbSpawn)
        {
            ++waves;
            ge.cptSpawn = 0;
            ++ge.nbSpawn;
            ge.nextSpawnTime /= difficulte;
            ge.NextWave();
            if(waves % 18 == 0)
            {
                ++level;
                ChangePlanet();
            }

            StartCoroutine("AffichageNextWave");
        }

    }

    IEnumerator AffichageNextWave()
    {
        cnv.enabled = true;
        yield return new WaitForSeconds(1.5f);
        cnv.enabled = false;
    }


    public GameObject Planet;

    private void ChangePlanet()
    {
        var thisPlanet = GameObject.Find("Planet");
        thisPlanet.name = "SikePlanet";
        GameObject player = GameObject.Find("Player");

        float distancePlanet = Random.Range(25, 50f);
        var planet = Instantiate(Planet, player.transform.up * distancePlanet, Quaternion.identity);
        planet.name = "Planet";
        //change the planet that attract
        player.GetComponent<ObjectGravity>().GetPlanet();
        ge.GetPlanet();
        //ObjectGravity
    }
}
