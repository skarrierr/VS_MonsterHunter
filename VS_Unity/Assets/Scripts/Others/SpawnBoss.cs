using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoss : MonoBehaviour
{
   public GameObject Boss;
   public GameObject MinimapBoss;
   public bool BossSpawned = false;
    public GameManager manager;
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && !BossSpawned)
        {
            if (Input.GetKey(KeyCode.E))
            {
                Boss.SetActive(true);
                BossSpawned = true;
                manager.CompleteQuest(2,0);
                MinimapBoss.SetActive(true);
            }
        }
    }
}
