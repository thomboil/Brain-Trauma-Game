using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadForce : MonoBehaviour
{
    public float force = 5;
    Rigidbody rb;
    CameraHead ch;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        StartCoroutine("TimerHeadForce");

        ch = Camera.main.GetComponent<CameraHead>();
    }

    IEnumerator TimerHeadForce()
    {
        yield return new WaitForSeconds(1);
        rb.useGravity = true;

        float x = Random.value;
        float y = Random.value;
        float z = Random.value;
        rb.AddForce(new Vector3(x,y,z).normalized * force, ForceMode.Impulse);


    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.name == "Ground")
        {
            rb.isKinematic = true;
            ch.StartMouvement();
        }
    }

}
