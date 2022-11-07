using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        //1. Configure our light settings
        LightSetup();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void LightSetup()
    {
        //1. Get a reference to our light
        GameObject dirLight = GameObject.Find("Directional Light");
        dirLight.transform.position = new Vector3(30, 55, -50);//Set a default position
        dirLight.transform.eulerAngles = new Vector3(22, -30, 0); //Set a default rotation
        dirLight.GetComponent<Light>().color = new Color32(102, 118, 130, 255);
    }

    //2. Create configuration for out Camera
    void FirstPersonCameraSetup()
    {
        //Get the camera reference using tag system
        GameObject gameCamera = GameObject.FindGameObjectWithTag("MainCamera");
        //Set the camera's position
        gameCamera.transform.position = new Vector3(0, 0.7f, 0.3f);
        //Set the rotation
        gameCamera.transform.eulerAngles = Vector3.zero;
        //Set rendering method
        gameCamera.GetComponent<Camera>().clearFlags = CameraClearFlags.Skybox;

    }
}
