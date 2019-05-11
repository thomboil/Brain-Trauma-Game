using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvement : MonoBehaviour
{

    Vector3 direction;
    float rotation;
    Rigidbody rb;

    public float speedMouvement = 2;
    public float speedRotation = 2;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector3(0, 0, Input.GetAxis("Vertical")).normalized;
        rotation = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        //rb.AddForce(direction * speed);
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.TransformDirection(direction) * speedMouvement * Time.deltaTime);
        transform.Rotate(0, rotation* speedRotation, 0);
    }
}
