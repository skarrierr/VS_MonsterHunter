using Newtonsoft.Json.Bson;
using System.Linq;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MobController : MonoBehaviour
{
    //Asegurar que todos que el tiempo vuelva a cero antes de cambiar de estado
   public enum MobType { NONE, ARPIA, FISH, BOSS }
   public enum BossStates { NONE, PATROL, CHASING, ATTACK, ATTACK2, ATTACK3 }

    public MobType mobType;
    public BossStates BossState;

    public float SpeedRotation;
    public float speed;
    public float speed_chasing;

    public float Attackspeed;
    public float tiempo;
    public float timing ;
    public float Attacktiming ;


    public bool CanDamage = false;

    public GameObject attackWarning;

    public GameObject target;
 
    void Start()
    {
        
    }

    
    void Update()
    {

        switch (mobType)
        {
            case MobType.NONE:

                break;
            case MobType.ARPIA:

                break;
            case MobType.FISH:

                break;

            case MobType.BOSS:
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

                break;
            
        }

    }

    private void OnTriggerEnter(Collider other)
    {
       
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
        }
        if (tiempo > 0 && tiempo < 1)
        {
            this.transform.LookAt(target.transform);
            var step = speed_chasing * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
        }
        if (tiempo >= Attacktiming - 1.0f && tiempo<= Attacktiming - 2)
        {
            Instantiate(attackWarning);
            CanDamage = true;
                
        }
        if (tiempo >= Attacktiming-2 && tiempo<= Attacktiming - 1)
        {
            transform.rotation = new Quaternion(-90,transform.rotation.y, transform.rotation.z, transform.rotation.z);
            transform.position = transform.position + transform.up * Attackspeed * Time.deltaTime;
        }
        if (tiempo >= Attacktiming - 1 && tiempo <= Attacktiming)
        {
            transform.rotation = new Quaternion(90, transform.rotation.y, transform.rotation.z, transform.rotation.z);
            transform.position = transform.position - transform.up * Attackspeed * Time.deltaTime;
        }
        if (tiempo >= Attacktiming){
            
            CanDamage = false;
            tiempo = 0;
            ChangeState(BossStates.CHASING);
        }

    }
}
