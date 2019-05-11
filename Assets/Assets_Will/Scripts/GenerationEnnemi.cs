using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationEnnemi : MonoBehaviour
{

    public int nbVagues = 5;
    public float nextVagueTime = 4;
    int cptVague = 0;

    public GameObject Ennemi;
    GameObject planet;

    float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        GetPlanet();

        SpawnEnnemi();
        StartCoroutine("TimerNextVague");
    }

    IEnumerator TimerNextVague()
    {
        yield return new WaitForSeconds(nextVagueTime);
        SpawnEnnemi();
        if(cptVague < nbVagues)
            StartCoroutine("TimerNextVague");
        cptVague++;

    }

    public void GetPlanet()
    {
        planet = GameObject.Find("Planet");
    }

    int distanceSpawn = 10;

    public void SpawnEnnemi()
    {
        float scale = planet.transform.localScale.x + distanceSpawn;
        float x = Random.Range(-scale, scale);
        float z = Random.Range(-scale, scale);

        float hypo = Mathf.Sqrt(x * x + z * z);
        float y = Mathf.Sqrt(Mathf.Abs( scale * scale - hypo * hypo));
        int side = Random.Range(0, 2);
        Vector3 positionSpawn;
        if(side == 0)
            positionSpawn = new Vector3(x, y, z);
        else
            positionSpawn = new Vector3(x, -y, z);



        GameObject ennemi = Instantiate(Ennemi, positionSpawn, Quaternion.identity);
    }
}
