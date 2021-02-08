using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public AudioSource Sound;
    // void Start()
    // {
        
    // }
    // void Update()
    // {
        
    // }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Line")
        {
            Sound.Play();
        }
    }
}
