using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu_Camera : MonoBehaviour
{
    public float transitionSpeed;
    public static bool play;

    public Vector3 playPosition;
    public Transform menuPosition;
    public Transform robot;

    public Transform cameraGameObject;

    //References par game object
    public GameObject player;
    public GameObject gameManager;

    public GameObject canvasJouer;

    //Declaration des scripts
    private Player_Menu_Mvt playerMenuMvtScript;
    private PlayerMouvement playerMouvementScript;
    private GenerationEnnemi generationEnnemiScript;

    // Start is called before the first frame update
    void Start()
    {
        play = false;
        cameraGameObject.position = menuPosition.position; //position initiale de la camera au menu
        
        //Canvas Jouer au debut
        canvasJouer = GameObject.Find("Canvas_jouer");
        canvasJouer.SetActive(false);

        //Script mouvement du menu
        playerMenuMvtScript = player.GetComponent<Player_Menu_Mvt>();
        playerMenuMvtScript.enabled = true;
        //Script mouvement dans la game
        playerMouvementScript = player.GetComponent<PlayerMouvement>();
        playerMouvementScript.enabled = false;

        //Script generation ennemi dans la game
        generationEnnemiScript = gameManager.GetComponent<GenerationEnnemi>();
        generationEnnemiScript.enabled = false;
    }   
    bool oneTime = true;
    // Update is called once per frame
    void Update()
    {
        if (play) //Si on click sur start game:
        {
            //Deplacement de la camera
            cameraGameObject.localPosition = Vector3.Lerp(menuPosition.localPosition, playPosition, transitionSpeed * Time.deltaTime);
            cameraGameObject.localRotation = Quaternion.Slerp(cameraGameObject.localRotation, Quaternion.Euler(90, 0, 0), transitionSpeed * Time.deltaTime);

            //Activation canvas de jeu
            canvasJouer.SetActive(true);

            //Activation des scripts de jeu
            playerMenuMvtScript.enabled = false;
            playerMouvementScript.enabled = true;

            generationEnnemiScript.enabled = true;
        }

        if (cameraGameObject.localPosition.y == playPosition.y && oneTime)
        {
            oneTime = false;
            play = false; //Arreter le mouvement de la camera mais le jeu continue
            Debug.Log("STOP");


      
        }


    }

    public void CameraStartGame()
    {
        play = true;
        GameObject.Find("Canvas_menu").SetActive(false);
    }
}
