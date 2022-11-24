using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public Rigidbody rb;
    public float SpeedRotation;
    public float speed;
    public float Maxspeed;
    float Mov;
    public GameObject Sea;
    public float corriente;

   
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GetCorriente();
    }

    // Update is called once per frame
    void Update()
    {

        Mov = Input.GetAxis("Vertical");

  
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.TransformDirection(new Vector3(0, 0, Mov * speed *Time.fixedDeltaTime)), ForceMode.Force);
            rb.AddForce(transform.TransformDirection(new Vector3(0, 0, corriente * Time.fixedDeltaTime)), ForceMode.Force);

           if(rb.velocity.magnitude >= Maxspeed)
            {
                Vector3 direction = rb.velocity.normalized;
                rb.velocity = Maxspeed * direction;
            } 
     
        }
       


        transform.Rotate(Vector3.up * SpeedRotation * Input.GetAxis("Horizontal") * Time.deltaTime);

    }

    public void GetCorriente()
    {
        corriente = Sea.GetComponent<WaterManager>().Corriente;
    }

   



   
}
