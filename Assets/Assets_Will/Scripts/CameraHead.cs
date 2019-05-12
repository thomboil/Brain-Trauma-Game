using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CameraHead : MonoBehaviour
{
    public float speedRotation = 5;
    public float speedMouvement = 5;
    public float speedThickness = 0.1f;

    bool startMotion = false;

    GameObject head;
    GameObject panel;
    Image image;


    // Start is called before the first frame update
    void Start()
    {
        head = GameObject.Find("PositionHead");/*.GetComponentsInChildren<GameObject>().First(x => x.name == "position");*/
        panel = GameObject.Find("Panel");
        image = panel.GetComponent<Image>();
    }


    // Update is called once per frame
    void Update()
    {
        if(startMotion)
        {

            Quaternion targetRotation = Quaternion.LookRotation(head.transform.position - transform.position);

            // Smoothly rotate towards the target point.
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speedRotation * Time.deltaTime);

            if(targetRotation == transform.rotation)
            {
                Vector3 destination = head.transform.position;
                transform.position = Vector3.Lerp(transform.position, destination, speedMouvement * Time.deltaTime);
                if (image.color.a < 1)
                    image.color = new Color(image.color.r, image.color.b, image.color.g, image.color.a + speedThickness);
                else
                    SceneManager.LoadScene(1);
            }
        }
    }

    public void StartMouvement()
    {
        startMotion = true;
    }
}
