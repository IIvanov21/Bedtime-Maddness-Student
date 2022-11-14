using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager instance;
    public static GameManager Instance
    {
        get { return instance; }
        private set { instance = value; }
    }

    private void Awake()
    {
        CheckGameManager();
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }

    //Scenes values
    public int currentScene = 0;
    public static int gameLevelScenes = 4;
   

    // Start is called before the first frame update
    void Start()
    {
        //1. Configure our light settings
        LightSetup(currentScene);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void LightSetup(int sceneIndex)
    {
        switch (sceneIndex)
        {
            case (int)ScenesManager.Scenes.waveOne: case 3: case 4: case 5:
                {
                    //1. Get a reference to our light
                    GameObject dirLight = GameObject.Find("Directional Light");
                    dirLight.transform.position = new Vector3(30, 55, -50);//Set a default position
                    dirLight.transform.eulerAngles = new Vector3(22, -30, 0); //Set a default rotation
                    dirLight.GetComponent<Light>().color = new Color32(102, 118, 130, 255);

                    break;
                }
        }
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

    void CheckGameManager()
    {
        //If we are creating the Game Manager for a first time
        //Assign it to our instance that we are using as accessor(singleton)
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        //If it does already exist destroy the new game object.
        else Destroy(this.gameObject);
    }
}
