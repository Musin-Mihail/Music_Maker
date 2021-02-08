using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Rigidbody Body;
    public GameObject Do;
    Vector3 target;
    int layerMask = 1 << 6;
    RaycastHit hit;
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
            Body.velocity = new Vector3(0,0,0);
        }
        float rotationY = Input.GetAxis("Mouse X") * 10;//Позиция мыши по X
        float rotationX = Input.GetAxis("Mouse Y") * 10;//Позиция мыши по Y
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0.0f);//Запрет поворота по Z
        transform.Rotate(0, rotationY, 0);// поворот по горизонтали
        transform.Rotate(-rotationX, 0, 0);// поворот по вертикали
        // target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, layerMask);
        if(Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, layerMask))
        {
            target = new Vector3(hit.point.x, 0.5f ,hit.point.z);
            Do.transform.position = target;
        }
        else
        {
            Do.transform.position = new Vector3(0,0,-30);
        }
        
        // Debug.Log(hit.point);
        // Debug.DrawRay(transform.position, transform.forward*20,Color.green,0.5f);
        // Debug.Log(hit.collider.name);
    }
}
