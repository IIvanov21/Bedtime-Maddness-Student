using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    //Delegates for Cursor State function
    public delegate void CursorDelegate(bool cursorState);
    public static CursorDelegate cursorDelegate;
    // Start is called before the first frame update
    void Start()
    {
        cursorDelegate = CursorMode;
    }


    public void CursorMode(bool cursorState)
    {

        if (cursorState)//Bind Cursor
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        if(!cursorState)//Release Cursor
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
    }
}
