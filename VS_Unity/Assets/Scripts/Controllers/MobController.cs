using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobController : MonoBehaviour
{
   public enum MobType { NONE, ARPIA, FISH, BOSS }
   public enum BossStates { NONE, PATROL, IDLE, ATTACK, ATTACK2, ATTACK3 }

    public MobType mobType;
    public BossStates BossState;
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
                        break;
                    case BossStates.IDLE:
                        break;
                    case BossStates.ATTACK:
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
}
