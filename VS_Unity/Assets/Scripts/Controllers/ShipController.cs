using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public Rigidbody rb;
    public GameManager manager;
    public float SpeedRotation;
    public float speed;
    public float Maxspeed;
    float Mov;
    

    public float corriente;

    public bool IsInGarage = false;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
     
    }

    
    void Update()
    {

        Rotate();


    }

    private void FixedUpdate()
    {

        if (transform.position.y <= 5)
        {
            Move();
        }
          


        
      

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

            manager.CompleteQuest(0,0);
        }
        transform.Rotate(Vector3.up * SpeedRotation * Input.GetAxis("Horizontal") * Time.deltaTime);
    }

    public void Rotate()
    {
        Mov = Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
            manager.CompleteQuest(0, 1);
        }
        
    }
    
}
