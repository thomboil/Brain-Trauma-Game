using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGravity : MonoBehaviour
{
    public float gravity = -15;

    PlanetGravity planetScript;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;

        GetPlanet();
    }

    public void GetPlanet()
    {
        planetScript = GameObject.Find("Planet").GetComponent<PlanetGravity>();

    }

    // Update is called once per frame
    void Update()
    {
        if(planetScript)
        {
            planetScript.Attraction(transform, gravity);
        }
    }
}
