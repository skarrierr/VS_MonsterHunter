using Newtonsoft.Json.Bson;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;



public class MobController : MonoBehaviour
{
    //Asegurar que todos que el tiempo vuelva a cero antes de cambiar de estado
  
   public enum BossStates { NONE, PATROL, CHASING, ATTACK, ATTACK2, DIE }

    
    public BossStates BossState;

    private GameManager manager;

    public float Life;

    public float SpeedRotation;
    public float speed;
    public float speed_chasing;



    public float Attackspeed;
    public float tiempo;
    public float timing ;
    public float Attacktiming ;

    public float warningOffset;
    public float attackOffset;
    private bool hasSpawn = false;

    private Quaternion q;


    public GameObject LifeBar;
    public GameObject Floater;
    public GameObject LootParticles;
    public Collider LootCollider;
    public Collider NormalCollider;


    public bool CanDamage = false;

    public GameObject attackWarning;

    public GameObject target;
 
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    
    void Update()
    {

        
                switch (BossState)
                {
                    case BossStates.NONE:
                        break;
                    case BossStates.PATROL:
                        Patroling();
                        break;
                    case BossStates.CHASING:
                        Chasing();
                        break;
                    case BossStates.ATTACK:
                        Attacking();
                        break;
                    case BossStates.ATTACK2:
                        break;
                    case BossStates.DIE:
                        IsDead();
                        break;
                   
                }

        
            
        }

    



    public void ChangeState(BossStates state)
    {
        BossState = state;
    }
    public void Patroling()
    {
        tiempo = tiempo + Time.deltaTime;
  

        if (tiempo >= timing - 2) {

            transform.Rotate(Vector3.up * SpeedRotation * Random.Range(-1, 1) * Time.deltaTime);
            if (tiempo >= timing)
            {
                tiempo = 0;
            }
        }
        if (Vector3.Distance(transform.position, target.transform.position) >= 10f)
        {

            ChangeState(BossStates.CHASING);
            LifeBar.SetActive(true);
        }



        transform.position = transform.position + transform.forward * speed * Time.deltaTime;
    }

    public void Attacking()
    {
        tiempo = tiempo + Time.deltaTime;

        if (!CanDamage)
        {
           this.transform.LookAt(new Vector3 (target.transform.position.x, attackOffset, target.transform.position.z));
            var step = speed_chasing * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.transform.position.x, attackOffset, target.transform.position.z), step);
        }

        if (tiempo >= Attacktiming - 2.3f && tiempo <= Attacktiming - 1.25f)
        {
            if (!hasSpawn)
            {
                GameObject _warning = Instantiate(attackWarning);

                _warning.transform.position = new Vector3(this.transform.position.x, warningOffset, this.transform.position.z);

                Destroy(_warning, 2);

                hasSpawn = true;
            }
            CanDamage = true;
            
        }

        if (tiempo >= Attacktiming - 1.25f && tiempo <= Attacktiming - 0.75f)
        {
            hasSpawn = false;
            Vector3 v = new Vector3(270, 0, 0);
            transform.rotation = Quaternion.Euler(v);
            transform.position = transform.position + transform.forward * Attackspeed * Time.deltaTime;

        }

        if (tiempo >= Attacktiming - 0.75 && tiempo <= Attacktiming)
        {
            Vector3 v = new Vector3(90, 0, 0);
            transform.rotation = Quaternion.Euler(v);
            transform.position = transform.position + transform.forward * Attackspeed * Time.deltaTime;
        }
        if (tiempo >= Attacktiming)
        {
            
            CanDamage = false;
            SetDefaultPose();

        }
        if (tiempo >= Attacktiming + 1)
        {
            tiempo = 0;
            SetDefaultPose();
            ChangeState(BossStates.CHASING);

        }
    }
        void SetDefaultPose() {
        var step = speed_chasing * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, 0, transform.position.z), step);
        transform.rotation = new Quaternion(0, 0, 0, 0);

        }
        
        void Chasing()
        {
            this.transform.LookAt(target.transform);

            var step = (speed_chasing -7) * Time.deltaTime;

            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);

        }


        void IsDead()
        {
            NormalCollider.enabled = false;
            LootCollider.enabled = true;
            Floater.SetActive(true);
            LootParticles.SetActive(true);
        }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Life = Life - manager.bulletDamage;
            if(Life <= 0)
            {
                ChangeState(BossStates.DIE);
            }
        }
        if (other.gameObject.tag == "Player")
        {
           
            {
                ChangeState(BossStates.ATTACK);
            }
        }
    }
}
