using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationEnnemi : MonoBehaviour
{

    public int nbVagues = 5;
    public float nextVague = 4;

    public GameObject Ennemi;
    GameObject planet;

    float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        SpawnEnnemi();
        StartCoroutine("TimerNextVague");
        GetPlanet();
    }

    IEnumerable TimerNextVague()
    {
        yield return new WaitForSeconds(nextVague);
        SpawnEnnemi();
        StartCoroutine("TimerNextVague");

    }

    public void GetPlanet()
    {
        planet = GameObject.FindGameObjectWithTag("Planet");
    }

    int distanceSpawn = 10;

    public void SpawnEnnemi()
    {
        float scale = planet.transform.localScale.x + distanceSpawn;
        float x = Random.Range(-scale, scale);
        float z = Random.Range(-scale, scale);

        float hypo = Mathf.Sqrt(x * x + z * z);
        float y = Mathf.Sqrt(scale * scale - hypo * hypo);

        Vector3 positionSpawn = new Vector3(x, y, z);

        GameObject ennemi = Instantiate(Ennemi, positionSpawn, Quaternion.identity);
    }
}
