using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject gunBall;
    public float speedShot = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //TODO choisir les inputs pour shoot
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("hi");
            GameObject ball;
            ball = Instantiate(gunBall, transform.position, transform.rotation);
            ball.GetComponent<Rigidbody>().AddForce(ball.transform.forward * speedShot, ForceMode.Impulse);

        }
    }


}
