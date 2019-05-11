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

    public GameObject player;
    public GameObject gameManager;

    public GameObject canvasJouer;

    // Start is called before the first frame update
    void Start()
    {
        cameraGameObject.position = menuPosition.position; //position initiale de la camera au menu
        play = false;
        canvasJouer = GameObject.Find("Canvas_jouer");
        canvasJouer.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (play)
        {
            Debug.Log("Game Sart");
            cameraGameObject.localPosition = Vector3.Lerp(menuPosition.localPosition, playPosition, transitionSpeed * Time.deltaTime);
            //Quaternion targetRotation = Quaternion.LookRotation()
            //cameraGameObject.transform.LookAt(robot);
            cameraGameObject.localRotation = Quaternion.Slerp(cameraGameObject.localRotation, Quaternion.Euler(90, 0, 0), transitionSpeed * Time.deltaTime);

            canvasJouer.SetActive(true);
        }

        if (cameraGameObject.localPosition.y == playPosition.y)
        {
            play = false; //Arreter le mouvement de la camera mais le jeu continue
            Debug.Log("STOP");


            //Canvas set active
            

            //Activation des scripts quand la camera est bien placee et on est pret a jouer.

            //Player
            player.GetComponent<Player_Menu_Mvt>().gameObject.SetActive(false);
            player.GetComponent<PlayerMouvement>().gameObject.SetActive(true);

            //Game manager
            gameManager.GetComponent<GenerationEnnemi>().gameObject.SetActive(true);
        }


    }

    public void CameraStartGame()
    {
        play = true;
        GameObject.Find("Canvas_menu").SetActive(false);

        



    }
}
