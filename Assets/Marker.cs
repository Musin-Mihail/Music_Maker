using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marker : MonoBehaviour
{
    public GameObject MarkerNote;
    public GameObject DeleteNote;
    public string NameNote;
    public Vector3 NewVector3;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            if(Global.StatusBuild == 1)
            {
                if(NameNote != null)
                {
                    Instantiate(Resources.Load(NameNote),NewVector3, Quaternion.identity);
                }
            }
            // if(Global.StatusBuild == 2)
            // {
            //     if(DeleteNote != null)
            //     {
            //         Destroy(DeleteNote);
            //     }
            // }
        }
        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            if(DeleteNote != null)
            {
                Destroy(DeleteNote);
            }
        }
    }

    void OnTriggerStay(Collider other)
    {  
        if (other.tag == "NoteLine")
        {
            if(Global.StatusBuild == 1)
            {
                NewVector3 = new Vector3(other.transform.position.x, 0.5f, transform.position.z);
                MarkerNote.transform.position = NewVector3;
                NameNote = other.name;
            }
        }

        if (other.tag == "Note")
        {
            // if(Global.StatusBuild == 2)
            // {
                DeleteNote = other.gameObject;
            // }
        }
    }
    // void OnTriggerEnter(Collider other)
    // {  
    //     if (other.tag == "NoteLine")
    //     {
    //         NameNote = other.name;
    //     }
    // }
    void OnTriggerExit(Collider other)
    {  
        if (other.tag == "NoteLine")
        {
            NameNote = null;
            MarkerNote.transform.position = new Vector3(0,0,-200);
        }
        if (other.tag == "Note")
        {
            DeleteNote = null;
        }
    }
}
