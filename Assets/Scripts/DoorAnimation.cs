using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimation : MonoBehaviour
{
    Animator doorAnimator;

    // Start is called before the first frame update
    void Start()
    {
        doorAnimator = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(OpenDoor());

        }
    }
    IEnumerator OpenDoor()
    {
        doorAnimator.SetBool("openDoor", true);
        yield return new WaitForSeconds(2);
        doorAnimator.SetBool("openDoor", false);

    }
}
