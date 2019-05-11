using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemi : MonoBehaviour
{

    int vie = 2;
    int vitesse = 1;
    int damage = 1;

    Vector3 direction;
    Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        direction = transform.forward;
    }

    private void FixedUpdate()
    {
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.TransformDirection(direction) * vitesse * Time.deltaTime);

        //rotation
        if (Random.value == 0)
            transform.Rotate(0, Random.Range(0f, 5f), 0);
        else
            transform.Rotate(0, Random.Range(-5f, 0f), 0);

    }
}
