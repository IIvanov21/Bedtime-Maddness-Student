using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BootUp : MonoBehaviour
{
    void ChangeLevel()
    {
        SceneManager.LoadScene(1);
    }
}
