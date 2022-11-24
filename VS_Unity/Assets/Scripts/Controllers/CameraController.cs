using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    public float actualtargetDistance;
    public float targetDistance;
    public float CanontargetDistance;

    private float rotationX;

    public bool aiming = false;

    public float tiempo;

    private float rotationY;
    [SerializeField]
    private GameObject actualtarget;
    public GameObject target;
    public GameObject canontarget;
    [SerializeField]
    private float cameraLerp;

    

    

    public float offsetX;
    public float offsetY;

    private void LateUpdate()
    {
            rotationX += Input.GetAxis("Mouse Y");
            rotationY += Input.GetAxis("Mouse X");
            rotationX = Mathf.Clamp(rotationX, -50f, 50f);
            transform.eulerAngles = new Vector3(rotationX, rotationY, 0);


            actualtargetDistance += Input.mouseScrollDelta.x;
            actualtargetDistance -= Input.mouseScrollDelta.y;


            Vector3 finalposition = actualtarget.transform.position - transform.forward * actualtargetDistance;

            RaycastHit hit;

            if (Physics.Linecast(actualtarget.transform.position, finalposition, out hit))
            {
                finalposition = hit.point;
            }


            transform.position = finalposition;
       
       



      
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            aiming = !aiming;
        }
        else {
          //  aiming = false;
        }

        if (aiming)
        {
            actualtarget = canontarget;
            actualtargetDistance = CanontargetDistance;

        }
        else
        {
            actualtarget = target;
            actualtargetDistance = targetDistance;
        }
    }

}
