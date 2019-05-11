using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemi : MonoBehaviour
{

    static int nbEnnemi = 0;

    float vie = 2;
    int vitesse = 1;
    int damage = 1;

    Vector3 direction;
    Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        ++nbEnnemi;
        rb = GetComponent<Rigidbody>();
        timeToMutate = Random.Range(3f, 8f);
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bullet")
        {
            Debug.Log("touch");
            vie -= other.GetComponent<GunBall>().damage;
            if(vie == 0)
            {
                //TODO instanstiate explosion
                Destroy(gameObject);
            }
        }
    }
}
