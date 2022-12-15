using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameManager manager;

    public enum EnemyType { NONE, ARPIA, PEZ }
    public enum EnemyState { NONE, PATROLING,CHASING, ATTACK }
    public EnemyType Type;
    public EnemyState State;

    public float Attackspeed;
    public float tiempo;
    public float timing;
    public float Attacktiming;
    public float SpeedRotation;
    public float speed;

    public float Life;

    public Collider LootCollider;
    public Collider NormalCollider;

    public GameObject LootParticles;
    public GameObject Floater;

    public bool Islooting;

    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            Islooting = true;
        }
        else
        {
            Islooting = false;
        }

            switch (Type)
        {
            case EnemyType.NONE:
                break;
            case EnemyType.ARPIA:

                switch (State)
                {
                    case EnemyState.NONE:
                        break;
                    case EnemyState.PATROLING:
                        Patroling();
                        break;
                    case EnemyState.CHASING:
                        break;
                    case EnemyState.ATTACK:
                        break;
                    default:
                        break;
                }


                break;
            case EnemyType.PEZ:
                switch (State)
                {
                    case EnemyState.NONE:
                        break;
                    case EnemyState.PATROLING:
                        Patroling();
                        break;
                    case EnemyState.CHASING:
                        break;
                    case EnemyState.ATTACK:
                        break;
                    default:
                        break;
                }
                break;
            default:
                break;
        }
    }
    
    public void Patroling()
    {
        tiempo = tiempo + Time.deltaTime;


        if (tiempo >= timing - 2)
        {

            transform.Rotate(new Vector3(0, SpeedRotation * Random.Range(-1, 1) * Time.deltaTime,0) );
            if (tiempo >= timing)
            {
                tiempo = 0;
            }
        }



        transform.position = transform.position + transform.forward * speed * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "Bullet")
        {
            Destroy(other.gameObject);
            Life = Life - manager.bulletDamage;
            if (Life <= 0)
            {
                State = EnemyState.NONE;
                NormalCollider.enabled = false;
                LootCollider.enabled = true;
                Floater.SetActive(true);
                LootParticles.SetActive(true);
                //transform.GetChild(1).transform.Rotate(new Vector3(0,0,90));
            }
        }
        
    }
    private void OnTriggerStay(Collider other) {
        if (other.gameObject.tag == "Player")
        {
            if (Islooting)
            {
                switch (Type)
                {
                    case EnemyType.NONE:
                        break;
                    case EnemyType.ARPIA:
                        manager.Inventory.Add(2);
                        break;
                    case EnemyType.PEZ:
                        manager.Inventory.Add(1);
                        break;
                }
                Destroy(this.gameObject);
            }

        }

    }
}
