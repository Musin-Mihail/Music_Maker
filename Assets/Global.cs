using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour
{
    static public int StatusBuild = 1;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            StatusBuild = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            StatusBuild = 2;
        }
    }
}
