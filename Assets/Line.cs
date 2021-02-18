using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    public int Go = 0;
    public Rigidbody Body;
    void Start()
    {
        Body = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if(Go == 0)
            {
                GetComponent<MeshRenderer>().enabled = true;
                GetComponent<Collider>().enabled = true;
                Go = 1;
            }
            else
            {
                Go = 0;
                GetComponent<MeshRenderer>().enabled = false;
                GetComponent<Collider>().enabled = false;
                transform.position = new Vector3(10,0.6f,0);
                Body.velocity = new Vector3(0,0,0);
            } 
        }
        if (Go == 1)
        {
            Body.velocity = new Vector3(0,0,20);
        }
        if (transform.position.z > 100)
        {
            Go = 0;
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
            transform.position = new Vector3(10,0.6f,0);
            Body.velocity = new Vector3(0,0,0);
        }

    }
}