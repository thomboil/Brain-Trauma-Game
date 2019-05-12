using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Menu_Mvt : MonoBehaviour
{
   Vector3 direction;
    float rotation;
    Rigidbody rb;

    public float speedMouvement = 5;
    public float speedRotation = 5;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector3(0, 0, 1).normalized;
   
    }

    void FixedUpdate()
    {
        //rb.AddForce(direction * speed);
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.TransformDirection(direction) * speedMouvement * Time.deltaTime);
   
    }
}
