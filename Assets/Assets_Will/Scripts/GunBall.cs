﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBall : MonoBehaviour
{

    public float damage = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Planet" || other.tag == "Ennemi")
        {
            //TODO instantiate explosion
            Destroy(gameObject);
        }
    }
}
