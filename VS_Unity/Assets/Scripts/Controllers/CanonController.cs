using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonController : MonoBehaviour
{

    public GameObject Camera;
    public bool aiming;
    
    void Start()
    {
       
    }

    
    void Update()
    {
        aiming = Camera.GetComponent<CameraController>().aiming;

        if (aiming)
        {
            this.transform.rotation = Camera.transform.rotation;
        }
    }
}
