using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemi : MonoBehaviour
{

    public static int nbEnnemi = 0;

    float vie = 1;
    float vieIni;
    int vitesse = 1;
    int damage = 1;

    Vector3 direction;
    Rigidbody rb;
    Material mat;
    ParticleSystem ps;
    float psRadiusIni;

    public ParticleSystem rocket;

    // Start is called before the first frame update
    void Start()
    {
        ++nbEnnemi;
        rb = GetComponent<Rigidbody>();
        timeToMutate = Random.Range(10f, 15f);

        ps = GetComponentInChildren<ParticleSystem>();
        psRadiusIni = ps.shape.radius;

        mat = GetComponent<Renderer>().material;

        vieIni = vie;
    }


    float timerMutate = 0;
    float timeToMutate = 4;
    // Update is called once per frame
    void Update()
    {
        direction = transform.forward;
        timerMutate += Time.deltaTime;
        if(timerMutate > timeToMutate)
        {
            Mutate();
            timeToMutate = Random.Range(3f, 8f);
            timerMutate = 0;
        }
    }

    float timerRotation = 0;
    int rotationSide = 0;

    private void FixedUpdate()
    {
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.TransformDirection(direction) * vitesse * Time.deltaTime);

        //rotation
        if(timerRotation > 1)
        {
            int r = Random.Range(0, 3);
            if (r == 0)
                rotationSide = 1;
            else if (r == 1)
                rotationSide = -1;
            else
                rotationSide = 0;
            timerRotation = 0;
        }
        

        if(rotationSide == 1)
            transform.Rotate(0, Random.Range(0f, 5f), 0);
        else if(rotationSide == -1)
            transform.Rotate(0, Random.Range(-5f, 0f), 0);
        timerRotation += Time.deltaTime;
    }

    private void Mutate()
    {
        if(nbEnnemi < 50)
        {
            Instantiate(gameObject, transform.position, transform.rotation);

        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.tag == "FlareCollider")
    //    {
    //        Debug.Log("touch");
    //        vie -= other.GetComponent<Flare>().damage;
    //        if(vie == 0)
    //        {
    //            //TODO instanstiate explosion
    //            Destroy(gameObject);
    //        }
    //    }

    //    if(other.tag == "Player")
    //    {
    //        --nbEnnemi;
    //        Destroy(gameObject);
    //    }
    //}

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "FlareCollider")
        {
            Debug.Log("touch");
            vie -= other.GetComponent<Flare>().damage;
            if (vie <= 0)
            {
                --nbEnnemi;

                var r = Instantiate(rocket, transform.position, transform.rotation);
                //TODO instanstiate explosion
                Destroy(gameObject);
            }
            HaloRange();
            ColorBaked();
        }
    }

    private void HaloRange()
    {
        var r = ps.shape;
        r.radius = psRadiusIni * vie;
    }

    private void ColorBaked()
    {
        mat.color = new Color(vie, mat.color.b, mat.color.g, mat.color.a);
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.collider.tag == "Player")
    //    {
    //        --nbEnnemi;
    //        Debug.Log("Heyyy");
    //        Destroy(gameObject);

    //    }
    //}
}
