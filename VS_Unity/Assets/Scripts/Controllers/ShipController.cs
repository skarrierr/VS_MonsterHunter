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
    

    public float corriente;

    public bool IsInGarage = false;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
     
    }

    
    void Update()
    {

        Mov = Input.GetAxis("Vertical");


    }

    private void FixedUpdate()
    {
        Move();

          


        
      

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Garage")
        {
            if (Input.GetKeyDown(KeyCode.E)) { IsInGarage = !IsInGarage; }
           
        }
    }
     


    public void Garage(){
        

    }


   public void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.TransformDirection(new Vector3(0, 0, Mov * speed * Time.fixedDeltaTime)), ForceMode.Force);
            rb.AddForce(transform.TransformDirection(new Vector3(0, 0, corriente * Time.fixedDeltaTime)), ForceMode.Force);
            if (rb.velocity.magnitude >= Maxspeed)
            {
                Vector3 direction = rb.velocity.normalized;
                rb.velocity = Maxspeed * direction;
            }
        }
        transform.Rotate(Vector3.up * SpeedRotation * Input.GetAxis("Horizontal") * Time.deltaTime);
    }
}
