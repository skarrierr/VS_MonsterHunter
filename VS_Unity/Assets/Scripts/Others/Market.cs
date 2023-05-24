using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Market : MonoBehaviour
{
    public GameManager manager;

    public int NumCarneInventory;
    public int NumSangreInventory;

    public int NeedSangre = 2;
    public int NeedCarne = 3;

    public GameObject ShopPanel;
    public Text SangreText;
    public Text CarneText;

    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        SangreText.color = Color.black;
        CarneText.color = Color.black;
        UpdateShop();
        SangreText.text = NumSangreInventory + "/" + NeedSangre;
        CarneText.text = NumCarneInventory + "/" + NeedCarne;
    }

   
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
                ShopPanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ShopPanel.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            NumCarneInventory = 0;
            NumSangreInventory = 0;
        }
    }


    public void BuyCebo()
    {
        int tempNeedCarne = NeedCarne;
        int tempNeedSangre = NeedSangre;

        List<int> tempInventory = manager.Inventory;


        if (NumCarneInventory >= NeedCarne && NumSangreInventory >= NeedSangre)
        {
            manager.Inventory.Add(3);
            
            for (int i = 0; i < tempInventory.Count; i++)
            {
                if (manager.Inventory[i] == 1 && tempNeedCarne > 0)
                {
                    manager.Inventory.Remove(i);
                    tempNeedCarne--;
                    
                }
                if (manager.Inventory[i] == 2 && tempNeedSangre > 0)
                {
                    manager.Inventory.Remove(i);
                    tempNeedSangre--;
                }
            }
            manager.CompleteQuest(1, 2);
        }
        else
        {
            SangreText.color = Color.red;
            CarneText.color = Color.red;
        }
        
    }

    public void UpdateShop()
    {
        NumCarneInventory = 0;
        NumSangreInventory = 0;

        for (int i = 0; i < manager.Inventory.Count; i++)
        {
            if (manager.Inventory[i] == 1)
            {
                NumCarneInventory++;
            }
            if (manager.Inventory[i] == 2)
            {
                NumSangreInventory++;
            }
        }
    }
}
