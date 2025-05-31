using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Rigidbody Body;
    public GameObject Marker;
    Vector3 target;
    int layerMask = 1 << 6; //Plane
    RaycastHit hit;
    RaycastHit hit2;
    void Start()
    {
        Body = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(Input.anyKey)
        {
            if (Input.GetKeyDown("w"))
            {
                Body.AddRelativeForce(Vector3.forward*500);
            }
            if (Input.GetKeyDown("s"))
            {
                Body.AddRelativeForce(Vector3.back*500);
            }
            if (Input.GetKeyDown("a"))
            {
                Body.AddRelativeForce(Vector3.left*500);
            }
            if (Input.GetKeyDown("d"))
            {
                Body.AddRelativeForce(Vector3.right*500);
            }
            if (Input.GetKeyDown("q"))
            {
                Body.AddRelativeForce(Vector3.up*500);
            }
            if (Input.GetKeyDown("e"))
            {
                Body.AddRelativeForce(Vector3.down*500);
            }
        }
        else
        {
            Body.linearVelocity = new Vector3(0,0,0);
        }

        float rotationY = Input.GetAxis("Mouse X") * 5;//Позиция мыши по X
        float rotationX = Input.GetAxis("Mouse Y") * 5;//Позиция мыши по Y
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0.0f);//Запрет поворота по Z
        transform.Rotate(0, rotationY, 0);// поворот по горизонтали
        transform.Rotate(-rotationX, 0, 0);// поворот по вертикали

        if(Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, layerMask))
        {
            target = new Vector3(hit.point.x, 0.5f ,hit.point.z);
            Marker.transform.position = target;
        }
        else
        {
            Marker.transform.position = new Vector3(0,0,-30);
        }

        // if (Global.StatusBuild == 2)
        // {
        //     if(Physics.Raycast(transform.position, transform.forward, out hit2, Mathf.Infinity, layerMask2))
        //     {
        //         hit2.collider.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
        //     }
        // }
    }
}
