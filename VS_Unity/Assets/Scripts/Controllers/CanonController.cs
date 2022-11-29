using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonController : MonoBehaviour
{

    public GameObject Camera;
    public bool aiming;
    public bool CanShoot;
    public GameObject CanonBall;
    public GameObject CanonSpawn;

    public float tiempo;
    public float CanonCooldown;
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
        /* if (!CanShoot)
         {
             tiempo += Time.deltaTime;
             if (tiempo >= CanonCooldown)
             {
                 tiempo = 0;
                 CanShoot = true;
             }
         }*/

        if (Input.GetKey(KeyCode.P) && CanShoot)
        {
            GameObject _canon = Instantiate(CanonBall, CanonSpawn.transform);
            _canon.GetComponent<Rigidbody>().AddForce(_canon.transform.forward, ForceMode.Impulse);
            _canon.GetComponent<Rigidbody>().AddForce(_canon.transform.up, ForceMode.Impulse);

           // CanShoot = false;
        }
    }
}
