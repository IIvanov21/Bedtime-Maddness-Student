using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    const string xAxis = "Mouse X";
    const string yAxis = "Mouse Y";

    [SerializeField]
    GameObject mainCamera;

    public float mouseSensitivity = 500.0f;

    float xRotation = 0.0f;

    bool captureMouse=true;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX=Input.GetAxis(xAxis) * mouseSensitivity*Time.deltaTime;
        float mouseY = Input.GetAxis(yAxis) * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90.0f, 90.0f);

        transform.Rotate(Vector3.up * mouseX);

        mainCamera.transform.localRotation = Quaternion.Euler(xRotation, 0.0f, 0.0f);

        if(Input.GetKeyDown(KeyCode.Escape)) CaptureMouse();
    }

    void CaptureMouse()
    {
        captureMouse = !captureMouse;

        if (captureMouse)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
    }
}
