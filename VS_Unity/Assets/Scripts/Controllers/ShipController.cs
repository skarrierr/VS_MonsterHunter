using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipController : MonoBehaviour
{
    public Rigidbody rb;
    public GameManager manager;
    public float SpeedRotation;
    public float speed;
    public float Maxspeed;
    public float Damage;
    float Mov;
    public GameObject DieText;
    public GameObject mirilla;
    public float ImpactForce;
    public float corriente;
    
    public bool IsInGarage = false;

    public GameObject Floater1;
    public GameObject Floater2;
    public GameObject Floater3;
    public GameObject Floater4; 
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
       
    }


    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        if (Input.GetKeyDown(KeyCode.R))
        {
            CambiarEscena(0);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        Rotate();
        
        {

            if (transform.position.y <= 5 && transform.position.y >= -5)
            {
                Move();

            }
            else
            {
                DieText.SetActive(true);
            }


            rb.AddForce(manager.viento * Time.fixedDeltaTime, ForceMode.Force);

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
               //rb.velocity = Maxspeed * direction;
            }

        }
        transform.Rotate(Vector3.up * SpeedRotation * Input.GetAxis("Horizontal") * Time.deltaTime);
    }

    public void Rotate()
    {
        Mov = Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
           
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Boss")
        {

            manager.HealthCasco = manager.HealthCasco - Damage;
            rb.AddForce(new Vector3(0,0,-1 * ImpactForce), ForceMode.Force);
            if (manager.HealthCasco <= 0)
            {
                Floater1.SetActive(false);
                Floater2.SetActive(false);
                Floater3.SetActive(false);
                Floater4.SetActive(false);
                DieText.SetActive(true);
            }
        }
    }

    public void CambiarEscena(int _id)
    {
        SceneManager.LoadScene(_id);
    }
}
