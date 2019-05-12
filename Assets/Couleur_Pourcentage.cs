using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Couleur_Pourcentage : MonoBehaviour
{
    public Text pourcentageTxt;
    public Color color;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //mat.color = new Color(couleurInitiale.r, couleurInitiale.b - nbEnnemi, couleurInitiale.g - nbEnnemi, couleurInitiale.a);
        float pourcentageSantePlanete = 2*((float)Ennemi.nbEnnemi / (float)PlanetColor.nbMaxEnnemi);
        pourcentageTxt.color = new Color(color.r,  color.g - pourcentageSantePlanete, color.b - pourcentageSantePlanete, color.a);
    }
}
