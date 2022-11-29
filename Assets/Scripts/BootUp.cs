using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BootUp : MonoBehaviour
{
    void ChangeScene()
    {
        //Load title scene
        SceneManager.LoadScene(1);
    }
}
