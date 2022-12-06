using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class AudioTrigger : MonoBehaviour
{
    [SerializeField]
    private UnityEvent audioEvent;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            audioEvent.Invoke();
        }
    }
}
