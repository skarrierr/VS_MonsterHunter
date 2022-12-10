using Newtonsoft.Json.Bson;
using System.Linq;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MobController : MonoBehaviour
{
    //Asegurar que todos que el tiempo vuelva a cero antes de cambiar de estado
  
   public enum BossStates { NONE, PATROL, CHASING, ATTACK, ATTACK2, ATTACK3 }

    
    public BossStates BossState;

    public float SpeedRotation;
    public float speed;
    public float speed_chasing;

    public float Attackspeed;
    public float tiempo;
    public float timing ;
    public float Attacktiming ;

    public float warningOffset;
    private bool hasSpawn = false;

    private Quaternion q;





    public bool CanDamage = false;

    public GameObject attackWarning;

    public GameObject target;
 
    void Start()
    {
        
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
                        Patroling();
                        break;
                    case BossStates.ATTACK:
                        Attacking();
                        break;
                    case BossStates.ATTACK2:
                        break;
                    case BossStates.ATTACK3:
                        break;
                    default:
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


        
        transform.position = transform.position + transform.forward * speed * Time.deltaTime;
    }

    public void Attacking()
    {
        tiempo = tiempo + Time.deltaTime;

        if (!CanDamage)
        {
            this.transform.LookAt(target.transform);
            var step = speed_chasing * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
            print("patroling");
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
            SetDefaultPose();
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
            ChangeState(BossStates.CHASING);

        }
    }
        void SetDefaultPose() {
        var step = speed_chasing * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, -1, transform.position.z), step);
        transform.rotation = new Quaternion(0, 0, 0, 0);
        

    }
}
