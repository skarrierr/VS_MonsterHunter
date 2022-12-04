using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MobController : MonoBehaviour
{
   public enum MobType { NONE, ARPIA, FISH, BOSS }
   public enum BossStates { NONE, PATROL, CHASING, ATTACK, ATTACK2, ATTACK3 }

    public MobType mobType;
    public BossStates BossState;

    public float SpeedRotation;
    public float speed;
    public float speed_attack;

    public float tiempo;
    public float timing ;

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
        var step = speed_attack * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position,step);
    }
}
