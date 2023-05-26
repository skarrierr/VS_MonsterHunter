using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoss : MonoBehaviour
{
   public GameObject Boss;
   public GameObject MinimapBoss;
   public GameObject LifeBar;
   public bool BossSpawned = false;
    public GameManager manager;

    public torretaç torreta;
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        torreta = GameObject.FindGameObjectWithTag("ballesta").GetComponent<torretaç>();
    }private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && !BossSpawned)
        {
            if (Input.GetKey(KeyCode.E))
            {
                for (int i = 0; i < manager.Inventory.Count; i++)
                {
                    if (manager.Inventory[i] == 3)
                    {
                        torreta.objetivo = Boss;
                        Boss.SetActive(true);
                        BossSpawned = true;
                        manager.CompleteQuest(2, 0);
                        MinimapBoss.SetActive(true);
                    }
                }
                LifeBar.SetActive(true);
            }
        }
    }
}
