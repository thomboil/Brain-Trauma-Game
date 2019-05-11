using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetColor : MonoBehaviour
{
    GameObject planet;

    Material mat;
    Color couleurInitiale;
    public static int nbMaxEnnemi = 25;
    // Start is called before the first frame update
    void Start()
    {
        GetPlanet();
    }

    void GetPlanet()
    {
        planet = GameObject.Find("Planet");
        mat = planet.GetComponent<Renderer>().material;

        couleurInitiale = mat.color;
    }

    float nbEnnemi = 0;
    // Update is called once per frame
    void Update()
    {
        nbEnnemi = Ennemi.nbEnnemi / (float)nbMaxEnnemi;
        mat.color = new Color(couleurInitiale.r, couleurInitiale.b - nbEnnemi, couleurInitiale.g - nbEnnemi, couleurInitiale.a);
    }
}
