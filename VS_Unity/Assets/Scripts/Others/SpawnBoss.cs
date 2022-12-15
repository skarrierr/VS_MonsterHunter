using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoss : MonoBehaviour
{
   public GameObject Boss;
   public GameObject MinimapBoss;
   public bool BossSpawned = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && !BossSpawned)
        {
            if (Input.GetKey(KeyCode.E))
            {
                Instantiate(Boss);
                BossSpawned = true;
                MinimapBoss.SetActive(true);
            }
        }
    }
}
