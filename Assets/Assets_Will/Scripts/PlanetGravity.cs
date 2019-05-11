using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGravity : MonoBehaviour
{

    public float gravity = -15;

    public void Attraction(Transform playerTransform, float g)
    {
        Vector3 gravityDirection = (playerTransform.transform.position - transform.position).normalized;

        playerTransform.GetComponent<Rigidbody>().AddForce(gravityDirection * g);

        Vector3 localUp = playerTransform.up;
        Quaternion targetRotation = Quaternion.FromToRotation(localUp, gravityDirection) * playerTransform.rotation;
        playerTransform.rotation = Quaternion.Slerp(playerTransform.rotation, targetRotation, 50f * Time.deltaTime);

    }

}
