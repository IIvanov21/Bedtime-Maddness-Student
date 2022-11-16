using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Singleton value
    private static GameManager instance;
    public static GameManager Instance
    {
        get { return instance; }
        private set { instance = value; }
    }
    //Player values
    public static int playerHealth = 0;

    private void Awake()
    {
        CheckGameManager();
    }
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

    void CheckGameManager()
    {
        //Create a Game Manager singleton if one doesn't exist
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(this.gameObject);//Destroy the new instance if a singleton already exist
    }

    public void LifeSystemTracker()
    {
        if (playerHealth < 100)
        {
            Debug.Log("Player's current suffocation level is: " + playerHealth + "%");
        }
        else
        {//If we die load the game over scene
            Debug.Log("Player's current suffocation level is: " + playerHealth + "% We are dead!");
            GetComponent<ScenesManager>().GameOver();

        }
    }
}
