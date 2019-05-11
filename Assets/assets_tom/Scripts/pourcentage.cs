using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class pourcentage : MonoBehaviour
{

    public Text pourcentageTxt;
    public GameObject audioBad;

    // Start is called before the first frame update
    void Start()
    {
        audioBad.GetComponent<AudioSource>().volume = 0;
    }

    // Update is called once per frame
    void Update()
    {

        //Calcul et affichage de la sante de la planete
        int pourcentage = (1 - (Ennemi.nbEnnemi / PlanetColor.nbMaxEnnemi))*100;
        pourcentageTxt.text = pourcentage.ToString() + "%";

        //Le son de peur augmente quand la planete est infectee
        audioBad.GetComponent<AudioSource>().volume = Ennemi.nbEnnemi / PlanetColor.nbMaxEnnemi;

    }
}
