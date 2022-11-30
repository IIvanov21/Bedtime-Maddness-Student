using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLevel : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameManager.Instance.GetComponent<ScenesManager>().NextLevel();
    }
}
