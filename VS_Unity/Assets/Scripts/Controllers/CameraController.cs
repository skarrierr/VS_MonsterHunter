using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float targetDistance;

    private float rotationX;

    public bool auto = false;

    public float tiempo;

    private float rotationY;
    [SerializeField]
    private GameObject target;
    [SerializeField]
    private float cameraLerp;

    public float segundos;

    Vector3 prevMouse;

    public float offsetX;
    public float offsetY;

    private void LateUpdate()
    {


        if (!auto)
        {
            rotationX += Input.GetAxis("Mouse Y");
            rotationY += Input.GetAxis("Mouse X");
            rotationX = Mathf.Clamp(rotationX, -50f, 50f);
            transform.eulerAngles = new Vector3(rotationX, rotationY, 0);


            targetDistance += Input.mouseScrollDelta.x;
            targetDistance -= Input.mouseScrollDelta.y;


            Vector3 finalposition = target.transform.position - transform.forward * targetDistance;

            RaycastHit hit;

            if (Physics.Linecast(target.transform.position, finalposition, out hit))
            {
                finalposition = hit.point;
            }






            transform.position = finalposition;



        }
       



       



       




    }

}
