using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class pourcentage : MonoBehaviour
{

    public Text pourcentageTxt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int pourcentage = (1 - (Ennemi.nbEnnemi / PlanetColor.nbMaxEnnemi))*100;
        pourcentageTxt.text = pourcentage.ToString();
    }
}
