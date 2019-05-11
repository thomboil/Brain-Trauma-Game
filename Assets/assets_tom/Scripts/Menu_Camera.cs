using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Camera : MonoBehaviour
{
    public float transitionSpeed;
    public static bool play;

    public Vector3 playPosition;
    public Transform menuPosition;
    public Transform robot;

    public Transform cameraGameObject;
    // Start is called before the first frame update
    void Start()
    {
        cameraGameObject.position = menuPosition.position; //position initiale de la camera au menu
        play = false;
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


        }

        if (cameraGameObject.localPosition.y == playPosition.y)
        {
            play = false; //Arreter le mouvement de la camera mais le jeu continue
            Debug.Log("STOP");

        }


    }

    public void CameraStartGame()
    {
        play = true;

    }
}
